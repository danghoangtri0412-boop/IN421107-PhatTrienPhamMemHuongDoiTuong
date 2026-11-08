using EduHub.Ch02.Interface;

namespace EduHub.Ch02.Services;

public class ReportServices
{
    private readonly IClubRepository _clubs;
    private readonly IMemberRepository _members;
    private readonly IAppLogger _logger;

    public ReportServices(IClubRepository club, IMemberRepository member, IAppLogger logger)
    {
        _clubs = club;
        _members = member;
        _logger = logger;
    }

    public void PrintClubReport()
    {
        foreach(var club in _clubs.GetAll())
        {
            var count = _members.CountByClub(club.Id);
            System.Console.WriteLine($"Club: {club.Name}, Member: {count}");
            _logger.Log($"Report generated for {club.Name}");
        }
    }
}