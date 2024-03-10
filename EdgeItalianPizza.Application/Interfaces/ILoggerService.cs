namespace EdgeItalianPizza.Application.Interfaces;

public interface ILoggerService
{
    void Log(string message);

    void Error(string message);
}
