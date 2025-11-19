
using Microsoft.AspNetCore.Authorization;

namespace TrainingManagementSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices _departmentServices;
        private readonly IInstructorServices _instructorServices;
        private readonly ICourseServices _courseServices;
        private readonly ITraineeServices _traineeServices;

        public DepartmentController(IDepartmentServices departmentServices
            ,IInstructorServices instructorServices
            ,ICourseServices courseServices
            ,ITraineeServices traineeServices
            )
        {
            _departmentServices = departmentServices;
            _instructorServices = instructorServices;
            _courseServices = courseServices;
            _traineeServices = traineeServices;
        }

        public IActionResult Index()
        {
            List<Department> departments = _departmentServices.GetAll().ToList(); 
            return View(nameof(Index),departments);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View(nameof(Create));
        
        }
        [HttpPost]
        public IActionResult Create(CreateDepartmentFormViewModel model)
        {
            if (!ModelState.IsValid) 
            {
                return View(nameof(Create),model);
            }
            Department department = new()
            {
               Name = model.Name,
               ManagerName = model.ManagerName

            };
            _departmentServices.Add(department);
            return RedirectToAction(nameof(Index));
        
        }

        [HttpGet]
        public IActionResult Delete(int id) {
        
            return View(id);
        }
        [HttpPost]
        public IActionResult ConfirmDelete(int id) {
        
            
            _departmentServices.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id) {
            // Get Department
            Department department = _departmentServices.GetById(id);


            // Mapping
            EditDepartmentFormViewModel ViewModel = new EditDepartmentFormViewModel();
            ViewModel.Id = id;
            ViewModel.Name = department.Name;
            ViewModel.ManagerName = department.ManagerName;

            //return view
            return View(nameof(Edit), ViewModel);
        }
        [HttpPost]
        public IActionResult Edit(EditDepartmentFormViewModel viewModel) {
            if (!ModelState.IsValid)
            {
              return View(nameof(Edit), viewModel);

            }
            Department department = new()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                ManagerName = viewModel.ManagerName

            };
            _departmentServices.Update(department);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var department = _departmentServices.GetByIdWithDetails(id);

            if (department == null)
                return NotFound();

            var viewModel = new DepartmentWithDetails
            {
                Id = department.Id,
                Name = department.Name,
                ManagerName = department.ManagerName,

                Courses = department.Courses?.Select(c => new DepartmentCourseViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList() ?? new List<DepartmentCourseViewModel>(),

                Instructors = department.Instructors?.Select(i => new DepartmentInstructorViewModel
                {
                    Id = i.Id,
                    Name = i.Name
                }).ToList() ?? new List<DepartmentInstructorViewModel>(),

                Trainees = department.Trainees?.Select(t => new DepartmentTraineeViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToList() ?? new List<DepartmentTraineeViewModel>()
            };

            return View(viewModel);
        }





        [AcceptVerbs("Get", "Post")]
        public IActionResult IsNameUnique(string name, int id)
        {
            bool exists = _departmentServices.GetAll()
                .Any(d => d.Name.ToLower() == name.ToLower() && d.Id != id);

            if (exists)
            {
                return Json($"The name '{name}' is already taken.");
            }

            return Json(true);
        }


    }
}
