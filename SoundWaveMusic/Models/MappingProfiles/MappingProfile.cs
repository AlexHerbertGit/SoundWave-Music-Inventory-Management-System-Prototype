using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoundWaveMusic.Entities;
using SoundWaveMusic.Models;

namespace SoundWaveMusic.Models.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Genre, GenreModel>().ReverseMap();
            CreateMap<Artist, ArtistModel>().ReverseMap();
            CreateMap<Album, AlbumModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<CD, CDModel>().ReverseMap();
            CreateMap<Vinyl, VinylModel>().ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();
            CreateMap<OrderItem, OrderItemModel>().ReverseMap();
        }
    }
}
