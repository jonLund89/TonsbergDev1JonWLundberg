using TonsbergDev1Master.Core.Interfaces;

namespace TonsbergDev1Master.Core.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetUtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}
