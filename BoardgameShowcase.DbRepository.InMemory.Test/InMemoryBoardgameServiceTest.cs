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

        private static void AssertExpectedCountAndBoardgameIds(IEnumerable<Boardgame> boardgames, int expectedCount, IEnumerable<string> boardgameIds)
        {
            Assert.Equal(expectedCount, boardgames.Count());
            foreach (string boardgameId in boardgameIds)
            {
                Assert.Contains(boardgames, b => b.Id == boardgameId);
            }
        }

        [Fact]
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
        [InlineData("04431d8e91c74283bd397b0b4e03b8d4", true, "Scythe : Conqu�rants du Lointain")]
        [InlineData("40d3e8d3fc264fa2861d4f47994d845b", false, null)]
        [InlineData("2b76f7e6e18746a9853a662236228de7", false, null)]
        public async Task GetByIdTest(string boardgameId, bool shouldFind, string expectedTitle)
        {
            Boardgame? boardgame = await _boardgameService.GetByIdAsync(boardgameId);
            Assert.Equal(shouldFind, boardgame is not null);
            Assert.Equal(expectedTitle, boardgame?.Title);
        }

        [Theory]
        [InlineData("azerty", 0)]
        [InlineData("te", 2, "9310639a9862457d8b8f5b7c45d1774c", "3c0f4169d3b147958b3be1eb1aece90d")]
        [InlineData("avent", 1, "427d038416be4f5e84be0782264649a6")]
        [InlineData("ing", 2, "3c0f4169d3b147958b3be1eb1aece90d", "dd137940ec5240d1a9233420e6647131")]
        public async Task GetByTitleTest(string titlePart, int expectedCount, params string[] boardgameIds)
        {
            IEnumerable<Boardgame> boardgames = await _boardgameService.GetByTitleAsync(titlePart);
            AssertExpectedCountAndBoardgameIds(boardgames, expectedCount, boardgameIds);
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
        [InlineData("31709d7cb6b743adb35c9546bef3fdee", 1, "9310639a9862457d8b8f5b7c45d1774c")]
        [InlineData("bdf144204fb3476aa9094f9ac5cd7112", 1, "3c0f4169d3b147958b3be1eb1aece90d")]
        [InlineData("5bf7883e49a14abebc81b38bcdcec866", 2, "e62ba15355724c54ba31639eee5755f3", "04431d8e91c74283bd397b0b4e03b8d4")]
        [InlineData("1e5e9bb7d5c84bc596f73488f9c6a19c", 1, "dd137940ec5240d1a9233420e6647131")]
        [InlineData("eb895b1f1a054b458471972587d51dc3", 1, "427d038416be4f5e84be0782264649a6")]
        [InlineData("294fb4abf5d94d93b21aebff08998b3d", 1, "77bece67ea984b0fb84c6dec36b3704b")]
        [InlineData("40d3e8d3fc264fa2861d4f47994d845b", 0)]
        [InlineData("2b76f7e6e18746a9853a662236228de7", 0)]
        [InlineData(null, 0)]
        public async Task GetByAuthorIdTest(string authorId, int expectedCount, params string[] boardgameIds)
        {
            IEnumerable<Boardgame> boardgames = await _boardgameService.GetByAuthorIdAsync(authorId);
            AssertExpectedCountAndBoardgameIds(boardgames, expectedCount, boardgameIds);
        }

        [Theory]
        [InlineData("a48e861f73294ede862408b7a71c3df9", 1, "9310639a9862457d8b8f5b7c45d1774c")]
        [InlineData("0c67dd6252e142a8b5b010cdfc3b6dd7", 1, "3c0f4169d3b147958b3be1eb1aece90d")]
        [InlineData("714242445ee64533a1eb5b18d71f061b", 2, "e62ba15355724c54ba31639eee5755f3", "04431d8e91c74283bd397b0b4e03b8d4")]
        [InlineData("b916ee6e523142438ab09ef8ff11780d", 1, "dd137940ec5240d1a9233420e6647131")]
        [InlineData("afca2c0c57664311af12ebf09daf70dd", 1, "427d038416be4f5e84be0782264649a6")]
        [InlineData("9d740aea7dbe442d9116fa2aad730222", 1, "77bece67ea984b0fb84c6dec36b3704b")]
        [InlineData("40d3e8d3fc264fa2861d4f47994d845b", 0)]
        [InlineData("2b76f7e6e18746a9853a662236228de7", 0)]
        [InlineData(null, 0)]
        public async Task GetByIllustratorIdTest(string illustratorId, int expectedCount, params string[] boardgameIds)
        {
            IEnumerable<Boardgame> boardgames = await _boardgameService.GetByIllustratorIdAsync(illustratorId);
            AssertExpectedCountAndBoardgameIds(boardgames, expectedCount, boardgameIds);
        }

        [Theory]
        [InlineData("650f72f3274849099d4265ccbeefc64f", 1, "9310639a9862457d8b8f5b7c45d1774c")]
        [InlineData("f80820ac1f0c4017a0c1fba2b3d263b5", 1, "3c0f4169d3b147958b3be1eb1aece90d")]
        [InlineData("ebaa178eabf642a59f31a5e27a5be566", 2, "e62ba15355724c54ba31639eee5755f3", "04431d8e91c74283bd397b0b4e03b8d4")]
        [InlineData("77dc41e600a241e1850fe71f2da9d0a6", 1, "dd137940ec5240d1a9233420e6647131")]
        [InlineData("3ceb6ddd724543c786a654e7c5a1d13e", 1, "427d038416be4f5e84be0782264649a6")]
        [InlineData("43ea31d0b8764517b78d686d66647d29", 1, "77bece67ea984b0fb84c6dec36b3704b")]
        [InlineData("40d3e8d3fc264fa2861d4f47994d845b", 0)]
        [InlineData("2b76f7e6e18746a9853a662236228de7", 0)]
        [InlineData(null, 0)]
        public async Task GetByPublisherIdTest(string publisherId, int expectedCount, params string[] boardgameIds)
        {
            IEnumerable<Boardgame> boardgames = await _boardgameService.GetByPublisherIdAsync(publisherId);
            AssertExpectedCountAndBoardgameIds(boardgames, expectedCount, boardgameIds);
        }

        [Theory]
        [InlineData(Theme.Antiquity, 1, "9310639a9862457d8b8f5b7c45d1774c")]
        [InlineData(Theme.Arts, 1, "77bece67ea984b0fb84c6dec36b3704b")]
        [InlineData(Theme.Constructions, 1, "77bece67ea984b0fb84c6dec36b3704b")]
        [InlineData(Theme.Economy, 2, "e62ba15355724c54ba31639eee5755f3", "04431d8e91c74283bd397b0b4e03b8d4")]
        [InlineData(Theme.Europe, 3, "e62ba15355724c54ba31639eee5755f3", "04431d8e91c74283bd397b0b4e03b8d4", "77bece67ea984b0fb84c6dec36b3704b")]
        [InlineData(Theme.Exploration, 2, "e62ba15355724c54ba31639eee5755f3", "04431d8e91c74283bd397b0b4e03b8d4")]
        [InlineData(Theme.Medieval, 1, "9310639a9862457d8b8f5b7c45d1774c")]
        [InlineData(Theme.ScienceFiction, 2, "3c0f4169d3b147958b3be1eb1aece90d", "dd137940ec5240d1a9233420e6647131")]
        [InlineData(Theme.Sciences, 1, "3c0f4169d3b147958b3be1eb1aece90d")]
        [InlineData(Theme.Trains, 1, "427d038416be4f5e84be0782264649a6")]
        [InlineData(Theme.USA, 1, "427d038416be4f5e84be0782264649a6")]
        public async Task GetByThemeTest(Theme theme, int expectedCount, params string[] boardgameIds)
        {
            IEnumerable<Boardgame> boardgames = await _boardgameService.GetByThemeAsync(theme);
            AssertExpectedCountAndBoardgameIds(boardgames, expectedCount, boardgameIds);
        }

        [Theory]
        [InlineData(Mechanism.Cards, 1, "dd137940ec5240d1a9233420e6647131")]
        [InlineData(Mechanism.Collection, 2, "427d038416be4f5e84be0782264649a6", "77bece67ea984b0fb84c6dec36b3704b")]
        [InlineData(Mechanism.Combination, 1, "3c0f4169d3b147958b3be1eb1aece90d")]
        [InlineData(Mechanism.Confrontation, 3, "e62ba15355724c54ba31639eee5755f3", "dd137940ec5240d1a9233420e6647131", "04431d8e91c74283bd397b0b4e03b8d4")]
        [InlineData(Mechanism.Dice, 1, "dd137940ec5240d1a9233420e6647131")]
        [InlineData(Mechanism.Draft, 1, "3c0f4169d3b147958b3be1eb1aece90d")]
        [InlineData(Mechanism.Exploration, 2, "e62ba15355724c54ba31639eee5755f3", "04431d8e91c74283bd397b0b4e03b8d4")]
        [InlineData(Mechanism.Management, 1, "9310639a9862457d8b8f5b7c45d1774c")]
        [InlineData(Mechanism.Placement, 1, "77bece67ea984b0fb84c6dec36b3704b")]
        [InlineData(Mechanism.Powers, 1, "3c0f4169d3b147958b3be1eb1aece90d")]
        [InlineData(Mechanism.Ressources, 1, "9310639a9862457d8b8f5b7c45d1774c")]
        [InlineData(Mechanism.SecretObjectives, 1, "427d038416be4f5e84be0782264649a6")]
        [InlineData(Mechanism.Tiles, 2, "3c0f4169d3b147958b3be1eb1aece90d", "77bece67ea984b0fb84c6dec36b3704b")]
        [InlineData(Mechanism.Wargame, 2, "e62ba15355724c54ba31639eee5755f3", "04431d8e91c74283bd397b0b4e03b8d4")]
        public async Task GetByMechanismTest(Mechanism mechanism, int expectedCount, params string[] boardgameIds)
        {
            IEnumerable<Boardgame> boardgames = await _boardgameService.GetByMechanismAsync(mechanism);
            AssertExpectedCountAndBoardgameIds(boardgames, expectedCount, boardgameIds);
        }

        [Theory]
        [InlineData(Category.Management, 3, "9310639a9862457d8b8f5b7c45d1774c", "3c0f4169d3b147958b3be1eb1aece90d", "77bece67ea984b0fb84c6dec36b3704b")]
        [InlineData(Category.Racing, 1, "427d038416be4f5e84be0782264649a6")]
        [InlineData(Category.Strategy, 3, "e62ba15355724c54ba31639eee5755f3", "dd137940ec5240d1a9233420e6647131", "04431d8e91c74283bd397b0b4e03b8d4")]
        public async Task GetByCategoryTest(Category category, int expectedCount, params string[] boardgameIds)
        {
            IEnumerable<Boardgame> boardgames = await _boardgameService.GetByCategoryAsync(category);
            AssertExpectedCountAndBoardgameIds(boardgames, expectedCount, boardgameIds);
        }
    }
}