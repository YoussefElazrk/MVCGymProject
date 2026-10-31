namespace MVCGymProject.DAL.Models;

public class Booking : BaseEntity
{
    public int MemberId { get; set; }
    public Member Member { get; set; } = default!;
    public int SessionId { get; set; }
    public Session Session { get; set; } = default!;
    public bool IsAttended { get; set; }

}
