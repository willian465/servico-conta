using AutoMapper;

namespace Conta.Mappers
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
