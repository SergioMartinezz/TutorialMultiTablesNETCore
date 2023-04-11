using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TutorialMultiTablesNETCore.Context;
using TutorialMultiTablesNETCore.Models;
using TutorialMultiTablesNETCore.ViewModels;

namespace TutorialMultiTablesNETCore.Controllers
{
    public class InstructorController : Controller
    {
        private readonly ActividadesDbContext _db;

        public InstructorController(ActividadesDbContext db)
        {
            _db = db;
        }

        public async Task<ActionResult> AllInstructores()
        {
            var instructor = await _db.Instructores.Include(c => c.Actividad).ToListAsync();
            return View(instructor);
        }

        public async Task<ActionResult> AddInstructor()
        {
            var instructorDisplay = await _db.Actividades.Select(d => new
            {
                Id = d.ActividadId,
                Value = d.Nombre
            }).ToListAsync();

            AddActividadViewModel vm = new AddActividadViewModel();

            vm.ListaActividades = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(instructorDisplay, "Id", "Value");
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddInstructor(AddActividadViewModel vm)
        {
            var instructor = await _db.Actividades.SingleOrDefaultAsync(d => d.ActividadId == vm.Actividad.ActividadId);
            vm.Instructor.Actividad = instructor;
            _db.Add(vm.Instructor);
            await _db.SaveChangesAsync();
            return RedirectToAction("AllInstructores");
        }

        public async Task<IActionResult> EditInstructor(int id)
        {
            AddActividadViewModel vm = new AddActividadViewModel();

            var instructorDisplay = await _db.Actividades.Select(d => new
            {
                Id = d.ActividadId,
                Value = d.Nombre
            }).ToListAsync();

            var actualActividad = _db.Instructores.Include(c => c.Actividad).Where(c => c.InstructorId == id).Select(c => c.Actividad.ActividadId).FirstOrDefault();

            vm.ListaActividades = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(instructorDisplay,
                "Id", "Value", actualActividad);

            Instructor cd = await _db.Instructores.FindAsync(id);
            vm.Instructor = cd;

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> EditInstructor(AddActividadViewModel vm)
        {
            var selectedActividad = vm.Actividad.ActividadId;
            var choosenActivity = await _db.Actividades.SingleOrDefaultAsync(act => act.ActividadId == selectedActividad);

            vm.Instructor.Actividad = choosenActivity;

            _db.Update(vm.Instructor);
            await _db.SaveChangesAsync();
            return RedirectToAction("AllInstructores");
        }

        public async Task<IActionResult> DeleteInstructor(int id)
        {
            Instructor ac;
            ac = await _db.Instructores.Include(c => c.Actividad).Where(c => c.InstructorId == id).FirstOrDefaultAsync();
            return View(ac);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteInstructor(Instructor instructor)
        {
            _db.Remove(instructor);
            await _db.SaveChangesAsync();
            return RedirectToAction("AllInstructores");
        }
    }
}
