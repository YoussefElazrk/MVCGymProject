namespace MVCGymProject.DAL.Models;

public class HealthRecord : BaseEntity
{
    public int Height { get; set; }
    public int Weight { get; set; }
    public string BloodType { get; set; } = default!;
    public string? Note { get; set; }

}
