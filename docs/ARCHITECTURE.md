# Architecture proposée
Contrats conceptuels, sans implémentation. Les langages, loaders et transports seront choisis après l'inspection des jeux.

## Composants
| Composant futur | Responsabilité | Condition |
| --- | --- | --- |
| Adaptateur Megabonk | Observer les acquisitions, gérer sa propre pause, appliquer M | Hooks locaux vérifiés ; C#/BepInEx IL2CPP candidat |
| Coordinateur | File des acquisitions, cycle de session, clôture unique et récupération | Un seul propriétaire de l'état |
| Adaptateur Math-Havoc | Démarrer/reset Havoc, produire réponses et raisons de fin | Moteur et accès aux événements à identifier |
| Règles de bonus | Calcul pur du M suivant selon le résultat | Choix gameplay validés |
| État de partie | M, identifiants et transactions terminées | Portée de persistance validée |
| Intégration Melty | Dépendances, installation, lancement et désinstallation | Instructions réelles de Melty obtenues |

Proposition : deux jeux exécutés séparément, reliés par un canal local et un coordinateur. Ce modèle évite de supposer qu'ils partagent un moteur ou qu'une fenêtre puisse être embarquée. Il reste à prouver que les deux adaptateurs sont possibles.

## Cycle
États conceptuels : Megabonk actif → pause demandée → Math-Havoc en préparation → session active → résultat validé → bonus appliqué → restauration de la pause précédente.
Toute panne va vers récupération avec M inchangé. Une session active bloque les nouvelles ouvertures ; les acquisitions distinctes sont mises en file.

1. Identifier une acquisition logique et sauvegarder le contexte de pause.
2. Obtenir confirmation de pause effective ; sinon ne pas ouvrir de session.
3. Créer session_id et run_id ; demander Havoc à l'adaptateur.
4. Attendre « prêt » avec délai de préparation distinct du chronomètre de gameplay.
5. Compter les réponses validées dans l'ordre ; clôturer à la première erreur ou à l'expiration.
6. Valider le résultat, calculer M une fois et préparer la transaction.
7. Appliquer les valeurs dans Megabonk ; enregistrer la clôture uniquement après confirmation.
8. Restaurer focus, entrées et pause ; traiter l'acquisition suivante si nécessaire.

## Contrat local proposé
Messages : StartSession, SessionReady, AnswerValidated, SessionEnded, CancelSession, ApplyMultiplier, MultiplierApplied.
Champs communs : protocol_version, run_id, session_id, event_id, sequence.
Réponse : question_id, verdict, instant relatif validé.
Fin : reason = wrong_answer | timer_expired | cancelled | technical_error ; total de bonnes réponses cohérent avec les événements.

Le coordinateur accepte seulement les messages du jeu attendu, pour la partie/session courante. Dédupliquer event_id, refuser les séquences incohérentes et ignorer les événements après clôture. Utiliser une horloge monotone commune ou une échéance relative normalisée, jamais comparer directement des horloges murales de processus.

Transport candidat : named pipes Windows ou socket loopback, privé à la session avec authentification locale. Aucun accès réseau public nécessaire. Ce contrat n'est pas une API existante des jeux ou de Melty.

## Cohérence et récupération
Journal transactionnel : M avant, résultat accepté, M cible, état d'application, identifiant de transaction. ApplyMultiplier doit être idempotent et fixer une valeur cible, jamais ajouter aveuglément un gain.
En cas de crash après application mais avant accusé de réception, réconcilier la transaction avec l'adaptateur avant de poursuivre : ni deuxième gain ni deuxième pénalité.
Un watchdog détecte perte de liaison, fermeture d'un jeu et délai de préparation. Restaurer uniquement la pause acquise par le mashup ; préserver un menu de récompense ou une pause utilisateur.
Ne pas suspendre brutalement le processus Megabonk comme mécanisme normal.

## Implantation future
Sous src/ : core/, adapters/megabonk/, adapters/math-havoc/, coordinator/, packaging/melty/.
Sous tests/ : unit/, protocol/, integration/ et manual/.
Ces sous-modules sont une proposition documentaire, pas des dépendances ni projets compilables.

## Limites
Aucune importation des ressources d'un jeu dans l'autre prévue. Aucun hook, API Havoc, manifeste Melty, loader Math-Havoc ou script d'installation créé. Le développement du mod complet est différé.
