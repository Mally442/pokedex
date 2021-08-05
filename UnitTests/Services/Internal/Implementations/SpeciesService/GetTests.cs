using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Services.External.Interfaces;
using Services.External.Models;

namespace UnitTests.Services.Internal.Implementations.SpeciesService
{
    /// <summary>
    /// Tests for the SpeciesService Get method
    /// </summary>
    [TestFixture]
    public class GetTests
    {
        #region Private Fields

        private Mock<IPokemonService> _pokemonService;
        private Mock<ITranslationFactory> _translationFactory;
        private Mock<ITranslationService> _translationService;
        private global::Services.Internal.Interfaces.ISpeciesService _speciesService;

        #endregion Private Fields

        #region SetUp

        [SetUp]
        public void CreateDependencies()
        {
            _pokemonService = new Mock<IPokemonService>();
            _translationFactory = new Mock<ITranslationFactory>();
            _translationService = new Mock<ITranslationService>();
            _speciesService = new global::Services.Internal.Implementations.SpeciesService(_pokemonService.Object, _translationFactory.Object);
        }

        #endregion SetUp

        #region Tests

        /// <summary>
        /// When the Pokemon service returns null
        /// </summary>
        [Test]
        public async Task WhenPokemonServiceReturnsNull()
        {
            // Arrange
            string text = "";
            Species speciesExternal = null;

            _translationService.Setup(e => e.Get(It.IsAny<string>()))
                .Returns(Task.FromResult(text));
            _translationFactory.Setup(e => e.CreateService(It.IsAny<global::Services.Internal.Models.Species>()))
                .Returns(_translationService.Object);
            _pokemonService.Setup(e => e.Get(It.IsAny<string>()))
                .Returns(Task.FromResult(speciesExternal));

            // Act
            var speciesInternal = await _speciesService.Get("mewtwo");

            // Assert
            
            Assert.IsNull(speciesInternal);
            _pokemonService.Verify(e => e.Get(It.IsAny<string>()), Times.Once);
            _translationFactory.Verify(e => e.CreateService(It.IsAny<global::Services.Internal.Models.Species>()), Times.Never);
            _translationService.Verify(e => e.Get(It.IsAny<string>()), Times.Never);
        }

        /// <summary>
        /// When the Pokemon service returns an object that does not have any English descriptions
        /// </summary>
        [Test]
        public async Task WhenPokemonServiceReturnsWithNoEnglishDescriptions()
        {
            // Arrange
            var text = "";
            var speciesExternal = new Species
            {
                Habitat = new Habitat(),
                FlavorTextEntries = new List<FlavorTextEntry>()
            };

            _translationService.Setup(e => e.Get(It.IsAny<string>()))
                .Returns(Task.FromResult(text));
            _translationFactory.Setup(e => e.CreateService(It.IsAny<global::Services.Internal.Models.Species>()))
                .Returns(_translationService.Object);
            _pokemonService.Setup(e => e.Get(It.IsAny<string>()))
                .Returns(Task.FromResult(speciesExternal));

            // Act
            var speciesInternal = await _speciesService.Get("mewtwo");

            // Assert

            Assert.IsNull(speciesInternal);
            _pokemonService.Verify(e => e.Get(It.IsAny<string>()), Times.Once);
            _translationFactory.Verify(e => e.CreateService(It.IsAny<global::Services.Internal.Models.Species>()), Times.Never);
            _translationService.Verify(e => e.Get(It.IsAny<string>()), Times.Never);
        }

        /// <summary>
        /// When the Pokemon service returns an object
        /// </summary>
        [Test]
        public async Task WhenPokemonServiceReturnsSpecies()
        {
            // Arrange
            var text = "";
            var speciesExternal = new Species
            {
                Habitat = new Habitat(),
                FlavorTextEntries = new List<FlavorTextEntry>
                {
                    new FlavorTextEntry
                    {
                        FlavorText = "mewtwo description",
                        Language = new Language
                        {
                            Name = "en"
                        },
                        Version = new Version
                        {
                            Name = "red"
                        }
                    }
                }
            };

            _translationService.Setup(e => e.Get(It.IsAny<string>()))
                .Returns(Task.FromResult(text));
            _translationFactory.Setup(e => e.CreateService(It.IsAny<global::Services.Internal.Models.Species>()))
                .Returns(_translationService.Object);
            _pokemonService.Setup(e => e.Get(It.IsAny<string>()))
                .Returns(Task.FromResult(speciesExternal));

            // Act
            var speciesInternal = await _speciesService.Get("mewtwo");

            // Assert

            Assert.AreEqual("mewtwo description", speciesInternal.Description);
            _pokemonService.Verify(e => e.Get(It.IsAny<string>()), Times.Once);
            _translationFactory.Verify(e => e.CreateService(It.IsAny<global::Services.Internal.Models.Species>()), Times.Never);
            _translationService.Verify(e => e.Get(It.IsAny<string>()), Times.Never);
        }

        /// <summary>
        /// When the Pokemon service returns an object
        /// </summary>
        [Test]
        public async Task WhenTranslatedTextIsEmpty()
        {
            // Arrange
            var text = "";
            var speciesExternal = new Species
            {
                Habitat = new Habitat(),
                FlavorTextEntries = new List<FlavorTextEntry>
                {
                    new FlavorTextEntry
                    {
                        FlavorText = "mewtwo description",
                        Language = new Language
                        {
                            Name = "en"
                        },
                        Version = new Version
                        {
                            Name = "red"
                        }
                    }
                }
            };

            _translationService.Setup(e => e.Get(It.IsAny<string>()))
                .Returns(Task.FromResult(text));
            _translationFactory.Setup(e => e.CreateService(It.IsAny<global::Services.Internal.Models.Species>()))
                .Returns(_translationService.Object);
            _pokemonService.Setup(e => e.Get(It.IsAny<string>()))
                .Returns(Task.FromResult(speciesExternal));

            // Act
            var speciesInternal = await _speciesService.Get("mewtwo", true);

            // Assert

            Assert.AreEqual("mewtwo description", speciesInternal.Description);
            _pokemonService.Verify(e => e.Get(It.IsAny<string>()), Times.Once);
            _translationFactory.Verify(e => e.CreateService(It.IsAny<global::Services.Internal.Models.Species>()), Times.Once);
            _translationService.Verify(e => e.Get(It.IsAny<string>()), Times.Once);
        }

        /// <summary>
        /// When the Pokemon service returns an object
        /// </summary>
        [Test]
        public async Task WhenTranslatedTextIsNotEmpty()
        {
            // Arrange
            var text = "translated text";
            var speciesExternal = new Species
            {
                Habitat = new Habitat(),
                FlavorTextEntries = new List<FlavorTextEntry>
                {
                    new FlavorTextEntry
                    {
                        FlavorText = "mewtwo description",
                        Language = new Language
                        {
                            Name = "en"
                        },
                        Version = new Version
                        {
                            Name = "red"
                        }
                    }
                }
            };

            _translationService.Setup(e => e.Get(It.IsAny<string>()))
                .Returns(Task.FromResult(text));
            _translationFactory.Setup(e => e.CreateService(It.IsAny<global::Services.Internal.Models.Species>()))
                .Returns(_translationService.Object);
            _pokemonService.Setup(e => e.Get(It.IsAny<string>()))
                .Returns(Task.FromResult(speciesExternal));

            // Act
            var speciesInternal = await _speciesService.Get("mewtwo", true);

            // Assert

            Assert.AreEqual("translated text", speciesInternal.Description);
            _pokemonService.Verify(e => e.Get(It.IsAny<string>()), Times.Once);
            _translationFactory.Verify(e => e.CreateService(It.IsAny<global::Services.Internal.Models.Species>()), Times.Once);
            _translationService.Verify(e => e.Get(It.IsAny<string>()), Times.Once);
        }

        #endregion Tests
    }
}
