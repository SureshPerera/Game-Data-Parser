public class Loger
{
    private readonly string _logFileName; 
    public Loger(string logFileName)
    {
        _logFileName = logFileName;
    }

    public void log(Exception ex)
    {
        var entry = $@"[{DateTime.Now}]
Exception Message : {ex.Message}
Stack trace : {ex.StackTrace}

";
        File.AppendAllText(_logFileName, entry);
    }
}
