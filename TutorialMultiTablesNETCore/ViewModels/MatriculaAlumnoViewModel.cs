using Microsoft.AspNetCore.Mvc.Rendering;
using TutorialMultiTablesNETCore.Models;

namespace TutorialMultiTablesNETCore.ViewModels
{
    public class MatriculaAlumnoViewModel
    {
        public Matricula Matricula { get; set; }
        public SelectList ListaAlumnos { get; set; }
    }
}
