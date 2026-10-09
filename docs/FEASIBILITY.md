# Faisabilité technique
Recherche documentaire du 9 octobre 2026. Aucun jeu ni Melty installé ou exécuté ici. Aucun hook, lancement automatique ou calcul en jeu validé.

## Verdict
Megabonk présente une voie de modding communautaire crédible. L'intégration du véritable Math-Havoc est le principal risque : son moteur et l'accès programmatique à ses réponses restent inconnus. Melty fournit un parcours de création et de distribution, mais ne constitue pas une preuve que cette paire de jeux soit compatible.

| Sujet | Évidence disponible | Statut du projet |
| --- | --- | --- |
| Megabonk | Modèle de plugin BepInEx pour Unity IL2CPP [S1] | Voie plausible ; version locale à vérifier |
| Pause, collecte, niveau, statistiques | Aucun point d'accroche inspecté ici | Non validés |
| Math-Havoc | Fiche du développeur : mode Havoc parmi trois modes principaux [S3] | Mode confirmé |
| Moteur/API Math-Havoc | Aucune documentation d'extension identifiée dans les recherches | Inconnu ; absence de résultat ne prouve pas une impossibilité |
| Melty | Site : instructions à fournir à Codex ou Claude Code [S4] | Parcours confirmé ; instructions techniques non obtenues |
| Distribution | Melty décrit test local et audit des releases [S5] | Hors portée du cadrage |

## Megabonk
[S1], publié par l'auteur d'un modèle de mod, documente un plugin C# avec BepInEx IL2CPP et des références locales aux bibliothèques du jeu. C'est une preuve communautaire, pas un SDK officiel ni une garantie pour une version actuelle.
[S2], documentation officielle de BepInEx, décrit l'installation sur Unity IL2CPP et le choix de la distribution adaptée. Ne pas figer le numéro de build historique du modèle.

Sur la copie Windows :
1. Relever la version exacte, l'architecture et les fichiers caractéristiques du moteur.
2. Tester un plugin minimal dans un profil séparé.
3. Identifier les méthodes réelles pour collecte, niveau, pause et recalcul des statistiques ; consigner signatures et version.
4. Vérifier que la pause arrête aussi chronomètres, dégâts, physique et tâches qui utiliseraient un temps indépendant.
5. Vérifier que les changements de M peuvent diminuer comme augmenter les valeurs sans empilement.

BepInEx/Harmony sont des candidats. Aucune classe du jeu ou méthode de pause n'est inventée dans cette architecture.

## Math-Havoc
[S3] confirme le jeu de João Lemes, son mode Havoc et des sessions mathématiques rapides ; elle ne documente pas une API de modding, son moteur ni les paramètres de lancement.
Ne pas présumer Unity et ne pas installer BepInEx sur ce jeu sans identification.

Inspection nécessaire :
- moteur et runtime, version et fichiers de configuration ;
- démarrage/reset du mode Havoc ;
- événement de réponse correcte/incorrecte, identifiant de question et fin du chronomètre ;
- possibilité d'arrêter immédiatement une session sur erreur ;
- possibilité de transmettre ces informations localement.

Si aucun adaptateur fiable n'est possible, demander un point d'extension au développeur ou revoir le périmètre. Un changement de fenêtre ou un lancement Steam seul ne donne pas les résultats. OCR et saisies simulées seraient fragiles ; ce ne sont pas la voie prévue. Un mini-jeu recréé serait un autre produit et ne satisferait pas l'intégration du véritable Math-Havoc.

## Melty
[S4] décrit un lanceur Windows qui installe des mashups, démarre les jeux possédés et propose des instructions pour agents de programmation.
[S5] décrit également les sauvegardes des fichiers remplacés, les builds locaux et l'audit avant publication, avec exécution réussie sur le PC du créateur.

Il faut récupérer les instructions de création actuelles depuis Melty et vérifier leur format de package, dépendances, lancement, arrêt et désinstallation. Aucun manifeste, SDK ou commande de publication supposés ne sont créés.
Universal Modder [S6] documente un outillage communautaire d'inspection et de test ; aucun lien technique obligatoire avec Melty n'a été établi ici. Il n'est ni installé ni exécuté.

## Ordre de preuve recommandé
1. Inventaire Windows des deux jeux et instructions Melty.
2. Megabonk : déclencheur journalisé et pause/reprise fiables.
3. Math-Havoc : session Havoc commandable et résultats fiables.
4. Contrat local entre adaptateurs avec simulation des pannes.
5. Règles de multiplicateur testées indépendamment.
6. Prototype complet, tests en jeu, puis paquet Melty et désinstallation.

Arrêt de faisabilité si les réponses exactes de Math-Havoc ne peuvent pas être observées ou si la pause Megabonk n'est pas fiable. Les documents et tests de logique pourront être travaillés sans installations ; les preuves en jeu exigent le PC Windows.

## Sources
Sources primaires consultées le 9 octobre 2026 ; les exemples de mods viennent de leurs auteurs et restent non officiels.
- [S1 — Modèle Megabonk, Oksamies](https://github.com/Oksamies/MEGABONK_SIMPLE_MOD)
- [S2 — BepInEx : installation Unity IL2CPP](https://docs.bepinex.dev/master/articles/user_guide/installation/unity_il2cpp.html)
- [S3 — Fiche Steam Math-Havoc](https://store.steampowered.com/app/4607690/MathHavoc/)
- [S4 — Site Melty](https://melty.gg/)
- [S5 — Melty, conditions, sections 4, 6 et 7](https://melty.gg/terms)
- [S6 — Universal Modder, dépôt de l'auteur](https://github.com/rehan-remade/universal-modder)

Ne versionner ni fichiers propriétaires des jeux, ni sauvegardes personnelles, ni secrets. Les tests de compatibilité doivent être faits sur des copies légitimes avec sauvegarde préalable. Aucune publication Melty effectuée.
