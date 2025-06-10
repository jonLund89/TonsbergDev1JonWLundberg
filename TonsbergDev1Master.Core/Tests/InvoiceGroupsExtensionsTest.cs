using TonsbergDev1Master.Core.Extensions;
using Xunit;

namespace TonsbergDev1Master.Core.Tests
{
    public class InvoiceGroupsExtensionsTest
    {
        [Fact]
        public void ShouldGetRecurringGuestNames()
        {
            var invoiceGroups = InvoiceGroupTestFixtures.GetGuestNameTestData();

            var result = invoiceGroups.GetReccuringGuestNames().ToList();

            Assert.Equal(2, result.Count);
            Assert.Contains(InvoiceGroupTestFixtures.Guest1, result);
            Assert.Contains(InvoiceGroupTestFixtures.Guest2, result);
        }

        [Fact]
        public void ShouldGetTotalNumberOfNightPerTravelAgent2015()
        {
            var invoiceGroups = InvoiceGroupTestFixtures.GetTravelAgentNightsTestData();

            var result = invoiceGroups.GetTotalNumberOfNightsPerTravelAgent();

            Assert.Equal(2, result.Count);
            Assert.Equal(7, result[InvoiceGroupTestFixtures.TravelAgent1]);
            Assert.Equal(2, result[InvoiceGroupTestFixtures.TravelAgent2]);
        }
    }
}
