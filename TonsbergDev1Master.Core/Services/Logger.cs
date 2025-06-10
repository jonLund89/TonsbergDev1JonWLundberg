using TonsbergDev1Master.Core.Interfaces;

public class Logger : ILogger
{
    private readonly TextWriter _writer;
    private readonly IDateTimeProvider _dateTimeProvider;
    public Logger(TextWriter writer, IDateTimeProvider dateTimeProvider)
    {
        _writer = writer;
        _dateTimeProvider = dateTimeProvider;
        Log("Logger initialized");
    }

    public void Log(string str)
    {
        _writer.WriteLine(string.Format("[{0:dd.MM.yy HH:mm:ss}] {1}", _dateTimeProvider.GetUtcNow(), str));
    }
}