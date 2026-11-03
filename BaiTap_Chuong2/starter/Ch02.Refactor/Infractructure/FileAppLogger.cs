using EduHub.Ch02.Interface;

namespace EduHub.Ch02.Infractructure;

public class FileAppLogger : IAppLogger
{
    private readonly string _logFilePath;

    public FileAppLogger(String filePath = "club-log.txt")
    {
        _logFilePath = filePath;
    }

    public void Log(String message)
    {
        File.AppendAllText(_logFilePath,$"[{DateTime.UtcNow}] {message}\n");
    }
}