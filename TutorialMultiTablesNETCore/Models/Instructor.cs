namespace TutorialMultiTablesNETCore.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string Nombre { get; set; }
        public Actividad Actividad { get; set; }
    }
}
