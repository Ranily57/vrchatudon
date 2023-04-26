Veuillez lire les notes de patch complètes.

https://docs.vrchat.com/v2023.2.2/docs/latest-release

# Client

## Fonctionnalités

- Introduction du **Mode guidé** !
  - Le mode guidé est un menu rapide simplifié destiné aux nouveaux utilisateurs, facilitant l'exploration de VRChat et l'apprentissage des fonctions vitales.
  - Ce mode est disponible pour tous les utilisateurs dans la version Open Beta pour test. 
  - Vous pouvez quitter le mode guidé pour revenir au menu rapide normal.
  - Une fois cette version mise en ligne, le mode guidé ne sera accessible qu'à certains nouveaux utilisateurs pour des tests supplémentaires.
  - Plus tard, nous le publierons entièrement et permettrons facultativement à tous les utilisateurs d'activer la fonctionnalité s'ils le préfèrent.

## Améliorations

- **Les statistiques d'avatar sont désormais calculées sur le serveur**
  - Les avatars qui dépassent votre limite de classement de performances ne seront pas téléchargés.
  - Cela ne fonctionnera pas sur tous les avatars, car les avatars doivent être analysés en premier ! Cela affectera principalement les avatars nouvellement téléchargés ou récemment mis à jour.
- Le clavier intégré réagit maintenant au début de l'action de clic (Souris/TriggerDown) au lieu de la fin (Souris/TriggerUp), ce qui le rend plus réactif.
- De nombreux changements ont été apportés à notre interface de signalement pour faciliter le signalement des utilisateurs et du contenu.
- Ajout d'un indicateur visuel lors de l'ajustement de la distance de priorité de téléchargement d'avatar.

## Corrections

- Correction d'un problème où la duplication d'avatar n'était pas activée correctement malgré l'affichage de l'interface utilisateur indiquant que c'était le cas.
- Correction du mode de déplacement à une main sur Quest standalone et Virtual Desktop.
- Correction du spam de journal et de la dégradation des performances sur les avatars ayant un nombre différent de paramètres entre les plateformes.
- L'ordre du bouton "Envoyer une invitation" sur la page d'utilisateur de QM est maintenant cohérent avec "Demander une invitation" et "Rejoindre".
- Ajustement de la taille des boutons de cache-oreilles sur la page Audio QM.
- La position de la bulle de discussion revient maintenant par défaut à "Au-dessus de la tête".
  - Votre paramètre de bulle de discussion sera défini sur "Au-dessus de la tête" lors du premier lancement de cette version.
- VRCat s'était encore échappé, mais nous avons utilisé des friandises stratégiques pour le faire revenir sur le menu rapide.
- Correction d'un problème avec la connexion à des instances sans nom court depuis la ligne de commande ou les liens URL.
  - Cela corrige l'onglet "Créer" de VRCQuickLauncher et certaines autres applications.
- Amélioration des temps de chargement initiaux lors de l'ouverture de VRChat sur Quest.
- Amélioration de la saccade lors du chargement de plusieurs avatars successifs.
- La HUD, le menu d'action et les vues de débogage sont désormais correctement mis à l'échelle lorsque le champ de vision est modifié.
- Amélioration des performances du visualiseur de journal de débogage intégré au jeu (menu de débogage 3).
- Correction d'un problème qui provoquait parfois l'apparition d'indicateurs de distance de cache-oreilles dans les scènes de chargement.

### Corrections des paramètres du menu principal

- Changement de l'en-tête de la section "Votre avatar" en "Débogage d'avatar".
- Ajustement des paramètres de locomotion et de tunnelisation aux valeurs par défaut d'origine.
- Les fenêtres contextuelles ne vous empêchent plus d'utiliser les paramètres qui y sont cachés.
- Les options de plaque signalétique ont été ajustées dans les nouveaux paramètres pour correspondre à celles du menu d'action.
  - La taille de votre plaque signalétique sera réinitialisée lors du premier lancement de cette version.
- Les paramètres de cache-oreilles sont désormais identiques dans les pages de paramètres MM et QM.
- Les info-bulles pour les cache-oreilles dans MM étaient inversées.
- Ajout de plusieurs info-bulles manquantes.
- Les paramètres de masquage de distance d'avatar sont désormais cohérents entre les pages de paramètres QM et MM.
- Le curseur de hauteur de la bulle de discussion était manquant.
- Les ailes dans le menu rapide ne se réinitialisent plus après l'ouverture de la page "Interface utilisateur".

## Problèmes connus

- L'Open Beta n'est pas encore disponible sur Quest.
- Les portails vers des mondes disponibles uniquement sur une seule plateforme affichent parfois l'anneau d'incompatibilité de la plateforme pour les utilisateurs sur la plateforme correcte.
- Certains avatars qui devraient être des avatars de secours sur Quest sont affichés comme bloqués pour des raisons de performances ; d'autres sont affichés comme l'avatar d'erreur.
- Après avoir effacé les paramètres utilisateur, le monde de tutoriel peut vous faire apparaître à la mauvaise position.
- Certains aides visuelles de distance sont trop bas et ne peuvent pas être vues même sur un sol plat.

# SDK

Veuillez consulter le canal d'informations Open Beta pour savoir comment accéder au SDK de pré-version.

## Fonctionnalités

- **DataContainers !** Listes, dictionnaires et JSON pour Udon !
  - Ajout de DataLists et de DataDictionaries, donnant à Udon des fonctionnalités similaires à celles des listes et des dictionnaires.
    - Les listes et les dictionnaires doivent généralement prendre en charge des génériques, et Udon ne les prend pas en charge, c'est pourquoi cela est fait en mettant vos données dans des DataTokens d'abord, qui peuvent stocker n'importe quelle valeur.
  - Ajout de VRCJSON, une classe d'aide qui peut convertir les chaînes JSON (comme celles reçues depuis [Remote String Loading](doc:string-loading)) en DataLists et DataDictionaries et vice versa.
  - [Lisez la page de documentation sur les Data Containers / VRCJSON](doc:data-containers-vrcjson) pour en savoir plus.

- **AsyncGPUReadback !** Cela vous permet de lire des données de GPU et de shaders sans coût de performance élevé
  - Ajoute la fonction `VRCAsyncGPUReadback.Request` et l'événement correspondant `OnAsyncGpuReadbackComplete`
  - Ces fonctions lisent les données du GPU dans la mémoire CPU sans trop d'impact sur les performances, au détriment du retard des données d'une ou plusieurs images.
  - Consultez la [documentation AsyncGPUReadback](doc:asyncgpureadback) pour plus d'informations.

## Améliorations

- **Squishy PhysBones !** Vous pouvez maintenant implémenter des PhysBones qui peuvent "s'écraser" ou se comprimer plutôt que de s'étirer !
  - Pour configurer un PhysBone Squishy, échangez votre composant PhysBone en version 1.1 et ajustez la valeur "Max Squish".
  - **Tous les PhysBones sont maintenant versionnés !** Vous pouvez changer la version dans le composant PhysBone. Cela est fait pour nous permettre d'ajouter de nouvelles fonctionnalités en toute sécurité.
    - Les anciens PhysBones sont automatiquement en Version 1.0.
    - Les fonctionnalités Squishy PhysBones sont en Version 1.1. Il y a d'autres changements documentés ci-dessous.
    - **Toutes les versions seront maintenues.** 1.0 n'est pas obsolète, mais il est verrouillé et ne bénéficiera pas de nouvelles fonctionnalités. À chaque fois que nous ajoutons une nouvelle fonctionnalité "définitive", nous incrémenterons la version.
  - PhysBones 1.1 : **La gravité et la rigidité agissent différemment et nécessitent de nouvelles valeurs si vous effectuez une mise à niveau à partir de 1.0.**
    - La gravité est maintenant le rapport de combien les os doivent pointer droit vers le haut/le bas dans l'espace mondial lorsqu'ils sont au repos.
    - La rigidité est maintenant le rapport de combien un os tente de rester dans son orientation précédente.
    - Auparavant, ces valeurs étaient des forces directes que vous deviez équilibrer avec le facteur de traction. Nous pensons que cela devrait être plus direct et plus facile à utiliser.
    - Ces changements étaient également nécessaires pour prendre en charge la nouvelle fonctionnalité ajoutée au composant.
  - PhysBones 1.1 : **La valeur Max Squish a été ajoutée.** C'est un pourcentage de la réduction maximale d'un os.
    - Le paramètre `_Squish` a été ajouté. Il fonctionne de manière similaire au paramètre `_Stretch`.
  - PhysBones 1.1 : **La valeur Stretch Motion a été ajoutée.** C'est un rapport de la manière dont le mouvement affecte l'étirement ou la compression d'un os.
  - Les catégories de valeurs dans l'interface utilisateur du composant VRCPhysBone peuvent maintenant être repliées.
    - Les catégories incluent également un bouton d'aide qui vous amènera à la documentation en ligne pour ce sujet.
  - La documentation sur les [PhysBones](doc:physbones) sera mise à jour pendant la Open Beta pour les PhysBones 1.1 et Squishy PhysBones.
- L'utilitaire Network ID fonctionne maintenant pour les PhysBones dans les projets d'avatar.
  - Cet outil permet la synchronisation des PhysBones entre les avatars sur différentes plates-formes, même s'ils ont des hiérarchies de GameObject différentes.
    - Cet outil avancé est utile uniquement si vos avatars PC et Quest ont des hiérarchies différentes !
    - Vous n'avez pas besoin de vous soucier de cet outil si vous ne savez pas pourquoi vous le feriez.
Consultez la documentation pour plus d'informations sur l'utilitaire Network ID. (doc:network-id-utility)

## Problèmes connus

- AsyncGpuReadback ne fonctionne pas sur Quest. Il renvoie un succès, mais avec des données illisibles.
  - Cela peut ne pas être résolu, car il devrait commencer à fonctionner correctement une fois que VRChat passera à Unity 2021 ou ultérieur.


