using BoardgameShowcase.Model.Entity;
using Xunit;

namespace BoardgameShowcase.DbRepository.InMemory.Test.Extensions
{
    public static class AssertExtensions
    {
        public static void EntitiesMatch<T>(IEnumerable<string> entitieIds, IEnumerable<T> entities) where T : GenericEntity
        {
            Assert.Equal(entitieIds.Count(), entities.Count());
            foreach (string entityId in entitieIds)
            {
                Assert.Contains(entities, b => b.Id == entityId);
            }
        }
    }
}
