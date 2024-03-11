using EdgeItalianPizza.Infrastructrure.SqlServer.Data;

internal class Program
{
    private static void Main()
    {
        var dbContext = new AppDbContext();
        dbContext.Database.EnsureCreated();
    }
}
