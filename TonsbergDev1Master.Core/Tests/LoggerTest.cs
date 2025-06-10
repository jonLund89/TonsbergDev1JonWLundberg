using TonsbergDev1Master.Core.Interfaces;
using Xunit;

namespace TonsbergDev1Master.Core.Tests
{
    public class LoggerTest
    {
        private class MockDateTimeProvider : IDateTimeProvider
        {
            public DateTime GetUtcNow()
            {
                return new DateTime(2015, 1, 1);
            }
        }

        private IDateTimeProvider GetDateTimeProvider()
        {
            return new MockDateTimeProvider();
        }

        [Fact]
        public void TestLoggerInit() 
        {
            var writer = new StringWriter();
            var logger = new Logger(writer, GetDateTimeProvider());

            var wts = writer.ToString();

            Assert.Contains("Logger initialized", writer.ToString());
        }

        [Fact]
        public void TestLoggerLog()
        {
            var text = "Lorem Ipsum";
            var writer = new StringWriter();
            var logger = new Logger(writer, GetDateTimeProvider());
            logger.Log(text);

            var wts = writer.ToString();

            Assert.Contains(text, writer.ToString());
        }
    }
}
