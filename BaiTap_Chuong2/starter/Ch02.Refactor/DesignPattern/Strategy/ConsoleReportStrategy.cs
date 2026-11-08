namespace EduHub.Ch02.DesignPattern;

public class ConsoleReportStrategy : IReportStrategy
{
    public void OutPut(IReadOnlyList<ClubReportRow> rows)
    {
        foreach(var r in rows)
        {
            System.Console.WriteLine($"Club: {r.ClubName}, Member: {r.MemberCount}");
        }
    }
}