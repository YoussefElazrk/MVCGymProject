using Microsoft.AspNetCore.Mvc;
using MVCGymProject.DAL.Models;
using MVCGymProject.DAL.Repositories.Interfaces;

namespace MVCGymProject.PL.Controllers;

public class PlanController : Controller
{
    private readonly IGenericRepository<Plan> _planRepository;

    public PlanController(IGenericRepository<Plan> planRepository)
    {
        _planRepository = planRepository;
    }

    public async Task<IActionResult> Index(CancellationToken ct)
    {
        var plans = await _planRepository.GetAllAsync(ct: ct);
        return View(plans);
    }

    public async Task<IActionResult> Details(int id, CancellationToken ct)
    {
        var plan = await _planRepository.GetByIdAsync(id, ct: ct);
        if (plan is null)
        {
            return NotFound();
        }
        return View(plan);
    }
}