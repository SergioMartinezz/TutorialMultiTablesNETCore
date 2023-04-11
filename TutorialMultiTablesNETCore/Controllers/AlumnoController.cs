using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TutorialMultiTablesNETCore.Context;
using TutorialMultiTablesNETCore.Models;

namespace TutorialMultiTablesNETCore.Controllers
{
    public class AlumnoController : Controller
    {
        private readonly ActividadesDbContext _db;
        public AlumnoController(ActividadesDbContext db)
        {
            _db = db;
        }

        public async Task<ActionResult> AllAlumnos()
        {
            var alumnos = await _db.Alumnos.ToListAsync();
            return View(alumnos);
        }

        public IActionResult AddAlumno()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAlumno(Alumno alumnos)
        {
            _db.Add(alumnos);
            await _db.SaveChangesAsync();
            return RedirectToAction("AllAlumnos");
        }

        public async Task<IActionResult> EditAlumno(int id)
        {
            Alumno alumno;
            alumno = _db.Alumnos.Find(id);
            return View(alumno);
        }

        [HttpPost]
        public async Task<IActionResult> EditAlumno(Alumno alumno)
        {
            _db.Update(alumno);
            await _db.SaveChangesAsync();
            return RedirectToAction("AllAlumnos");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAlumno(int id)
        {
            var alumno = await _db.Alumnos.FindAsync(id);
            return View(alumno);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAlumno(Alumno alumno)
        {
            _db.Remove(alumno);
            await _db.SaveChangesAsync();
            return RedirectToAction("AllAlumnos");
        }
        public async Task<IActionResult> MatricularAlumno(int? id)
        {
            var alumnoDisplay = await _db.Alumnos.Select(x => new
            {
                Id = x.AlumnoId,
                Value = x.Nombre
            }).ToListAsync();

            ViewModels.MatriculaAlumnoViewModel vm = new ViewModels.MatriculaAlumnoViewModel();
            vm.ListaAlumnos = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(alumnoDisplay, "Id", "Value");
            var actividad = await _db.Actividades.SingleOrDefaultAsync(c => c.ActividadId == id);
            ViewBag.Actividad = actividad;

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> MatricularAlumno(ViewModels.MatriculaAlumnoViewModel vm)
        {
            if (Comprueba(vm.Matricula.Actividad.ActividadId, vm.Matricula.Alumno.AlumnoId))
            {
                return RedirectToAction("AllActividades");
            }
            else
            {
                var alumno = await _db.Alumnos.SingleOrDefaultAsync(s => s.AlumnoId == vm.Matricula.Alumno.AlumnoId);
                var actividad = await _db.Actividades.SingleOrDefaultAsync(s => s.ActividadId == vm.Matricula.Actividad.ActividadId);

                actividad.Plazas--;

                Matricula matricula = new Matricula();
                matricula.Alumno = alumno;
                matricula.Actividad = actividad;
                _db.Add(matricula);

                await _db.SaveChangesAsync();
                return RedirectToAction("AllActividades", "Actividad");
            }
        }
        private bool Comprueba(int actId, int aluId)
        {
            var matricula = _db.Matriculas.Include(c => c.Alumno).Include(c => c.Actividad).Where(c => c.Actividad.ActividadId == actId && c.Alumno.AlumnoId == aluId).FirstOrDefault();
            bool located = (matricula != null);
            return located;
        }

        public async Task<IActionResult> InscribedAlumno(int? id)
        {
            var matricula = await _db.Matriculas.Where(e => e.Actividad.ActividadId == id).Include(e => e.Actividad).Include(e => e.Alumno).ToListAsync();

            List<Alumno> inscribed = new List<Alumno>();
            foreach (var m in matricula)
            {
                var alumno = await _db.Alumnos.SingleOrDefaultAsync(s => s.AlumnoId == m.Alumno.AlumnoId);
                inscribed.Add(alumno);
            }

            ViewData["Actividad"] = _db.Actividades.Find(id).Nombre;
            return View(inscribed);
        }
    }
}
