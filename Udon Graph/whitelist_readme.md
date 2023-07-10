## Guide pour utiliser le script `whitelist_toggle`

Le script `whitelist_toggle` permet de désactiver un GameObject spécifique pour tous les utilisateurs qui ne figurent pas dans une liste blanche prédéfinie.

### Étapes à suivre :

1. **Installer UdonSharp**

   Assurez-vous que vous avez installé UdonSharp dans votre projet Unity. Il est nécessaire pour compiler ce script. Vous pouvez l'obtenir à partir du [Asset Store de Unity](https://assetstore.unity.com/).

2. **Télécharger le script**

   Téléchargez le fichier depuis la repo

3. **Importer le script dans votre projet Unity**

   Ouvrez Unity et allez dans `Assets` -> `Import Package` -> `Custom Package` et sélectionnez le fichier zip que vous venez de télécharger. Cela ajoutera le script à votre projet.

4. **Attacher le script à un GameObject**

   Sélectionnez le GameObject que vous souhaitez contrôler avec ce script dans la hiérarchie Unity. Dans l'inspecteur, cliquez sur "Add Component" et ajoutez le script `whitelist_toggle` que vous venez d'importer.

5. **Configurer le script**

   Vous devrez maintenant configurer le script. Dans l'inspecteur Unity, vous devriez voir les options pour `objectToDisable` et `whitelist`.

   - Pour `objectToDisable`, cliquez sur le cercle à côté du champ et sélectionnez le GameObject que vous souhaitez désactiver pour les utilisateurs qui ne sont pas dans la liste blanche.
   
   - Pour `whitelist`, définissez la taille du tableau à la quantité d'utilisateurs que vous voulez inclure dans la liste blanche, puis remplissez les champs avec les noms des utilisateurs.

6. **Tester le script**

   Exécutez votre scène pour voir le script en action. Le GameObject désigné devrait être désactivé pour tous les utilisateurs qui ne figurent pas dans votre liste blanche.

Et voilà ! Vous avez maintenant un script fonctionnel qui permet de contrôler l'accessibilité d'un GameObject spécifique en fonction d'une liste blanche d'utilisateurs.
