namespace TrainingManagementSystem.Models
{
    public class CrsReslt
    {
        public int Id { get; set; }
        public int? Degree { get; set; }

        public int CrsId { get; set; }
        public int TraineeId { get; set; }

        public bool? IsPassed { get; set; }

        public DateTime? DateCompleted { get; set; }

        public virtual Course Course { get; set; }

        public virtual Trainee Trainee { get; set; }
    }
}
