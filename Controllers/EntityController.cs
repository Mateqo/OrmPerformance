using Microsoft.AspNetCore.Mvc;
using OrmPerformance.Services.EntityFramework;

namespace OrmPerformance.Controllers
{
    public class EntityController : Controller
    {
        private readonly IEntityFrameworkService _entityFrameworkService;
        public EntityController(IEntityFrameworkService entityFrameworkService)
        {
            _entityFrameworkService = entityFrameworkService;
        }


        public IActionResult Get(int Id)
        {
            var viewModel = _entityFrameworkService.Get(Id);
            return View(viewModel);
        }

    }
}
