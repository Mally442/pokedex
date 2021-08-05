using Microsoft.Extensions.DependencyInjection;
using Services.External.Implementations;
using Services.External.Interfaces;
using Services.Internal.Implementations;
using Services.Internal.Interfaces;

namespace Services.Registration
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ISpeciesService, SpeciesService>();
            services.AddScoped<IPokemonService, PokemonService>();
            services.AddScoped<ITranslationFactory, TranslationFactory>();
        }
    }

}
