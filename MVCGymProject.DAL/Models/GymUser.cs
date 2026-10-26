using MVCGymProject.DAL.Models.Enums;

namespace MVCGymProject.DAL.Models;

public abstract class GymUser : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;

    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public Address Address { get; set; } = default!;

}
