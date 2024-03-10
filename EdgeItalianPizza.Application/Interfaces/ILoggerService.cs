namespace EdgeItalianPizza.Application.Interfaces;

public interface ILoggerService
{
    void Log(params string[] message);

    void Error(params string[] message);
}
