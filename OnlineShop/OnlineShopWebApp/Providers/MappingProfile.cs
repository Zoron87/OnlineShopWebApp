using AutoMapper;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Areas.Administrator.Models;
using OnlineShopWebApp.Models;
using WebAPI.Models;

namespace OnlineShopWebApp.Providers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Product, ItemViewModel>().ReverseMap();
            CreateMap<ItemViewModel, Product>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ImagesPath, opt =>opt.MapFrom(s => s.ImagesPath));
            CreateMap<Image, ImageViewModel>().ReverseMap();
            CreateMap<Cart, CartViewModel>().ReverseMap();
            CreateMap<CartItem, CartItemViewModel>().ReverseMap();
            CreateMap<Order, OrderViewModel>().ReverseMap();
            CreateMap<OrderDetails, Order>()
                .ForPath(x => x.OrderDetails.Name, opt => opt.MapFrom(el => el.Name))
                .ForPath(x => x.OrderDetails.Email, opt => opt.MapFrom(el => el.Email))
                .ForPath(x => x.OrderDetails.Address, opt => opt.MapFrom(el => el.Address))
                .ForPath(x => x.OrderDetails.Comment, opt => opt.MapFrom(el => el.Comment))
                .ForPath(x => x.OrderDetails.Delivery, opt => opt.MapFrom(el => el.Delivery))
                .ForPath(x => x.OrderDetails.DeliveryDate, opt => opt.MapFrom(el => el.DeliveryDate))
                .ForPath(x => x.OrderDetails.Pay, opt => opt.MapFrom(el => el.Pay))
                .ForPath(x => x.OrderDetails.Phone, opt => opt.MapFrom(el => el.Phone));
            CreateMap<OrderViewModel, Order>().ReverseMap();
            CreateMap<Order, OrderDetailsViewModel>().ReverseMap();
            CreateMap<OrderDetails, OrderDetailsViewModel>().ReverseMap();
            CreateMap<OrderDetails, OrderViewModel>().ReverseMap();
            CreateMap<User, UserViewModel>()
                .ForMember(x => x.Password, opt => opt.MapFrom(el => el.PasswordHash)).ReverseMap();
            CreateMap<ProfileViewModel, User>()
                .ForMember(x => x.AvatarImagepath, opt => opt.Ignore())
                .ForMember(x => x.Name, opt => opt.MapFrom(el => el.Name))
                .ForMember(x => x.Phone, opt => opt.MapFrom(el => el.Phone))
                .ForMember(x => x.Email, opt => opt.MapFrom(el => el.Email))
                .ForMember(x => x.Address, opt => opt.MapFrom(el => el.Address))
                .ForMember(x => x.UserName, opt => opt.MapFrom(el => el.Email))
                .ForMember(x => x.Role, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<Favourite, FavouriteViewModel>().ReverseMap();
            CreateMap<UserRole, RoleViewModel>().ReverseMap();
            CreateMap<Compare, CompareViewModel>().ReverseMap();
            CreateMap<ItemViewModel, ProductViewModel>().ReverseMap();
            CreateMap<ReviewDB, ReviewViewModel>().ReverseMap();
        }
        
    }
}
