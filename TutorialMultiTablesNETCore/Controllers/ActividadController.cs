using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TutorialMultiTablesNETCore.Context;
using TutorialMultiTablesNETCore.Models;

namespace TutorialMultiTablesNETCore.Controllers
{
    public class ActividadController : Controller
    {
        private readonly ActividadesDbContext _db;

        public ActividadController(ActividadesDbContext db)
        {
            _db = db;
        }

        public async Task<ActionResult> AllActividades()
        {
            var actividades = await _db.Actividades.ToListAsync();
            return View(actividades);
        }

        public IActionResult AddActividad()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddActividad(Actividad actividad)
        {
            _db.Add(actividad);
            await _db.SaveChangesAsync();
            return RedirectToAction("AllActividades");
        }

        public async Task<IActionResult> EditActividad(int id)
        {
            var actividad = await _db.Actividades.FindAsync(id);
            return View(actividad);
        }

        [HttpPost]
        public async Task<IActionResult> EditActividad(Actividad actividad)
        {
            _db.Update(actividad);
            await _db.SaveChangesAsync();
            return RedirectToAction("AllActividades");
        }

        public async Task<IActionResult> DeleteActividad(int id)
        {
            var actividad = await _db.Actividades.FindAsync(id);
            return View(actividad);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteActividad(Actividad actividad)
        {
            _db.Remove(actividad);
            await _db.SaveChangesAsync();
            return RedirectToAction("AllActividades");
        }
    }
}
