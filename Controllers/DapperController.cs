using Microsoft.AspNetCore.Mvc;
using OrmPerformance.Extension.Common;
using OrmPerformance.Services.Dapper;
using OrmPerformance.ViewModels.Orders;
using System.Diagnostics;

namespace OrmPerformance.Controllers
{
    public class DapperController : Controller
    {
        private readonly IDapperService _dapperService;
        private readonly ILogger<EntityController> _logger;

        public DapperController(IDapperService dapperService, ILogger<EntityController> logger)
        {
            _dapperService = dapperService;
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
                    var viewModel = _dapperService.Get(id);
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
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                List<OrderGet> orders = new List<OrderGet>();

                for (int i = 1; i <= count; i++)
                {
                    var viewModel = _dapperService.GetExtended(phrase);
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
        public IActionResult GetWithJoin(int count, int id)
        {
            try
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                List<OrderGetExtended> orders = new List<OrderGetExtended>();

                for (int i = 1; i <= count; i++)
                {
                    var viewModel = _dapperService.GetWithJoin(id);
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
        public IActionResult GetWithJoinExtended(int count, string phrase)
        {
            try
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                List<OrderGetExtended> orders = new List<OrderGetExtended>();

                for (int i = 1; i <= count; i++)
                {
                    var viewModel = _dapperService.GetWithJoinExtended(phrase);
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

        [HttpPost]
        public IActionResult Create(int count, OrderCreate create)
        {
            try
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                List<int> ids = new List<int>();

                for (int i = 1; i <= count; i++)
                {
                    int id = _dapperService.Create(create);
                    ids.Add(id);
                }

                stopWatch.Stop();
                var time = TimeFormat.GetSecondsFormat(stopWatch);

                return Json(new { result = ids, time = time });
            }
            catch (Exception e)
            {
                _logger.LogInformation(String.Format("Data: {0}, Błąd: {1}", DateTime.Now, e));
                return View("Error");
            }
        }


        [HttpPost]
        public IActionResult Update(List<int> ids, OrderUpdate update)
        {
            try
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                foreach (var id in ids)
                {
                    update.Id = id;
                    _dapperService.Update(update);
                }

                stopWatch.Stop();
                var time = TimeFormat.GetSecondsFormat(stopWatch);

                return Json(new { time = time });
            }
            catch (Exception e)
            {
                _logger.LogInformation(String.Format("Data: {0}, Błąd: {1}", DateTime.Now, e));
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult Delete(List<int> ids)
        {
            try
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                List<bool> isDeleteList = new List<bool>();

                foreach (var id in ids)
                {
                    var isDelete = _dapperService.Delete(id);
                    isDeleteList.Add(isDelete);
                }

                stopWatch.Stop();
                var time = TimeFormat.GetSecondsFormat(stopWatch);

                return Json(new { result = isDeleteList, time = time });
            }
            catch (Exception e)
            {
                _logger.LogInformation(String.Format("Data: {0}, Błąd: {1}", DateTime.Now, e));
                return View("Error");
            }
        }
    }
}
