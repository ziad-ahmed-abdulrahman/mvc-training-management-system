
using Microsoft.AspNetCore.Authorization;
using TrainingManagementSystem.Models;
using TrainingManagementSystem.Services.CourseServices;
using TrainingManagementSystem.Services.DepartmentServices;

namespace TrainingManagementSystem.Controllers
{

    [Authorize(Roles = "Admin")]
    public class CourseController : Controller
    {
        private readonly ICourseServices _courseServices;
        private readonly IDepartmentServices _departmentServices;
      

        public CourseController(ICourseServices courseServices,IDepartmentServices departmentServices)
        {
            _courseServices = courseServices;
            _departmentServices = departmentServices;
           
        }

        public IActionResult Index()
        {
            List<Course> courses = _courseServices.GetAll().ToList();
            return View(nameof(Index), courses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var departments = _departmentServices.GetAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString(),

            }
            )
            .ToList();
         
            CreateCourseFormViewModel model = new CreateCourseFormViewModel()
            {
                Departments = departments,
               

            };  
           
            return View(nameof(Create),model);

        }
        [HttpPost]
        public IActionResult Create(CreateCourseFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Create), model);
            }
            Course course = new()
            {
                Name = model.Name,
                Degree = model.Degree,
                MinDegree = model.MinDegree,
                Hours = model.Hours,
                DeptId = model.SelectedDepartment
            };
            _courseServices.Add(course);
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {

            return View(id);
        }
        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {


            _courseServices.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }
      
     
      
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Get course
            Course course = _courseServices.GetById(id);


            // Mapping
            EditCourseFormViewModel viewModel = new EditCourseFormViewModel();

            var departments = _departmentServices.GetAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString(),

            }
         )
         .ToList();

     

            viewModel.Id = id;
            viewModel.Name = course.Name;
            viewModel.Degree = course.Degree;
            viewModel.MinDegree = course.MinDegree;
            viewModel.Hours = course.Hours;
            viewModel.SelectedDepartment = course.DeptId;
            viewModel.Departments = departments;
            
           
            //return view
            return View(nameof(Edit), viewModel);
        }
        [HttpPost]
        public IActionResult Edit(EditCourseFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Edit), viewModel);

            }
            Course course = new()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Degree = viewModel.Degree,
                MinDegree = viewModel.MinDegree,
                Hours = viewModel.Hours,
                DeptId = viewModel.SelectedDepartment


            };
            _courseServices.Update(course);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var courseWithDetails = _courseServices.GetByIdWithDetails(id);

            if (courseWithDetails == null) {
            return NotFound();
            }

            CourseDetailsViewModel viewModel = new CourseDetailsViewModel()
            {
                Id = courseWithDetails.Id,
                Name = courseWithDetails.Name,
                Degree = courseWithDetails.Degree,
                MinDegree = courseWithDetails.MinDegree,
                Hours = courseWithDetails.Hours,
                SelectedDepartment = courseWithDetails.DeptId,
                DepartmentName = courseWithDetails.Department?.Name,
                Instructors = courseWithDetails.Instructors.Select(i => new InstructorInfoViewModel
                {
                    Id = i.Id,
                    Name = i.Name,

                }).ToList(),
            };

            return View(viewModel);
        }


        [AcceptVerbs("Get", "Post")]
        public IActionResult IsNameUnique(string name, int id)
        {
            bool exists = _courseServices.GetAll()
                .Any(d => d.Name.ToLower() == name.ToLower() && d.Id != id);

            if (exists)
            {
                return Json($"The name '{name}' is already taken.");
            }

            return Json(true);
        }


    }
}
