using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Interface;

public interface IMemberRepository
{
    void Add (Member member);
    int CountByClub(Club club);
    IReadOnlyList<Member> GetByClub(Guid clubId);
}