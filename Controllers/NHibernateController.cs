using Microsoft.AspNetCore.Mvc;
using OrmPerformance.Extension.Common;
using OrmPerformance.Services.NHibernate;
using OrmPerformance.ViewModels.Orders;
using System.Diagnostics;

namespace OrmPerformance.Controllers
{
    public class NHibernateController : Controller
    {
        private readonly INHibernateService _nHibernateService;
        private readonly ILogger<NHibernateController> _logger;

        public NHibernateController(INHibernateService nHibernateService, ILogger<NHibernateController> logger)
        {
            _nHibernateService = nHibernateService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(int count, int id)
        {
            try
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                List<OrderGet> orders = new List<OrderGet>();

                for (int i = 1; i <= count; i++)
                {
                    var viewModel = _nHibernateService.Get(id);
                    orders.Add(viewModel);
                }

                stopWatch.Stop();
                var time = TimeFormat.GetSecondsFormat(stopWatch);

                return Json(new { result = orders, time = time });
            }
            catch (Exception e)
            {
                _logger.LogInformation(String.Format("Data: {0}, Błąd: {1}", DateTime.Now, e));
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult GetExtended(int count, string phrase)
        {
            try
            {
                List<OrderGet> orders = new List<OrderGet>();

                for (int i = 1; i <= count; i++)
                {
                    var viewModel = _nHibernateService.GetExtended(phrase);
                    orders.Add(viewModel);
                }

                return Json(orders);
            }
            catch (Exception e)
            {
                _logger.LogInformation(String.Format("Data: {0}, Błąd: {1}", DateTime.Now, e));
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult GetWithJoin(int count, int id)
        {
            try
            {
                List<OrderGetExtended> orders = new List<OrderGetExtended>();

                for (int i = 1; i <= count; i++)
                {
                    var viewModel = _nHibernateService.GetWithJoin(id);
                    orders.Add(viewModel);
                }

                return Json(orders);
            }
            catch (Exception e)
            {
                _logger.LogInformation(String.Format("Data: {0}, Błąd: {1}", DateTime.Now, e));
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult GetWithJoinExtended(int count, string phrase)
        {
            try
            {
                List<OrderGetExtended> orders = new List<OrderGetExtended>();

                for (int i = 1; i <= count; i++)
                {
                    var viewModel = _nHibernateService.GetWithJoinExtended(phrase);
                    orders.Add(viewModel);
                }

                return Json(orders);
            }
            catch (Exception e)
            {
                _logger.LogInformation(String.Format("Data: {0}, Błąd: {1}", DateTime.Now, e));
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult Create(int count, OrderCreate create)
        {
            try
            {
                List<int> ids = new List<int>();

                for (int i = 1; i <= count; i++)
                {
                    int id = _nHibernateService.Create(create);
                    ids.Add(id);
                }

                return Json(ids);
            }
            catch (Exception e)
            {
                _logger.LogInformation(String.Format("Data: {0}, Błąd: {1}", DateTime.Now, e));
                return View("Error");
            }
        }


        [HttpPost]
        public IActionResult Update(int count, OrderUpdate update)
        {
            try
            {
                for (int i = 1; i <= count; i++)
                {
                    _nHibernateService.Update(update);
                }

                return Json(null);
            }
            catch (Exception e)
            {
                _logger.LogInformation(String.Format("Data: {0}, Błąd: {1}", DateTime.Now, e));
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult Delete(int count, int id)
        {
            try
            {
                List<bool> isDeleteList = new List<bool>();

                for (int i = 1; i <= count; i++)
                {
                    var isDelete = _nHibernateService.Delete(id);
                    isDeleteList.Add(isDelete);
                }

                return Json(isDeleteList);
            }
            catch (Exception e)
            {
                _logger.LogInformation(String.Format("Data: {0}, Błąd: {1}", DateTime.Now, e));
                return View("Error");
            }
        }
    }
}
