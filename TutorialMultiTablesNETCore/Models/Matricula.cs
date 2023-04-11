namespace TutorialMultiTablesNETCore.Models
{
    public class Matricula
    {
        public int MatriculaId { get; set; }
        public int AlumnoId { get; set; }
        public int ActividadId { get; set; }
        public Alumno Alumno { get; set; }
        public Actividad Actividad { get; set; }
    }
}
