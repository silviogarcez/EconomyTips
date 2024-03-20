using EconomyTips.Domain.Abstractions.Interfaces;

namespace EconomyTips.Domain
{
    public class Cdb : ICdb
    {
        public double StartValue { get; set; }
        public double FinalValue { get; set; }
        public double FinalValueWithTaxes { get; set; }
        private double Cdi { get; set; } = 0.009;
        private double Tb { get; set; } = 1.08;
        public CdbTaxes cdbTaxes { get; set; } = new CdbTaxes();
        public int Months { get; set; } = 1;


        public void IsValid()
        {
            if (this.StartValue < 0)
                throw new ArgumentException("Started value must be greater than zero.");

            if (this.Months < 2)
                throw new ArgumentException("Month value must be greater than one.");
        }

        public ICdb Calculation(ICdb domain)
        {
            this.StartValue = domain.StartValue;
            this.Months = domain.Months;

            IsValid();

            CalculationWithMonths(this.Months);

            CalculationFee();

            return this;
        }

        private void CalculationWithMonths(int months)
        {
            var value = this.StartValue;

            for (int i = 1; i <= months; i++)
            {
                value = value * (1 + (this.Cdi * this.Tb));
            }

            this.FinalValue = Math.Round(value, 2);
        }

        private void CalculationFee()
        {
            this.FinalValueWithTaxes = Math.Round(this.FinalValue - ((this.FinalValue - this.StartValue) * cdbTaxes.Fee(this.Months)), 2);
        }

    }
}
