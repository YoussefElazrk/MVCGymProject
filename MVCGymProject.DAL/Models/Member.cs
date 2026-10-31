namespace MVCGymProject.DAL.Models;

public sealed class Member : GymUser
{
    public string? PhotoUrl { get; set; }
    public HealthRecord HealthRecord { get; set; } = default!;
    public ICollection<Membership> Memberships { get; set; } = new HashSet<Membership>();
    public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
}
