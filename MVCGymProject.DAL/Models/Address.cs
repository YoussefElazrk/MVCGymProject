using Microsoft.EntityFrameworkCore;

namespace MVCGymProject.DAL.Models;

[Owned]
public class Address
{
    public int BuildingNumber { get; set; }
    public string Street { get; set; } = default!;
    public string City { get; set; } = default!;
}
