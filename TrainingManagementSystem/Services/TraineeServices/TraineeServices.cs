namespace TrainingManagementSystem.Services.TraineeServices
{
   
        public class TraineeServices : ITraineeServices
        {
            private readonly IRepository<Trainee> _repo;

            public TraineeServices(IRepository<Trainee> repo)
            {
                _repo = repo;
            }
        public void Add(Trainee trainee)
        {
                _repo.Add(trainee);
                _repo.Save();
            
        }

            public void DeleteById(int id)
            {
                Trainee trainee = _repo.GetById(id);
                if (trainee == null)
                {
                    throw new Exception($"Trainee with Id = {id} was not found.");
                }
                _repo.Delete(trainee);
                _repo.Save();
            }

            public IEnumerable<Trainee> GetAll()
            {
                return _repo.GetAll();
            }

            public Trainee GetById(int id)
            {
                Trainee trainee = _repo.GetById(id);
                if (trainee == null)
                {
                    throw new Exception($"Trainee with Id = {id} was not found.");
                }
                return trainee;

            }

            public void Update(Trainee trainee)
            {
                Trainee existing = _repo.GetById(trainee.Id);
                if (existing == null)
                {
                    throw new Exception($"Trainee with Id = {trainee.Id} was not found.");
                }

                existing.Id = trainee.Id;
                existing.Name = trainee.Name;
                existing.Address = trainee.Address;
                existing.Grade = trainee.Grade;
                existing.DeptId = trainee.DeptId;
               

                _repo.Update(existing);
                _repo.Save();

            }

            public Trainee GetByIdWithDetails(int id)
            {
                var set = _repo.Set();
                return set.Include(t => t.Department).Include(t => t.CrsReslts).ThenInclude(cr => cr.Course).FirstOrDefault(c => c.Id == id);
            }

     


    }
}




   

