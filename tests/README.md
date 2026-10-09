# Futurs tests
Plan de validation seulement : aucun test exécuté ni suite automatisée créée.

## Logique isolée
Vérifier les exemples chiffrés de [SPECIFICATIONS.md](../docs/SPECIFICATIONS.md), zéro bonne réponse, plusieurs erreurs successives, M inférieur à 1 et absence de malus technique. Tester la formule retenue après validation des décisions ouvertes.

## Protocole
Simuler doublons, résultat périmé, réponses désordonnées, expiration simultanée à une réponse, timeout de préparation et crash pendant l'application. Chaque résultat doit être crédité exactement une fois.

## Intégration Windows
- Déclencher séparément objet, bonus et niveau.
- Vérifier déduplication d'un level-up et de sa récompense.
- Contrôler position, santé, ennemis et temps avant/après la pause.
- Observer les événements réels du mode Havoc.
- Comparer les statistiques avant/après augmentation puis division de M.
- Vérifier focus, saisie, menus, crash, reconnexion et nouvelle partie.
- Installer puis désinstaller via le parcours Melty effectivement documenté.

Pour chaque preuve future, enregistrer versions des jeux/loaders, configuration, résultat attendu, résultat observé et logs utiles sans secrets. Ne jamais déclarer un test de jeu réussi sur la seule base d'un test de logique.
