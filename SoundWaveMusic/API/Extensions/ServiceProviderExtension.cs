using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using SoundWaveMusic.Interfaces;
using SoundWaveMusic.Repositories;
using SoundWaveMusic.DataAccess.Data;
using SoundWaveMusic.DataAccess;
using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using SoundWaveMusic.Models.MappingProfiles;
using SoundWaveMusic.DataAccess.Interfaces;

namespace API.Extensions
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
            services.AddScoped<ICDRepository, CDRepository>();
            services.AddScoped<IVinylRepository, VinylRepository>();

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
            services.AddScoped<ICDService, CDService>();
            services.AddScoped<IVinylService, VinylService>();

            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            return services;
        }

        public static IServiceCollection RegisterDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SoundWaveDbContext>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}
