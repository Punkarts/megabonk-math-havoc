# Spécifications de gameplay
Version de cadrage — 9 octobre 2026.

## Règles demandées
1. Une acquisition d'objet, de bonus ou un gain de niveau dans Megabonk déclenche une session Math-Havoc en mode Havoc.
2. Megabonk est mis en pause ; simulation, ennemis, dégâts et temps de partie ne doivent pas avancer.
3. Chaque bonne réponse contribue au multiplicateur permanent.
4. La première réponse incorrecte arrête la session et divise les multiplicateurs permanents par deux.
5. L'expiration du compte à rebours termine sans pénalité et ajoute un gain proportionnel au nombre de bonnes réponses.
6. Le résultat est appliqué une seule fois avant le retour à Megabonk.

## Choix validés le 9 octobre 2026
- Développement local, Megabonk reste le jeu principal.
- Bonus limité aux dégâts.
- Multiplicateur initial ×1, remis à ×1 à chaque nouvelle partie, aucune persistance entre parties.
- Session de 10 secondes.
- Gain de +0,01 par bonne réponse.
- Sur erreur : ajouter les gains de cette session puis diviser le total par deux, soit (M précédent + n × 0,01) / 2.
- Expiration sans erreur : M précédent + n × 0,01.
Ces choix remplacent les hypothèses historiques de la section suivante.

## Interprétation actualisée
Le bonus dure toute la partie Megabonk, puis est réinitialisé à la suivante. M = 1 au départ et g = 0,01.

Pendant la session, compter les bonnes réponses et afficher le total provisoire. À la clôture :
- Temps écoulé : M suivant = M précédent + n × 0,01.
- Réponse incorrecte : M suivant = (M précédent + n × 0,01) / 2.
- Annulation ou panne technique : M inchangé.

Aucun plancher à 1 : le multiplicateur peut devenir inférieur à 1.

| M avant | Bonnes réponses | Fin | M après |
| --- | --- | --- | --- |
| 1 | 10 | Temps écoulé | 1,10 |
| 1 | 10 | Réponse incorrecte | 0,55 |
| 1 | 0 | Temps écoulé | 1 |
| 1 | 0 | Réponse incorrecte | 0,50 |

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
Durée retenue : 10 secondes. Vérifier le chronomètre natif : s'il s'agit d'un temps par question plutôt que par session, documenter l'adaptation nécessaire. L'horloge de la session continue indépendamment de la pause de Megabonk et démarre lorsque Math-Havoc confirme qu'il est prêt.
Une réponse n'est comptée que si elle est validée avant l'échéance. À l'échéance exacte, le temps écoulé prime ; un événement tardif ne provoque aucun malus.
La fermeture normale de session et l'expiration ont une raison distincte de la réponse incorrecte.

## Application des bonus
Statistique retenue : dégâts uniquement. Identifier la valeur et le point de recalcul réels après inspection. Ne pas multiplier indistinctement les temps de recharge, effets booléens ou statistiques plafonnées.
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
Restent à préciser : liste des bonus déclencheurs et regroupement des acquisitions. Les choix validés plus haut font autorité ; les détails techniques restent à vérifier.
