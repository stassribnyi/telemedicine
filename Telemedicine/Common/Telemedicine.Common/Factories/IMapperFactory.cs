using AutoMapper;
namespace Telemedicine.Common.Factories
{
    public interface IMapperFactory
    {
        IMappingEngine CreateMapper<TProfile>()
            where TProfile : Profile, new();
    }
}