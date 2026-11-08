namespace EduHub.Ch02.DesignPattern;

public interface IReportStrategy
{
    public void OutPut(IReadOnlyList<ClubReportRow> rows);
}