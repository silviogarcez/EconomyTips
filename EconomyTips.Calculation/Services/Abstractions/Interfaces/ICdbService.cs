using EconomyTips.Domain;
using EconomyTips.Domain.Abstractions.Interfaces;

namespace EconomyTips.Calculation.Services.Abstractions.Interfaces
{
    public interface ICdbService
    {
        Result<ICdb> GetCalculation(ICdb cdb);
    }
}
