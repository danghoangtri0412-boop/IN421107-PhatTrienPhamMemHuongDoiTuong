using EduHub.Ch02.Domain;
using EduHub.Ch02.Interface;

namespace EduHub.Ch02.Infractructure;

public class InMemoryMemberRepository : IMemberRepository
{
    private readonly List<Member> _members = new();

    public void Add(Member member)
    {
        _members.Add(member);
    }

    public int CountByClub(Guid clubId)
    {
        return _members.Count(m => m.ClubId == clubId);
    }

    public IReadOnlyList<Member> GetByClub(Guid clubId)
    {
        return _members.Where(m => m.ClubId == clubId).ToList();
    }
}