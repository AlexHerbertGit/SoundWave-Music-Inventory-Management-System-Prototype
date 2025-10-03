using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SoundWaveMusic.DataAccess;
using SoundWaveMusic.DataAccess.Data;
using SoundWaveMusic.DataAccess.Interfaces;
using SoundWaveMusic.DataAccess.Repositories;
using SoundWaveMusic.BusinessLayer.Interfaces;
using SoundWaveMusic.BusinessLayer.Services;

namespace SoundWaveMusic.API.Extensions
{
    public static class ServiceProviderExtension
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositories
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;

        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }

        public static IServiceCollection RegisterDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SoundWaveDbContext>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}
