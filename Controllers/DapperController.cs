using Microsoft.AspNetCore.Mvc;
using OrmPerformance.Services.Dapper;

namespace OrmPerformance.Controllers
{
    public class DapperController : Controller
    {
        private readonly IDapperService _dapperService;
        public DapperController(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }


        public IActionResult Get(int Id)
        {
            var viewModel = _dapperService.Get(Id);
            return View(viewModel);
        }
    }
}
