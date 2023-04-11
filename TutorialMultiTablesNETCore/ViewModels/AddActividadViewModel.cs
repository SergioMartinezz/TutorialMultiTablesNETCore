using Microsoft.AspNetCore.Mvc.Rendering;
using TutorialMultiTablesNETCore.Models;

namespace TutorialMultiTablesNETCore.ViewModels
{
    public class AddActividadViewModel
    {
        public Instructor Instructor { get; set; }
        public Actividad Actividad { get; set; }
        public SelectList ListaActividades { get; set; }
    }
}
