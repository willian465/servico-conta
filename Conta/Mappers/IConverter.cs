namespace Conta.Mappers
{
    public interface IConverter
    {
        T Map<T>(object source);
    }
}
