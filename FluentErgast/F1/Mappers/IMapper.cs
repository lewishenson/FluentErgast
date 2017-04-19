namespace FluentErgast.F1.Mappers
{
    public interface IMapper<in TIn, TOut>
    {
        TOut Map(TIn input);
    }
}