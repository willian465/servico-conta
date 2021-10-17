using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conta.Mapper
{
    public class Coverter : IConverter
    {
        private readonly IMapper _mapper;

        public Coverter()
        {
            _mapper = ConfigMapper.RegisterMappings().CreateMapper();
        }

        public T Map<T>(object source)
        {
            T model = _mapper.Map<T>(source);
            return model;
        }
    }
}
