# Boardgame Showcase

This is a showcase solution about setting up
a versatile .Net ecosystem including :
+ a GraphQL server
+ a GraphQL client library
+ a web portal (Blazor Server) that can be based
  on direct access to the database
  (the access used by the GraphQL server),
  or on access via the GraphQL client.
+ a fat client application that can be based
  on direct access to the database
  (the access used by the GraphQL server),
  or on access via the GraphQL client.

The solution contains the following projects :
+ [BoardgameShowcase.Common](BoardgameShowcase.Common/README.md), a library containing general purpose functions.
+ [BoardgameShowcase.Model](BoardgameShowcase.Model/README.md), a library containing the application data model,
  as well as the related service interfaces.
+ [BoardgameShowcase.Repository](BoardgameShowcase.Repository/README.md), a repository implementation
  of the data model services, exposing repository interfaces.
+ BoardgameShowcase.Repository.InMemory, an implementation of the repositories,
  based on in memory data (for development and test purpose).
+ BoardgameShowcase.Repository.MongoDB, an implementation of the repositories,
  based on a MongoDB database.
  _coming soon ..._
+ BoardgameShowcase.Repository.GraphQL, an implementation of the repositories,
  based on a GraphQL client.
+ BoardgameShowcase.GraphQL.Server, the GraphQL Server,
  that can use the InMemory or the MongoDB repository.
+ BoardgameShowcase.Portal, a Blazor Server web portal,
  that can use the InMemory, the MongoDB or the GraphQL repository.
  _coming soon ..._
+ BoardgameShowcase.Repository.InMemory.Test, a unit test project
  that ensures the proper functioning of the InMemory repository.
+ BoardgameShowcase.Repository.GraphQL.Worker, a console project
  that ensures the proper functioning of the GraphQL repository.
+ BoardgameShowcase.Repository.GraphQL.Subscriber, a console project
  that ensures the proper functioning of the GraphQL client for subscriptions.
