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
    }
}
