using AutoMapper;
using Conta.Models;
using Conta.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conta.Mappers.Profiles
{
    public class ModelToResponse : Profile
    {
        public ModelToResponse()
        {
            CreateMap<ContaModel, ContaResponse>().ReverseMap();
        }
    }
}
