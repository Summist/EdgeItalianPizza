using EdgeItalianPizza.Application.Interfaces;

namespace EdgeItalianPizza.Application.Services;

public sealed class FileLoggerService : ILoggerService
{
    private readonly string _filePath;

    public FileLoggerService()
    {
        _filePath = CreateFile($"Log for {DateTime.Now.ToString("dd-MM-yyyy HH-mm")}");
        WriteLog("Log Entry", $"At {DateTime.Now.ToLongTimeString()}");
    }

    public void Error(params string[] message)
    {
        WriteLog("Error", message);
    }

    public void Log(params string[] message)
    {
        WriteLog("Log", message);
    }

    private void WriteLog(string title, params string[] message)
    {
        string fixedTitle = $"--- {title} ---";

        using (var sw = new StreamWriter(_filePath, true, System.Text.Encoding.Default))
        {
            sw.WriteLine(fixedTitle);
            for (int i = 0; i < message.Length; i++)
            {
                sw.WriteLine(" " + message);
            }
            sw.WriteLine(new string('-', fixedTitle.Length));
        }
    }

    private string CreateFile(string fileName)
    {
        string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Log Files");

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        string filePath = Path.Combine(directoryPath, $"{fileName}.txt");

        using (FileStream fs = File.Create(filePath))

        return filePath;
    }
}
