using Microsoft.AspNetCore.Mvc;
using MVCGymProject.DAL.Repositories.Interfaces;
using MVCGymProject.Data;

namespace MVCGymProject.Controllers
{

    public class PlansController : Controller
    {
        private readonly GymDbContext _dbcontext;
        public PlansController(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
            //_planRepository = new PlanRepository();
            //_dbcontext = new GymDbContext();
        }
        private readonly IPlanRepository _planRepository;
        public async Task<IActionResult> Index(CancellationToken ct)
        {
            //var plans = await _dbcontext.Plans.ToListAsync();
            var plans = await _planRepository.GetAllPlansAsync(ct: ct);
            return View(plans);
        }
        public async Task<IActionResult> Details(int id, CancellationToken ct)
        {
            //var plan = await _dbcontext.Plans.FindAsync(id);
            var plan = await _planRepository.GetPlanByIdAsync(id, ct: ct);
            if (plan == null)
            {
                return RedirectToAction("Index");
            }
            return View(plan);
        }
    }
}
