namespace MVCGymProject.DAL.Models;

public class HealthRecord : BaseEntity
{
    public decimal Height { get; set; }
    public decimal Weight { get; set; }
    public string BloodType { get; set; } = default!;
    public string? Note { get; set; }
    public Member Member { get; set; } = default!;

}
