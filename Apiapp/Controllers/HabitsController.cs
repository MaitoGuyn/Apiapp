using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Apiapp.Controllers
{
    public class HabitsController : Controller
    {
        [ApiController]
        [Route("[controller]")]
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
