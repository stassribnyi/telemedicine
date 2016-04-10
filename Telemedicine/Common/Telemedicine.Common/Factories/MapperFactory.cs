using AutoMapper;
using AutoMapper.Mappers;

namespace Telemedicine.Common.Factories
{
    public class MapperFactory : IMapperFactory
    {
        public IMappingEngine CreateMapper<TProfile>()
            where TProfile : Profile, new()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<TProfile>());
            var engine = new MappingEngine(config, config.CreateMapper());
            return engine;
        }
    }
}
