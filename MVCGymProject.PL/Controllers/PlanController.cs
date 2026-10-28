using Microsoft.AspNetCore.Mvc;
using MVCGymProject.DAL.Repositories.Interfaces;

namespace MVCGymProject.PL.Controllers;

public class PlanController : Controller
{
    private readonly IPlanRepository _planRepository;

    public PlanController(IPlanRepository planRepository)
    {
        _planRepository = planRepository;
    }

    public async Task<IActionResult> Index(CancellationToken ct)
    {
        var plans = await _planRepository.GetAllPlansAsync(ct: ct);
        return View(plans);
    }

    public async Task<IActionResult> Details(int id, CancellationToken ct)
    {
        var plan = await _planRepository.GetPlanByIdAsync(id, ct: ct);
        if (plan is null)
        {
            return NotFound();
        }
        return View(plan);
    }
}