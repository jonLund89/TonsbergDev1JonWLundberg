namespace TonsbergDev1Master.Core.Tests
{
    public static class InvoiceGroupTestFixtures
    {
        public const string Guest1 = nameof(Guest1);
        public const string Guest2 = nameof(Guest2);
        public const string Guest3 = nameof(Guest3);
        public const string TravelAgent1 = nameof(TravelAgent1);
        public const string TravelAgent2 = nameof(TravelAgent2);
        public static IEnumerable<InvoiceGroup> GetGuestNameTestData()
        {
            return new List<InvoiceGroup>
        {
            new InvoiceGroup
            {
                Invoices = new List<Invoice>
                {
                    new Invoice
                    {
                        Observations = new List<Observation>
                        {
                            new Observation { GuestName = Guest1 },
                            new Observation { GuestName = Guest2 },
                            new Observation { GuestName = Guest3 },
                        }
                    },
                    new Invoice
                    {
                        Observations = new List<Observation>
                        {
                            new Observation { GuestName = Guest1 }, // Repeated
                            new Observation { GuestName = Guest2 }
                        }
                    }
                }
            }
        };
        }

        public static IEnumerable<InvoiceGroup> GetTravelAgentNightsTestData()
        {
            return new List<InvoiceGroup>
            {
                new InvoiceGroup
                {
                    IssueDate = new DateTime(2015, 5, 10),
                    Invoices = new List<Invoice>
                    {
                        new Invoice
                        {
                            Observations = new List<Observation>
                            {
                                new Observation { TravelAgent = TravelAgent1, NumberOfNights = 3 },
                                new Observation { TravelAgent = TravelAgent2, NumberOfNights = 2 }
                            }
                        }
                    }
                },
                new InvoiceGroup
                {
                    IssueDate = new DateTime(2015, 8, 20),
                    Invoices = new List<Invoice>
                    {
                        new Invoice
                        {
                            Observations = new List<Observation>
                            {
                                new Observation { TravelAgent = TravelAgent1, NumberOfNights = 4 }
                            }
                        }
                    }
                },
                new InvoiceGroup
                {
                    IssueDate = new DateTime(2016, 1, 10), // Outside 2015
                    Invoices = new List<Invoice>
                    {
                        new Invoice
                        {
                            Observations = new List<Observation>
                            {
                                new Observation { TravelAgent = TravelAgent1, NumberOfNights = 10 }
                            }
                        }
                    }
                }
            };
        }
    }
}
