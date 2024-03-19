using EconomyTips.Calculation.Services.Abstractions.Interfaces;
using EconomyTips.Domain;
using EconomyTips.Domain.Abstractions.Interfaces;

namespace EconomyTips.Calculation.Services
{
    public class CdbService(ILogger<CdbService> logger) : ICdbService
    {
        private readonly ILogger<CdbService> logger = logger;

        public Result<ICdb> GetCalculation(ICdb cdb)
        {
            Result<ICdb> ret = new Result<ICdb>();
            try
            {
                logger.LogInformation("Started Method GetCalculation");
                ret = ret.OK(cdb.Calculation(cdb));
                logger.LogInformation("Ended Method GetCalculation");
            }
            catch (Exception ex)
            {
                ret.BadRequest(ex.Message);
                logger.LogError(ex, "GetCalculation Method has an error: ");
                throw;
            }

            return ret;
        }
    }
}
