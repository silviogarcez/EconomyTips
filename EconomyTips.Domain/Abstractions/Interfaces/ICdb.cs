namespace EconomyTips.Domain.Abstractions.Interfaces
{
    public interface ICdb : IIndex<ICdb>
    {
        public double StartValue { get; set; }
        public double FinalValue { get; set; }
        public double FinalValueWithTaxes { get; set; }
        public int Months { get; set; }


        public CdbTaxes cdbTaxes { get; set; }
    }
}
