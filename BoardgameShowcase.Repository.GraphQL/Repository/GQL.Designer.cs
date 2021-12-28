﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BoardgameShowcase.Repository.GraphQL.Repository {
    using System;
    
    
    /// <summary>
    ///   Une classe de ressource fortement typée destinée, entre autres, à la consultation des chaînes localisées.
    /// </summary>
    // Cette classe a été générée automatiquement par la classe StronglyTypedResourceBuilder
    // à l'aide d'un outil, tel que ResGen ou Visual Studio.
    // Pour ajouter ou supprimer un membre, modifiez votre fichier .ResX, puis réexécutez ResGen
    // avec l'option /str ou régénérez votre projet VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class GQL {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal GQL() {
        }
        
        /// <summary>
        ///   Retourne l'instance ResourceManager mise en cache utilisée par cette classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BoardgameShowcase.Repository.GraphQL.Repository.GQL", typeof(GQL).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Remplace la propriété CurrentUICulture du thread actuel pour toutes
        ///   les recherches de ressources à l'aide de cette classe de ressource fortement typée.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à query GetAuthorById($authorId: String!) {
        ///  author(id: $authorId) {
        ///	id
        ///	name
        ///  }
        ///}.
        /// </summary>
        internal static string Author {
            get {
                return ResourceManager.GetString("Author", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à mutation CreateAuthor($name: String!) {
        ///  author: saveAuthor(inputAuthor: {
        ///    name: $name
        ///  }) {
        ///	id
        ///	name
        ///  }
        ///}.
        /// </summary>
        internal static string AuthorCreate {
            get {
                return ResourceManager.GetString("AuthorCreate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à mutation DeleteAuthor($authorId: String!) {
        ///  author: removeAuthor(authorId: $authorId) {
        ///	id
        ///	name
        ///  }
        ///}.
        /// </summary>
        internal static string AuthorDelete {
            get {
                return ResourceManager.GetString("AuthorDelete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à query GetAllAuthors {
        ///  authors {
        ///	id
        ///	name
        ///  }
        ///}.
        /// </summary>
        internal static string Authors {
            get {
                return ResourceManager.GetString("Authors", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à query AuthorsLike($namePart: String!) {
        ///  authors: authorsByName(namePart: $namePart) {
        ///	id
        ///	name
        ///  }
        ///}.
        /// </summary>
        internal static string AuthorsByName {
            get {
                return ResourceManager.GetString("AuthorsByName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à mutation UpdateAuthor($id: String!, $name: String!) {
        ///  author: saveAuthor(inputAuthor: {
        ///    id: $id
        ///    name: $name
        ///  }) {
        ///	id
        ///	name
        ///  }
        ///}.
        /// </summary>
        internal static string AuthorUpdate {
            get {
                return ResourceManager.GetString("AuthorUpdate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à query GetBoardgameById($boardgameId: String!) {
        ///  boardgame(id: $boardgameId) {
        ///	id
        ///    title
        ///    authorId
        ///    illustratorId
        ///    publisherId
        ///    minimumPlayerCount
        ///    maximumPlayerCount
        ///    minimumPlayerAge
        ///    approximateGameTimeInMinutes
        ///    category
        ///    themes
        ///    mechanisms
        ///  }
        ///}.
        /// </summary>
        internal static string Boardgame {
            get {
                return ResourceManager.GetString("Boardgame", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à mutation CreateBoardgame(
        ///  $title: String!
        ///  $authorId: String!
        ///  $illustratorId: String!
        ///  $publisherId: String!
        ///  $minimumPlayerCount: Int!
        ///  $maximumPlayerCount: Int!
        ///  $minimumPlayerAge: Int!
        ///  $approximateGameTimeInMinutes: Int!
        ///  $category: Category!
        ///  $themes: [Theme!]!
        ///  $mechanisms: [Mechanism!]!
        ///) {
        ///  boardgame: saveBoardgame(inputBoardgame: {
        ///    title: $title
        ///    authorId: $authorId
        ///    illustratorId: $illustratorId
        ///    publisherId: $publisherId
        ///    minimumPlayerCount: $minimu [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        internal static string BoardgameCreate {
            get {
                return ResourceManager.GetString("BoardgameCreate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à mutation DeleteBoardgame($boardgameId: String!) {
        ///  boardgame: removeBoardgame(boardgameId: $boardgameId) {
        ///	id
        ///    title
        ///    authorId
        ///    illustratorId
        ///    publisherId
        ///    minimumPlayerCount
        ///    maximumPlayerCount
        ///    minimumPlayerAge
        ///    approximateGameTimeInMinutes
        ///    category
        ///    themes
        ///    mechanisms
        ///  }
        ///}.
        /// </summary>
        internal static string BoardgameDelete {
            get {
                return ResourceManager.GetString("BoardgameDelete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à query GetAllBoargames {
        ///  boargames {
        ///	id
        ///    title
        ///    authorId
        ///    illustratorId
        ///    publisherId
        ///    minimumPlayerCount
        ///    maximumPlayerCount
        ///    minimumPlayerAge
        ///    approximateGameTimeInMinutes
        ///    category
        ///    themes
        ///    mechanisms
        ///  }
        ///}.
        /// </summary>
        internal static string Boardgames {
            get {
                return ResourceManager.GetString("Boardgames", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à query BoardgamesByAuthor($authorId: String!) {
        ///  boardgames: boardgamesByAuthorId(authorId: $authorId) {
        ///	id
        ///    title
        ///    authorId
        ///    illustratorId
        ///    publisherId
        ///    minimumPlayerCount
        ///    maximumPlayerCount
        ///    minimumPlayerAge
        ///    approximateGameTimeInMinutes
        ///    category
        ///    themes
        ///    mechanisms
        ///  }
        ///}.
        /// </summary>
        internal static string BoardgamesByAuthor {
            get {
                return ResourceManager.GetString("BoardgamesByAuthor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à query BoardgamesByCategory($category: Category!) {
        ///  boardgames: boardgamesByCategory(category: $category) {
        ///	id
        ///    title
        ///    authorId
        ///    illustratorId
        ///    publisherId
        ///    minimumPlayerCount
        ///    maximumPlayerCount
        ///    minimumPlayerAge
        ///    approximateGameTimeInMinutes
        ///    category
        ///    themes
        ///    mechanisms
        ///  }
        ///}.
        /// </summary>
        internal static string BoardgamesByCategory {
            get {
                return ResourceManager.GetString("BoardgamesByCategory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à query BoardgamesByIllustrator($illustratorId: String!) {
        ///  boardgames: boardgamesByIllustratorId(illustratorId: $illustratorId) {
        ///	id
        ///    title
        ///    authorId
        ///    illustratorId
        ///    publisherId
        ///    minimumPlayerCount
        ///    maximumPlayerCount
        ///    minimumPlayerAge
        ///    approximateGameTimeInMinutes
        ///    category
        ///    themes
        ///    mechanisms
        ///  }
        ///}.
        /// </summary>
        internal static string BoardgamesByIllustrator {
            get {
                return ResourceManager.GetString("BoardgamesByIllustrator", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à query BoardgamesByMechanism($mechanism: Mechanism!) {
        ///  boardgames: boardgamesByMechanism(mechanism: $mechanism) {
        ///	id
        ///    title
        ///    authorId
        ///    illustratorId
        ///    publisherId
        ///    minimumPlayerCount
        ///    maximumPlayerCount
        ///    minimumPlayerAge
        ///    approximateGameTimeInMinutes
        ///    category
        ///    themes
        ///    mechanisms
        ///  }
        ///}.
        /// </summary>
        internal static string BoardgamesByMechanism {
            get {
                return ResourceManager.GetString("BoardgamesByMechanism", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à query BoardgamesByPublisher($publisherId: String!) {
        ///  boardgames: boardgamesByPublisherId(publisherId: $publisherId) {
        ///	id
        ///    title
        ///    authorId
        ///    illustratorId
        ///    publisherId
        ///    minimumPlayerCount
        ///    maximumPlayerCount
        ///    minimumPlayerAge
        ///    approximateGameTimeInMinutes
        ///    category
        ///    themes
        ///    mechanisms
        ///  }
        ///}.
        /// </summary>
        internal static string BoardgamesByPublisher {
            get {
                return ResourceManager.GetString("BoardgamesByPublisher", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à query BoardgamesByTheme($theme: Theme!) {
        ///  boardgames: boardgamesByTheme(theme: $theme) {
        ///	id
        ///    title
        ///    authorId
        ///    illustratorId
        ///    publisherId
        ///    minimumPlayerCount
        ///    maximumPlayerCount
        ///    minimumPlayerAge
        ///    approximateGameTimeInMinutes
        ///    category
        ///    themes
        ///    mechanisms
        ///  }
        ///}.
        /// </summary>
        internal static string BoardgamesByTheme {
            get {
                return ResourceManager.GetString("BoardgamesByTheme", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à query BoardgamesLike($titlePart: String!) {
        ///  boardgames: boardgamesByTitle(namePart: $titlePart) {
        ///	id
        ///    title
        ///    authorId
        ///    illustratorId
        ///    publisherId
        ///    minimumPlayerCount
        ///    maximumPlayerCount
        ///    minimumPlayerAge
        ///    approximateGameTimeInMinutes
        ///    category
        ///    themes
        ///    mechanisms
        ///  }
        ///}.
        /// </summary>
        internal static string BoardgamesByTitle {
            get {
                return ResourceManager.GetString("BoardgamesByTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à mutation UpdateBoardgame(
        ///  $id: String!
        ///  $title: String!
        ///  $authorId: String!
        ///  $illustratorId: String!
        ///  $publisherId: String!
        ///  $minimumPlayerCount: Int!
        ///  $maximumPlayerCount: Int!
        ///  $minimumPlayerAge: Int!
        ///  $approximateGameTimeInMinutes: Int!
        ///  $category: Category!
        ///  $themes: [Theme!]!
        ///  $mechanisms: [Mechanism!]!
        ///) {
        ///  boardgame: saveBoardgame(inputBoardgame: {
        ///    id: $id
        ///    title: $title
        ///    authorId: $authorId
        ///    illustratorId: $illustratorId
        ///    publisherId: $publisherId
        ///   [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        internal static string BoardgameUpdate {
            get {
                return ResourceManager.GetString("BoardgameUpdate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à query GetIllustratorById($illustratorId: String!) {
        ///  illustrator(id: $illustratorId) {
        ///	id
        ///	name
        ///  }
        ///}.
        /// </summary>
        internal static string Illustrator {
            get {
                return ResourceManager.GetString("Illustrator", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à mutation CreateIllustrator($name: String!) {
        ///  illustrator: saveIllustrator(inputIllustrator: {
        ///    name: $name
        ///  }) {
        ///	id
        ///	name
        ///  }
        ///}.
        /// </summary>
        internal static string IllustratorCreate {
            get {
                return ResourceManager.GetString("IllustratorCreate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à mutation DeleteIllustrator($illustratorId: String!) {
        ///  illustrator: removeIllustrator(illustratorId: $illustratorId) {
        ///	id
        ///	name
        ///  }
        ///}.
        /// </summary>
        internal static string IllustratorDelete {
            get {
                return ResourceManager.GetString("IllustratorDelete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à query GetAllIllustrators {
        ///  illustrators {
        ///	id
        ///	name
        ///  }
        ///}.
        /// </summary>
        internal static string Illustrators {
            get {
                return ResourceManager.GetString("Illustrators", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à query IllustratorsLike($namePart: String!) {
        ///  illustrators: illustratorsByName(namePart: $namePart) {
        ///	id
        ///	name
        ///  }
        ///}.
        /// </summary>
        internal static string IllustratorsByName {
            get {
                return ResourceManager.GetString("IllustratorsByName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à mutation UpdateIllustrator($id: String!, $name: String!) {
        ///  illustrator: saveIllustrator(inputIllustrator: {
        ///    id: $id
        ///    name: $name
        ///  }) {
        ///	id
        ///	name
        ///  }
        ///}.
        /// </summary>
        internal static string IllustratorUpdate {
            get {
                return ResourceManager.GetString("IllustratorUpdate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à query GetPublisherById($publisherId: String!) {
        ///  publisher(id: $publisherId) {
        ///	id
        ///	name
        ///  }
        ///}.
        /// </summary>
        internal static string Publisher {
            get {
                return ResourceManager.GetString("Publisher", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à mutation CreatePublisher($name: String!) {
        ///  publisher: savePublisher(inputPublisher: {
        ///    name: $name
        ///  }) {
        ///	id
        ///	name
        ///  }
        ///}.
        /// </summary>
        internal static string PublisherCreate {
            get {
                return ResourceManager.GetString("PublisherCreate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à mutation DeletePublisher($publisherId: String!) {
        ///  publisher: removePublisher(publisherId: $publisherId) {
        ///	id
        ///	name
        ///  }
        ///}.
        /// </summary>
        internal static string PublisherDelete {
            get {
                return ResourceManager.GetString("PublisherDelete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à query GetAllPublishers {
        ///  publishers {
        ///	id
        ///	name
        ///  }
        ///}.
        /// </summary>
        internal static string Publishers {
            get {
                return ResourceManager.GetString("Publishers", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à query PublishersLike($namePart: String!) {
        ///  publishers: publishersByName(namePart: $namePart) {
        ///	id
        ///	name
        ///  }
        ///}.
        /// </summary>
        internal static string PublishersByName {
            get {
                return ResourceManager.GetString("PublishersByName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à mutation UpdatePublisher($id: String!, $name: String!) {
        ///  publisher: savePublisher(inputPublisher: {
        ///    id: $id
        ///    name: $name
        ///  }) {
        ///	id
        ///	name
        ///  }
        ///}.
        /// </summary>
        internal static string PublisherUpdate {
            get {
                return ResourceManager.GetString("PublisherUpdate", resourceCulture);
            }
        }
    }
}