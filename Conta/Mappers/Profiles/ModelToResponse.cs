using AutoMapper;
using Conta.Models;
using Conta.Responses;

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
