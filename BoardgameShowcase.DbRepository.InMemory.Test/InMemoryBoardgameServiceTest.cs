using BoardgameShowcase.DbRepository.InMemory.Test.Extensions;
using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Entity.Enumeration;
using BoardgameShowcase.Model.Service;
using Xunit;

namespace BoardgameShowcase.DbRepository.InMemory.Test
{
    public class InMemoryBoardgameServiceTest
    {
        private readonly IBoardgameService _boardgameService;

        public InMemoryBoardgameServiceTest(IBoardgameService boardgameService)
        {
            _boardgameService = boardgameService;
        }

        public async Task GetAllTest()
        {
            IEnumerable<Boardgame> boardgames = await _boardgameService.GetAllAsync();
            Assert.Equal(7, boardgames.Count());
        }

        [Theory]
        [InlineData("9310639a9862457d8b8f5b7c45d1774c", true, "7 Wonders : Architects")]
        [InlineData("3c0f4169d3b147958b3be1eb1aece90d", true, "Terraforming Mars")]
        [InlineData("e62ba15355724c54ba31639eee5755f3", true, "Scythe")]
        [InlineData("dd137940ec5240d1a9233420e6647131", true, "King of Tokyo")]
        [InlineData("427d038416be4f5e84be0782264649a6", true, "Les Aventuriers du Rail")]
        [InlineData("77bece67ea984b0fb84c6dec36b3704b", true, "Azul")]
        [InlineData("04431d8e91c74283bd397b0b4e03b8d4", true, "Scythe : Conquérants du Lointain")]
        [InlineData("40d3e8d3fc264fa2861d4f47994d845b", false, null)]
        [InlineData("2b76f7e6e18746a9853a662236228de7", false, null)]
        public async Task GetByIdTest(string boardgameId, bool shouldFind, string expectedTitle)
        {
            Boardgame? boardgame = await _boardgameService.GetByIdAsync(boardgameId);
            Assert.Equal(shouldFind, boardgame is not null);
            Assert.Equal(expectedTitle, boardgame?.Title);
        }

        [Theory]
        [InlineData("azerty")]
        [InlineData("te", "9310639a9862457d8b8f5b7c45d1774c", "3c0f4169d3b147958b3be1eb1aece90d")]
        [InlineData("avent", "427d038416be4f5e84be0782264649a6")]
        [InlineData("ing", "3c0f4169d3b147958b3be1eb1aece90d", "dd137940ec5240d1a9233420e6647131")]
        public async Task GetByTitleTest(string titlePart, params string[] boardgameIds)
        {
            IEnumerable<Boardgame> boardgames = await _boardgameService.GetByTitleAsync(titlePart);
            AssertExtensions.EntitiesMatch(boardgameIds, boardgames);
        }

        [Fact]
        public async Task AddModifiyAndRemoveTest()
        {
            Boardgame boardgame = new()
            {
                Title = "Blood Rage"
            };
            Boardgame? addedBoardgame = await _boardgameService.SaveAsync(boardgame);
            Assert.NotNull(addedBoardgame);
            IEnumerable<Boardgame> boardgamesAfterAdd = await _boardgameService.GetAllAsync();
            Assert.Equal(8, boardgamesAfterAdd.Count());
            if (addedBoardgame is not null)
            {
                addedBoardgame.Title = "Root";
                Boardgame? modifiedBoardgame = await _boardgameService.SaveAsync(addedBoardgame);
                Assert.NotNull(modifiedBoardgame);
                IEnumerable<Boardgame> boardgamesAfterUpdate = await _boardgameService.GetAllAsync();
                Assert.Equal(8, boardgamesAfterUpdate.Count());
                if (modifiedBoardgame is not null)
                {
                    Assert.Equal(addedBoardgame, modifiedBoardgame);
                    Assert.Equal(addedBoardgame.Title, modifiedBoardgame.Title);
                    Boardgame? removedBoardgame = await _boardgameService.RemoveAsync(modifiedBoardgame);
                    Assert.NotNull(removedBoardgame);
                    Assert.Equal(modifiedBoardgame, removedBoardgame);
                    IEnumerable<Boardgame> boardgamesAfterRemove = await _boardgameService.GetAllAsync();
                    Assert.Equal(7, boardgamesAfterRemove.Count());
                }
            }
        }

        [Theory]
        [InlineData("31709d7cb6b743adb35c9546bef3fdee", "9310639a9862457d8b8f5b7c45d1774c")]
        [InlineData("bdf144204fb3476aa9094f9ac5cd7112", "3c0f4169d3b147958b3be1eb1aece90d")]
        [InlineData("5bf7883e49a14abebc81b38bcdcec866", "e62ba15355724c54ba31639eee5755f3", "04431d8e91c74283bd397b0b4e03b8d4")]
        [InlineData("1e5e9bb7d5c84bc596f73488f9c6a19c", "dd137940ec5240d1a9233420e6647131")]
        [InlineData("eb895b1f1a054b458471972587d51dc3", "427d038416be4f5e84be0782264649a6")]
        [InlineData("294fb4abf5d94d93b21aebff08998b3d", "77bece67ea984b0fb84c6dec36b3704b")]
        [InlineData("40d3e8d3fc264fa2861d4f47994d845b")]
        [InlineData("2b76f7e6e18746a9853a662236228de7")]
        [InlineData(null)]
        public async Task GetByAuthorIdTest(string authorId, params string[] boardgameIds)
        {
            IEnumerable<Boardgame> boardgames = await _boardgameService.GetByAuthorIdAsync(authorId);
            AssertExtensions.EntitiesMatch(boardgameIds, boardgames);
        }

        [Theory]
        [InlineData("a48e861f73294ede862408b7a71c3df9", "9310639a9862457d8b8f5b7c45d1774c")]
        [InlineData("0c67dd6252e142a8b5b010cdfc3b6dd7", "3c0f4169d3b147958b3be1eb1aece90d")]
        [InlineData("714242445ee64533a1eb5b18d71f061b", "e62ba15355724c54ba31639eee5755f3", "04431d8e91c74283bd397b0b4e03b8d4")]
        [InlineData("b916ee6e523142438ab09ef8ff11780d", "dd137940ec5240d1a9233420e6647131")]
        [InlineData("afca2c0c57664311af12ebf09daf70dd", "427d038416be4f5e84be0782264649a6")]
        [InlineData("9d740aea7dbe442d9116fa2aad730222", "77bece67ea984b0fb84c6dec36b3704b")]
        [InlineData("40d3e8d3fc264fa2861d4f47994d845b")]
        [InlineData("2b76f7e6e18746a9853a662236228de7")]
        [InlineData(null)]
        public async Task GetByIllustratorIdTest(string illustratorId, params string[] boardgameIds)
        {
            IEnumerable<Boardgame> boardgames = await _boardgameService.GetByIllustratorIdAsync(illustratorId);
            AssertExtensions.EntitiesMatch(boardgameIds, boardgames);
        }

        [Theory]
        [InlineData("650f72f3274849099d4265ccbeefc64f", "9310639a9862457d8b8f5b7c45d1774c")]
        [InlineData("f80820ac1f0c4017a0c1fba2b3d263b5", "3c0f4169d3b147958b3be1eb1aece90d")]
        [InlineData("ebaa178eabf642a59f31a5e27a5be566", "e62ba15355724c54ba31639eee5755f3", "04431d8e91c74283bd397b0b4e03b8d4")]
        [InlineData("77dc41e600a241e1850fe71f2da9d0a6", "dd137940ec5240d1a9233420e6647131")]
        [InlineData("3ceb6ddd724543c786a654e7c5a1d13e", "427d038416be4f5e84be0782264649a6")]
        [InlineData("43ea31d0b8764517b78d686d66647d29", "77bece67ea984b0fb84c6dec36b3704b")]
        [InlineData("40d3e8d3fc264fa2861d4f47994d845b")]
        [InlineData("2b76f7e6e18746a9853a662236228de7")]
        [InlineData(null)]
        public async Task GetByPublisherIdTest(string publisherId, params string[] boardgameIds)
        {
            IEnumerable<Boardgame> boardgames = await _boardgameService.GetByPublisherIdAsync(publisherId);
            AssertExtensions.EntitiesMatch(boardgameIds, boardgames);
        }

        [Theory]
        [InlineData(Theme.Antiquity, "9310639a9862457d8b8f5b7c45d1774c")]
        [InlineData(Theme.Arts, "77bece67ea984b0fb84c6dec36b3704b")]
        [InlineData(Theme.Constructions, "77bece67ea984b0fb84c6dec36b3704b")]
        [InlineData(Theme.Economy, "e62ba15355724c54ba31639eee5755f3", "04431d8e91c74283bd397b0b4e03b8d4")]
        [InlineData(Theme.Europe, "e62ba15355724c54ba31639eee5755f3", "04431d8e91c74283bd397b0b4e03b8d4", "77bece67ea984b0fb84c6dec36b3704b")]
        [InlineData(Theme.Exploration, "e62ba15355724c54ba31639eee5755f3", "04431d8e91c74283bd397b0b4e03b8d4")]
        [InlineData(Theme.Medieval, "9310639a9862457d8b8f5b7c45d1774c")]
        [InlineData(Theme.ScienceFiction, "3c0f4169d3b147958b3be1eb1aece90d", "dd137940ec5240d1a9233420e6647131")]
        [InlineData(Theme.Sciences, "3c0f4169d3b147958b3be1eb1aece90d")]
        [InlineData(Theme.Trains, "427d038416be4f5e84be0782264649a6")]
        [InlineData(Theme.USA, "427d038416be4f5e84be0782264649a6")]
        public async Task GetByThemeTest(Theme theme, params string[] boardgameIds)
        {
            IEnumerable<Boardgame> boardgames = await _boardgameService.GetByThemeAsync(theme);
            AssertExtensions.EntitiesMatch(boardgameIds, boardgames);
        }

        [Theory]
        [InlineData(Mechanism.Cards, "dd137940ec5240d1a9233420e6647131")]
        [InlineData(Mechanism.Collection, "427d038416be4f5e84be0782264649a6", "77bece67ea984b0fb84c6dec36b3704b")]
        [InlineData(Mechanism.Combination, "3c0f4169d3b147958b3be1eb1aece90d")]
        [InlineData(Mechanism.Confrontation, "e62ba15355724c54ba31639eee5755f3", "dd137940ec5240d1a9233420e6647131", "04431d8e91c74283bd397b0b4e03b8d4")]
        [InlineData(Mechanism.Dice, "dd137940ec5240d1a9233420e6647131")]
        [InlineData(Mechanism.Draft, "3c0f4169d3b147958b3be1eb1aece90d")]
        [InlineData(Mechanism.Exploration, "e62ba15355724c54ba31639eee5755f3", "04431d8e91c74283bd397b0b4e03b8d4")]
        [InlineData(Mechanism.Management, "9310639a9862457d8b8f5b7c45d1774c")]
        [InlineData(Mechanism.Placement, "77bece67ea984b0fb84c6dec36b3704b")]
        [InlineData(Mechanism.Powers, "3c0f4169d3b147958b3be1eb1aece90d")]
        [InlineData(Mechanism.Ressources, "9310639a9862457d8b8f5b7c45d1774c")]
        [InlineData(Mechanism.SecretObjectives, "427d038416be4f5e84be0782264649a6")]
        [InlineData(Mechanism.Tiles, "3c0f4169d3b147958b3be1eb1aece90d", "77bece67ea984b0fb84c6dec36b3704b")]
        [InlineData(Mechanism.Wargame, "e62ba15355724c54ba31639eee5755f3", "04431d8e91c74283bd397b0b4e03b8d4")]
        public async Task GetByMechanismTest(Mechanism mechanism, params string[] boardgameIds)
        {
            IEnumerable<Boardgame> boardgames = await _boardgameService.GetByMechanismAsync(mechanism);
            AssertExtensions.EntitiesMatch(boardgameIds, boardgames);
        }

        [Theory]
        [InlineData(Category.Management, "9310639a9862457d8b8f5b7c45d1774c", "3c0f4169d3b147958b3be1eb1aece90d", "77bece67ea984b0fb84c6dec36b3704b")]
        [InlineData(Category.Racing, "427d038416be4f5e84be0782264649a6")]
        [InlineData(Category.Strategy, "e62ba15355724c54ba31639eee5755f3", "dd137940ec5240d1a9233420e6647131", "04431d8e91c74283bd397b0b4e03b8d4")]
        public async Task GetByCategoryTest(Category category, params string[] boardgameIds)
        {
            IEnumerable<Boardgame> boardgames = await _boardgameService.GetByCategoryAsync(category);
            AssertExtensions.EntitiesMatch(boardgameIds, boardgames);
        }
    }
}