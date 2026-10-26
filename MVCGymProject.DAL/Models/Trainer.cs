using MVCGymProject.DAL.Models.Enums;

namespace MVCGymProject.DAL.Models;

public sealed class Trainer : GymUser
{
    public Specialty Speciality { get; set; }

}

