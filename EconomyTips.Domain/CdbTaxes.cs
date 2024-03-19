using EconomyTips.Domain.Abstractions.Interfaces;

namespace EconomyTips.Domain
{
    public class CdbTaxes : ICdbTaxes
    {
        public const double SixMonths = 0.225;
        public const double OneYear = 0.20;
        public const double TwoYear = 0.175;
        public const double AboveTwoYear = 0.175;

        public double Tax { get; set; } = 0;

        public double Fee(int Month)
        {
            if (Month <= 6)
            {
                Tax = SixMonths;
            }
            else if (Month > 6 && Month <= 12)
            {
                Tax = OneYear;
            }
            else if (Month > 12 && Month <= 24)
            {
                Tax = TwoYear;
            }
            else if (Month > 24)
            {
                Tax = AboveTwoYear;
            }

            return Tax;
        }
    }
}
