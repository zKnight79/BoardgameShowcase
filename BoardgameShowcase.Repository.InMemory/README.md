# BoardgameShowcase.Repository.InMemory

#### _A library containing an implementation of the repositories, for InMemory data._

This library contains an implementation of  of the repositories,
for InMemory data.

It's main purpose is for testing and speedup development.

This implementation can be used in another project,
using dependency injection,
by calling the extension method :
```csharp
services.AddBoardgameShowcaseRepositoryInMemory()
```