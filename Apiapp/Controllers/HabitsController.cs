using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Apiapp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HabitsController : Controller
    {
        private readonly List<Habits> _habits;
        public HabitsController(List<Habits> habits)
        {
            _habits = habits ?? new List<Habits>
            {
                new Habits(1, "Cпорт" , "Становая тяга 10 повторения, вес 50 кг" , DateTime.Now , 0),
                new Habits(2, "Программирование" , "Сделать 10 хардовых задач на LeetCode" , DateTime.Now , 25),
                new Habits(3, "Cаморефлекксия" , "В течения месяца делать саморелекисю" , DateTime.Now , 30),
                new Habits(4, "Проект" , "Каждый день 30 минут делать Unity" , DateTime.Now , 40),
                new Habits(5, "Работа" , "Сделать 20 закаков" , DateTime.Now , 50)
            };
        }
        

        public ActionResult<Habits> GetHaBits(int id)
        {
            var habit = _habits.FirstOrDefault(h => h.Id == id);
            if (habit == null)
            {
                return NotFound();
            }
            return habit;
        }

        private readonly ILogger<HabitsController> _logger;

        public HabitsController(ILogger<HabitsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetHabits")]
        public IEnumerable<Habits> Get()
        {
            return _habits;
        }




        // GET: HabitsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HabitsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
