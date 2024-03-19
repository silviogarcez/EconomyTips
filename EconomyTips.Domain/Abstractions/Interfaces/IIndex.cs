namespace EconomyTips.Domain.Abstractions.Interfaces
{
    public interface IIndex<T> : IValidation
    {
        public abstract T Calculation(T domain);
    }
}
