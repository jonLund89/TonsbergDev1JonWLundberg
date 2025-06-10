
using Services;
using TonsbergDev1Master.Core.Interfaces;
using static VatVerifier;

namespace TonsbergDev1Master.Core.Services
{
    public class VatVerificationService : IVatVerificationService
    {
        private readonly checkVatPortTypeClient _checkVatPortTypeClient;
        public VatVerificationService()
        {
            _checkVatPortTypeClient = new checkVatPortTypeClient();
        }
        public async Task<VatVerifier.VerificationStatus> GetVatVerificationStatusAsync(string countryCode, string vatId)
        {
                if (string.IsNullOrWhiteSpace(countryCode))
                {
                    throw new ArgumentException($"{nameof(countryCode)} cannot be empty");
                }
                if (string.IsNullOrWhiteSpace(countryCode))
                {
                    throw new ArgumentException($"{nameof(vatId)} cannot be empty");
                }

                var request = new checkVatRequest(countryCode, vatId);
                var (sucess, status) = await TryCheckVatAsync(request);
                    
                return status;
        }

        private async Task<(bool, VerificationStatus)> TryCheckVatAsync(checkVatRequest request)
        {
            try
            {
                var response = await _checkVatPortTypeClient.checkVatAsync(request);
                return response.valid ? 
                    (true, VerificationStatus.Valid) : 
                    (true, VerificationStatus.Invalid);
            }
            catch (Exception e)
            {
                return (false, VerificationStatus.Unavailable);
            }
        }
    }
}
