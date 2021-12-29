# BoardgameShowcase.Repository

#### _A library containing a repository-based implementation of the model services._

This library contains a repository-based implementation of the model services,
as well as the repositories interfaces.

This implementation can be used in another project,
that should provide an implementation for the repositories,
using dependency injection,
by calling the extension method :

```csharp
services.AddBoardgameShowcaseRepository()
```