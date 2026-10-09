# Spécifications de gameplay
Version de cadrage — 9 octobre 2026.

## Règles demandées
1. Une acquisition d'objet, de bonus ou un gain de niveau dans Megabonk déclenche une session Math-Havoc en mode Havoc.
2. Megabonk est mis en pause ; simulation, ennemis, dégâts et temps de partie ne doivent pas avancer.
3. Chaque bonne réponse contribue au multiplicateur permanent.
4. La première réponse incorrecte arrête la session et divise les multiplicateurs permanents par deux.
5. L'expiration du compte à rebours termine sans pénalité et ajoute un gain proportionnel au nombre de bonnes réponses.
6. Le résultat est appliqué une seule fois avant le retour à Megabonk.

## Interprétation proposée, à confirmer avant implémentation
Le mot « permanent » ne précise pas si le bonus survit à la mort, à une nouvelle partie ou au redémarrage. Proposition initiale : bonus conservé pendant toute la partie Megabonk, réinitialisé à la suivante. Une persistance entre parties reste une décision ouverte.

Pour le cadrage, utiliser un multiplicateur global M appliqué aux seules statistiques explicitement compatibles. Valeur initiale : M = 1. Chaque bonne réponse vaut un incrément configurable g, illustré par g = 0,05. Aucun montant n'a été imposé par l'utilisateur.

Pendant la session, afficher un gain provisoire n × g, sans modifier Megabonk. À la clôture :
- Temps écoulé : M suivant = M précédent + n × g.
- Réponse incorrecte : M suivant = M précédent / 2 ; le gain provisoire de cette session est perdu.
- Annulation, crash ou panne de communication : M inchangé ; aucune pénalité technique.

La perte des gains provisoires sur erreur est une proposition : l'autre interprétation possible est (M précédent + n × g) / 2. Le choix doit être fixé avant de coder. La division concerne ici le multiplicateur total, pas seulement son surplus au-dessus de 1. Aucun plancher à 1 n'est ajouté : M peut devenir inférieur à 1.

| M avant | Bonnes réponses | Fin | M après avec g = 0,05 |
| --- | --- | --- | --- |
| 1 | 10 | Temps écoulé | 1,50 |
| 1,50 | 4 | Réponse incorrecte | 0,75 |
| 0,75 | 5 | Temps écoulé | 1 |
| 1 | 0 | Temps écoulé | 1 |
| 1 | 0 | Réponse incorrecte | 0,50 |
| 1,50 | 4 | Panne technique | 1,50 |

## Déclencheurs
Les événements doivent provenir de l'état du jeu, pas d'une reconnaissance visuelle.
- Objet : acquisition effective ; identifier les objets concernés.
- Bonus : acquisition ponctuelle ; liste exacte encore à définir.
- Niveau : augmentation effective du niveau ; pas chaque affichage de menu.
- Chaque événement reçoit une identité stable ; les notifications répétées sont dédupliquées.
- Proposition : un level-up et le choix de récompense associé comptent comme une seule acquisition logique. Des acquisitions réellement distinctes sont mises en file, sans lancer plusieurs sessions simultanées.
- XP, monnaie, soins, coffres avec plusieurs objets : périmètre à confirmer. Ne pas supposer que toute collecte doit ouvrir une session.

Proposition d'ordre : laisser se terminer l'attribution de la récompense et le choix éventuel, puis prendre la pause dès un point sûr avant de reprendre la simulation. Vérifier ce point dans le jeu.

## Session et temps
Utiliser le véritable mode Havoc. Ne pas remplacer Math-Havoc par un quiz maison sans une nouvelle décision.
Durée configurable, valeur non fixée. Vérifier le chronomètre natif : s'il s'agit d'un temps par question plutôt que par session, documenter l'adaptation nécessaire. L'horloge de la session continue indépendamment de la pause de Megabonk et démarre lorsque Math-Havoc confirme qu'il est prêt.
Une réponse n'est comptée que si elle est validée avant l'échéance. À l'échéance exacte, le temps écoulé prime ; un événement tardif ne provoque aucun malus.
La fermeture normale de session et l'expiration ont une raison distincte de la réponse incorrecte.

## Application des bonus
Définir une liste de statistiques positives à multiplier après inspection : dégâts, vitesse, etc. sont seulement des candidats. Ne pas multiplier indistinctement les temps de recharge, effets booléens ou statistiques plafonnées.
Calculer depuis la valeur de référence et le M courant, jamais depuis la valeur déjà multipliée. Tout objet acquis ultérieurement doit être recalculé avec M, sans cumuler deux fois le même effet.
Préciser les interactions avec bonus additifs, sauvegarde/chargement et autres mods.

## Acceptation
- Une seule session par acquisition logique ; aucune récursion via l'application du bonus.
- Pause conservée jusqu'à la clôture ; menus et saisie ne passent pas simultanément aux deux jeux.
- Exactement n bonnes réponses créditées lors de l'expiration.
- Erreur : une seule division par deux et arrêt immédiat.
- Zéro réponse à l'expiration : aucun changement.
- Résultat répété ou provenant d'une ancienne session : ignoré.
- Crash ou fermeture : récupération sans malus ; retour à l'état de pause antérieur, jamais dépauser un menu qui était déjà ouvert.
- Nouvelle partie : appliquer la politique de persistance choisie.

## Décisions ouvertes
Portée de « permanent », valeur de g, durée, traitement des bonnes réponses précédant une erreur, multiplicateur global ou plusieurs catégories, statistiques affectées, liste des bonus déclencheurs et regroupement des acquisitions. Les propositions ci-dessus ne valent pas validation utilisateur.
