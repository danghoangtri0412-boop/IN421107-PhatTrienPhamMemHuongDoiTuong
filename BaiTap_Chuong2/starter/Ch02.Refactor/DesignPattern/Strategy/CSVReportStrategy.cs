namespace EduHub.Ch02.DesignPattern;

public class CSVReportStrategy : IReportStrategy
{
    private readonly string _path;
    public CSVReportStrategy(string path = "report.csv")
    {
        _path = path;
    }
    public void OutPut(IReadOnlyList<ClubReportRow> rows)
    {
        var line = new List<string> {"ClubName, MemberCount"};
        line.AddRange(rows.Select(r => $"{r.ClubName}, {r.MemberCount}"));
        File.WriteAllLines(_path, line);
    }
}