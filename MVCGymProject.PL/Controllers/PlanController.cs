using Microsoft.AspNetCore.Mvc;
using MVCGymProject.DAL.Models;
using MVCGymProject.DAL.Repositories.Interfaces;

namespace MVCGymProject.PL.Controllers;

public class PlanController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public PlanController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index(CancellationToken ct)
    {
        var plans = await _unitOfWork.Repository<Plan>().GetAllAsync(ct: ct);
        return View(plans);
    }

    public async Task<IActionResult> Details(int id, CancellationToken ct)
    {
        var plan = await _unitOfWork.Repository<Plan>().GetByIdAsync(id, ct: ct);
        if (plan is null)
        {
            return NotFound();
        }
        return View(plan);
    }
}