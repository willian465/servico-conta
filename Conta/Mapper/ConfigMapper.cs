using AutoMapper;
using Conta.Mapper.Profiles;

namespace Conta.Mapper
{
    public static class ConfigMapper
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(config =>
            {
                config.AddProfile(new ModelToResponse());
            });
        }

    }
}
