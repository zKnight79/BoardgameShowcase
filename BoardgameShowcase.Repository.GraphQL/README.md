# BoardgameShowcase.Repository.GraphQL

#### _A library containing an implementation of the repositories, using GraphQL client._

This library contains an implementation of  of the repositories,
using a GraphQL client for the [BoardgameShowcase.GraphQL.Server](BoardgameShowcase.GraphQL.Server/README.md).

The endpoint of the GraphQL Server should be configured in
the `appsettings.json` configuration file,
in the `GraphQL.Endpoint` path, like this :

```json
"GraphQL": {
  "Endpoint": "https://localhost:5001/graphql"
}
```

This implementation can be used in another project,
using dependency injection,
by calling the extension method :

```csharp
services.AddBoardgameShowcaseRepositoryGraphQL()
```