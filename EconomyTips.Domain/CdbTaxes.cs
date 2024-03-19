using EconomyTips.Domain.Abstractions.Interfaces;

namespace EconomyTips.Domain
{
    public class CdbTaxes : ICdbTaxes
    {
        public const double SixMonths = 0.225;
        public const double OneYear = 0.20;
        public const double TwoYear = 0.175;
        public const double AboveTwoYear = 0.175;
        private const int TwoYearsInMonths = 24;

        public double Tax { get; set; } = 0;

        public double Fee(int Month)
        {
            if (Month <= 6)
                Tax = SixMonths;
            else if (Month <= 12)
                Tax = OneYear;
            else if (Month <= TwoYearsInMonths)
                Tax = TwoYear;
            else
                Tax = AboveTwoYear;

            return Tax;
        }
    }
}
