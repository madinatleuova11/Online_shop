using IShop.Interfaces;
using IShop.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IShop.UserServiceTests
{
    public class CardUnitTesting
    {
        List<DiscountCard> cards = new List<DiscountCard>
        {
            new DiscountCard() { type = "test user 1" },
            new DiscountCard() { type = "test user 2" },
        };

        [Fact]
        public async Task AddTest()
        {
            var fakeRepository = Mock.Of<IDiscountCardRepository>();
            var cardService = new Services.DiscountCardService(fakeRepository);

            var card = new DiscountCard() { type = "test user 1" };
            await cardService.AddAndSave(card);
        }

        [Fact]
        public async Task GetCardsTest()
        {
            var cards = new List<DiscountCard>
            {
                new DiscountCard() { type = "test user 1" },
                new DiscountCard() { type = "test user 2" },
            };

            var fakeRepositoryMock = new Mock<IDiscountCardRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(cards);


            var cardService = new Services.DiscountCardService(fakeRepositoryMock.Object);

            var resultUsers = await cardService.GetDiscountCards();

            Assert.Collection(resultUsers, card =>
            {
                Assert.Equal("test user 1", card.type);
            },
            card =>
            {
                Assert.Equal("test user 2", card.type);
            });
        }

        [Fact]
        public async Task DeleteEntityTest()
        {
            var fakeRepositoryMock = new Mock<IDiscountCardRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(cards);


            var cardService = new Services.DiscountCardService(fakeRepositoryMock.Object);

            await cardService.DeleteCard(2);
        }
    }
}
