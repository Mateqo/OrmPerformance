using Microsoft.AspNetCore.Mvc;
using OrmPerformance.Services.NHibernate;

namespace OrmPerformance.Controllers
{
    public class NHibernateController : Controller
    {
        private readonly INHibernateService _nHibernateService;
        public NHibernateController(INHibernateService nHibernateService)
        {
            _nHibernateService = nHibernateService;
        }


        public IActionResult Get(int Id)
        {
            var viewModel = _nHibernateService.Get(Id);
            return View(viewModel);
        }
    }
}
