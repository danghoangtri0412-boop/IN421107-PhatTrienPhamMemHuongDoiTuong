using EduHub.Ch02;
using EduHub.Ch02.Domain;

namespace Ch02.Refactor.Tests;

// Mẫu AAA: Arrange (chuẩn bị) - Act (thực hiện) - Assert (kiểm tra).
// Mỗi test chỉ kiểm tra MỘT hành vi. Đặt tên: TênMethod_TìnhHuống_KếtQuảMongĐợi.
public class DomainTests
{
    // Test mẫu đã viết sẵn: chạy được ngay trên ClubManager hiện tại.
    [Fact]
    public void CreateClub_WithEmptyName_ThrowsArgumentException()
    {
        // Arrange
        var manager = new ClubManager();

        // Act
        var act = () => manager.CreateClub("", "mô tả", "p@gmail.com");

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

    // TODO (Nhiệm vụ 4): bỏ Skip và viết thân test cho từng trường hợp dưới đây.
    // Cần ≥ 6 test AAA cho lớp Domain (Club, Event), trong đó có cả trường hợp lỗi.

    [Fact]
    public void Club_Create_WithValidName_ReturnsClub()
    {
        // Arrange
        var name = "Chess Club";
        var description = "Câu lạc bộ cờ vua";

        // Act
        var club = Club.Create(name, description);

        // Assert
        Assert.Equal(name, club.Name);
        Assert.Equal(description, club.Description);
        Assert.NotEqual(Guid.Empty, club.Id);
    }

    [Fact]
    public void Club_Create_WithEmptyName_ThrowsArgumentException()
    {
        // Arrange
        var emptyName = "";

        // Act
        var act = () => Club.Create(emptyName, "mô tả");

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void Club_Create_WithWhitespaceName_ThrowsArgumentException()
    {
        // Arrange
        var whitespaceName = "   ";

        // Act
        var act = () => Club.Create(whitespaceName, "mô tả");

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void Club_Create_WithNameLongerThanMax_ThrowsArgumentException()
    {
        // Arrange
        var tooLongName = new string('a', Club.MaxNameLength + 1);

        // Act
        var act = () => Club.Create(tooLongName, "mô tả");

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void Club_Create_WithNameOfExactlyMaxLength_ReturnsClub()
    {
        // Arrange
        var maxName = new string('a', Club.MaxNameLength);

        // Act
        var club = Club.Create(maxName, "mô tả");

        // Assert
        Assert.Equal(maxName, club.Name);
    }

    [Fact]
    public void Club_HasRoom_AtMaxMembers_ReturnsFalse()
    {
        // Arrange
        var club = Club.Create("Chess Club", "mô tả");

        // Act
        var result = club.HasRoom(Club.MaxMembers);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Club_HasRoom_OneBelowMaxMembers_ReturnsTrue()
    {
        // Arrange
        var club = Club.Create("Chess Club", "mô tả");

        // Act
        var result = club.HasRoom(Club.MaxMembers - 1);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Event_Register_NewMember_ReturnsTrue()
    {
        // Arrange
        var ev = CreateEvent();
        var memberId = Guid.NewGuid();

        // Act
        var result = ev.Register(memberId);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Event_Register_SameMemberTwice_ReturnsFalse()
    {
        // Arrange
        var ev = CreateEvent();
        var memberId = Guid.NewGuid();
        ev.Register(memberId);

        // Act
        var result = ev.Register(memberId);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Event_CheckIn_UnregisteredMember_ThrowsInvalidOperationException()
    {
        // Arrange
        var ev = CreateEvent();
        var memberId = Guid.NewGuid();

        // Act
        var act = () => ev.CheckIn(memberId);

        // Assert
        Assert.Throws<InvalidOperationException>(act);
    }

    [Fact]
    public void Event_CheckIn_RegisteredMember_AddsToCheckedInList()
    {
        // Arrange
        var ev = CreateEvent();
        var memberId = Guid.NewGuid();
        ev.Register(memberId);

        // Act
        ev.CheckIn(memberId);

        // Assert
        Assert.Contains(memberId, ev.CheckedInMemberIds);
    }

    private static Event CreateEvent() => new Event
    {
        Id = Guid.NewGuid(),
        ClubId = Guid.NewGuid(),
        Title = "Workshop SOLID",
        Date = new DateTime(2026, 11, 20)
    };
}
