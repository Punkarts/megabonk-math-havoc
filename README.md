# Megabonk × Math-Havoc
Projet de mashup destiné à Melty : interrompre temporairement Megabonk pour jouer une session du véritable Math-Havoc en mode Havoc, puis traduire les réponses en bonus durables.

## État
Cadrage documentaire au 9 octobre 2026. Aucun mod implémenté, aucune compilation ni session de jeu testée. Aucun accès aux installations Windows des jeux dans cet environnement. La faisabilité complète reste conditionnelle, surtout pour Math-Havoc.

## Boucle de jeu
- Obtenir un objet, un bonus ou un niveau déclenche une session mathématique.
- Megabonk reste en pause pendant cette session.
- Les bonnes réponses augmentent le multiplicateur.
- Une mauvaise réponse termine immédiatement la session et divise par deux le multiplicateur permanent.
- Le chronomètre arrivé à zéro termine la session sans malus et crédite les bonnes réponses.

Les formules et choix provisoires sont détaillés dans les [spécifications](docs/SPECIFICATIONS.md).

## Organisation
| Chemin | Rôle |
| --- | --- |
| [docs/SPECIFICATIONS.md](docs/SPECIFICATIONS.md) | Règles, hypothèses et exemples |
| [docs/FEASIBILITY.md](docs/FEASIBILITY.md) | Sources, incertitudes et vérifications nécessaires |
| [docs/ARCHITECTURE.md](docs/ARCHITECTURE.md) | Composants proposés et échanges entre jeux |
| [src/README.md](src/README.md) | Emplacement réservé au futur code |
| [tests/README.md](tests/README.md) | Scénarios de validation futurs |

## Prochaine étape
Sur Windows, relever les versions et moteurs réels, récupérer les instructions de création fournies par Melty, puis prouver séparément la pause de Megabonk et la lecture des réponses de Math-Havoc. Ne choisir les dépendances et ne développer le prototype qu'après ces vérifications.

Le dépôt contient uniquement les documents du projet ; aucun binaire, ressource, sauvegarde ou jeton des jeux. La préparation sur GitHub ne rend pas les installations locales accessibles à Codex.
