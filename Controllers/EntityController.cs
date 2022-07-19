using Microsoft.AspNetCore.Mvc;
using OrmPerformance.Services.EntityFramework;
using OrmPerformance.ViewModels.Orders;

namespace OrmPerformance.Controllers
{
    public class EntityController : Controller
    {
        private readonly IEntityFrameworkService _entityFrameworkService;
        private readonly ILogger<EntityController> _logger;
        public EntityController(IEntityFrameworkService entityFrameworkService, ILogger<EntityController> logger)
        {
            _entityFrameworkService = entityFrameworkService;
            _logger = logger;
        }


        [HttpGet]
        public IActionResult Get(int count, int id)
        {
            try
            {
                List<OrderGet> orders = new List<OrderGet>();

                for (int i = 1; i <= count; i++)
                {
                    var viewModel = _entityFrameworkService.Get(id);
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
        public IActionResult GetExtended(int count, string phrase)
        {
            try
            {
                List<OrderGet> orders = new List<OrderGet>();

                for (int i = 1; i <= count; i++)
                {
                    var viewModel = _entityFrameworkService.GetExtended(phrase);
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
                    var viewModel = _entityFrameworkService.GetWithJoin(id);
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
                    var viewModel = _entityFrameworkService.GetWithJoinExtended(phrase);
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
                    int id = _entityFrameworkService.Create(create);
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
                    _entityFrameworkService.Update(update);
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
                    var isDelete = _entityFrameworkService.Delete(id);
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
