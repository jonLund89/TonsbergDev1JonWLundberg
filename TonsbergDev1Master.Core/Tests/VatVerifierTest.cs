using TonsbergDev1Master.Core.Services;
using Xunit;

namespace TonsbergDev1Master.Core.Tests
{
    public class VatVerifierTest
    {
        [Fact]
        public async Task TestGermanVatVerifier()
        {
            var verifier = new VatVerificationService();
            var status = await verifier.GetVatVerificationStatusAsync("DE", "118856456");
            Assert.NotNull(status);
        }

        [Fact]
        public async Task TestGermanVatVerifier2()
        {
            var verifier = new VatVerificationService(); 
            var status = await verifier.GetVatVerificationStatusAsync("DE", "327990207");
            Assert.NotNull(status);
        }
    }
}
