namespace TonsbergDev1Master.Core.Extensions
{
    public static class InvoiceGroupsExtensions
    {
        public static IEnumerable<string> GetReccuringGuestNames(this IEnumerable<InvoiceGroup> invoiceGroups) 
        { 
            return invoiceGroups?
                .SelectMany(ig => ig.Invoices)
                .SelectMany(i => i.Observations)
                .Select(o => o.GuestName)
                .GroupBy(name => name)
                .Where(group => group.Count() > 1)
                .Select(g => g.Key)
                ?? Enumerable.Empty<string>();
        }

        public static Dictionary<string, int> GetTotalNumberOfNightsPerTravelAgent(
            this IEnumerable<InvoiceGroup> invoiceGroups, DateTime? from = null, DateTime? to = null)
        {
            if (from == null)
            {
                from = new DateTime(2015, 1, 1);
            }
            if (to == null)
            {
                to = new DateTime(2016, 1, 1);
            }

            var r = invoiceGroups?
                .Where(ig => ig.IssueDate >= from && ig.IssueDate < to)
                .SelectMany(ig => ig.Invoices)
                .SelectMany(i => i.Observations)
                .GroupBy(o => o.TravelAgent)
                .ToDictionary(t => t.Key, t => t.Sum(x => x.NumberOfNights))
                ?? new Dictionary<string, int>();

            return r;
        } 
    }
}
