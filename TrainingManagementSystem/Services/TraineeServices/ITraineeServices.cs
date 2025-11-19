namespace TrainingManagementSystem.Services.TraineeServices
{
    public interface ITraineeServices
    {
        IEnumerable<Trainee> GetAll();
        Trainee GetById(int id);
        void Add(Trainee trainee);
        void Update(Trainee trainee);
        void DeleteById(int id);
        public Trainee GetByIdWithDetails(int id);

       
    }
}





