﻿using AutoMapper;
using Conta.Mappers.Profiles;

namespace Conta.Mappers
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
