using Moq;
using NUnit.Framework;
using Services.External.Implementations;
using Services.Internal.Models;

namespace UnitTests.Services.External.Implementations.TranslationFactory
{
    /// <summary>
    /// Tests for the TranslationFactory CreateService method
    /// </summary>
    [TestFixture]
    public class CreateServiceTests
    {
        #region Private Fields

        private global::Services.External.Interfaces.ITranslationFactory _translationFactory;

        #endregion Private Fields

        #region SetUp

        [SetUp]
        public void CreateDependencies()
        {
            _translationFactory = new global::Services.External.Implementations.TranslationFactory();
        }

        #endregion SetUp

        #region Tests

        /// <summary>
        /// When the species habitat is "cave"
        /// </summary>
        [Test]
        public void WhenHabitatIsCave()
        {
            // Arrange
            var species = new Species
            {
                Habitat = "cave"
            };

            // Act
            var translationService = _translationFactory.CreateService(species);

            // Assert
            Assert.IsInstanceOf<YodaTranslationService>(translationService);
        }

        /// <summary>
        /// When the species is legendary
        /// </summary>
        [Test]
        public void WhenIsLegendaryTrue()
        {
            // Arrange
            var species = new Species
            {
                IsLegendary = true
            };

            // Act
            var translationService = _translationFactory.CreateService(species);

            // Assert
            Assert.IsInstanceOf<YodaTranslationService>(translationService);
        }

        /// <summary>
        /// When the Shakespeare service is returned as default
        /// </summary>
        [Test]
        public void WhenDefaultToShakespeare()
        {
            // Arrange
            var species = new Species();

            // Act
            var translationService = _translationFactory.CreateService(species);

            // Assert
            Assert.IsInstanceOf<ShakespeareTranslationService>(translationService);
        }

        #endregion Tests
    }
}
