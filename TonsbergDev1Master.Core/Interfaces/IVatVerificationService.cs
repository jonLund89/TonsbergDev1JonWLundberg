
namespace TonsbergDev1Master.Core.Interfaces
{
    public interface IVatVerificationService
    {
        Task<VatVerifier.VerificationStatus> GetVatVerificationStatusAsync(string countryCode, string vatId);
    }
}
