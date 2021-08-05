using System.Threading.Tasks;
using API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Services.Internal.Interfaces;
using Services.Internal.Models;

namespace UnitTests.API.Controllers.Pokemon
{
    /// <summary>
    /// Tests for the PokemonController Get action
    /// </summary>
    [TestFixture]
    public class GetTests
    {
        #region Private Fields

        private Mock<ISpeciesService> _speciesService;
        private PokemonController _controller;

        #endregion Private Fields

        #region SetUp

        [SetUp]
        public void CreateDependencies()
        {
            _speciesService = new Mock<ISpeciesService>();
            _controller = new PokemonController(_speciesService.Object);
        }

        #endregion SetUp

        #region Tests

        /// <summary>
        /// When the species service returns null
        /// </summary>
        /// <remarks>
        /// If the logic to return 404 Not Found is changed, ensure it is changed for all endpoints
        /// </remarks>
        [Test]
        public async Task WhenServiceReturnsNull()
        {
            // Arrange
            Species species = null;

            _speciesService.Setup(e => e.Get(It.IsAny<string>(), false))
                .Returns(Task.FromResult(species));

            // Act
            var response = await _controller.Get("mewtwo");

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(response);
        }

        /// <summary>
        /// When the species service returns an object
        /// </summary>
        [Test]
        public async Task WhenServiceReturnsSpecies()
        {
            // Arrange
            var species = new Species
            {
                Description = "mewtwo description"
            };

            _speciesService.Setup(e => e.Get(It.IsAny<string>(), false))
                .Returns(Task.FromResult(species));

            // Act
            var response = await _controller.Get("mewtwo") as OkObjectResult;
            var responseValue = response.Value as Species;

            // Assert
            Assert.AreEqual("mewtwo description", responseValue.Description);
        }

        #endregion Tests
    }
}
