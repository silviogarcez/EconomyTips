namespace EconomyTips.Domain.Abstractions.Interfaces
{
    public interface ICdbTaxes
    {
        public double Tax { get; set; }

        double Fee(int Month);
    }
}