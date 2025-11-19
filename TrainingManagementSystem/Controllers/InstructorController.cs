using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingManagementSystem.Models;
using TrainingManagementSystem.ViewModels.InstructorViewModels;
using TrainingManagementSystem.ViewModels.TraineeViewModels;

namespace TrainingManagementSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class InstructorController : Controller
    {
        
        private readonly IInstructorServices _instructorServices;
        private readonly IDepartmentServices _departmentServices;
         private readonly ICourseServices _courseServices;

        public InstructorController(IInstructorServices instructorServices,
            IDepartmentServices departmentServices ,
            ICourseServices courseServices ) 
        {
            _instructorServices = instructorServices;
            _departmentServices = departmentServices;
            _courseServices = courseServices;

        }

        public IActionResult Index()
        {
            List<Instructor> instructors = _instructorServices.GetAll().ToList();
            return View(nameof(Index), instructors);
        }

        public IActionResult Create()
        {
            var departments = _departmentServices.GetAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString(),

            }
            )
            .ToList();
            var courses = _courseServices.GetAll().Select(i => new SelectListItem
            {
              Text = i.Name,
               Value = i.Id.ToString(),

            }
            )
            .ToList();
            CreateInstructorFormViewModel model = new CreateInstructorFormViewModel()
            {
                Departments = departments,

                Courses = courses

            };

            return View(nameof(Create), model);

        }


        [HttpPost]
        public IActionResult Create(CreateInstructorFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Create), model);
            }
            Instructor instructor = new()
            {
                Id = model.Id,
                Name = model.Name,
                Address = model.Address,
                Salary= model.Salary,
                DeptId = model.SelectedDepartment,
                CourseId = model.SelectedCourse

            };
            _instructorServices.Add(instructor);
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


            _instructorServices.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            
            Instructor instructor = _instructorServices.GetById(id);

            var departments = _departmentServices.GetAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            }
            )
            .ToList();

            var courses = _courseServices.GetAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            }
            )
            .ToList();

            // Mapping
            EditInstructorFormViewModel viewModel = new EditInstructorFormViewModel()
            {

                Id = id,
                Name = instructor.Name,
                Address = instructor.Address,
                Salary = instructor.Salary,
                SelectedDepartment = instructor.DeptId,
                Departments = departments,
                SelectedCourse = instructor.CourseId,
                Courses = courses
                // viewModel.SelectedInst.... = course.;
                //viewModel.Instr.... = instr...;

            };

        

    
            //return view
            return View(nameof(Edit), viewModel);
        }
        [HttpPost]
        public IActionResult Edit(EditInstructorFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Edit), viewModel);

            }
            Instructor instructor  = new()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Address = viewModel.Address,
                Salary = viewModel.Salary,
                DeptId = viewModel.SelectedDepartment,
                CourseId = viewModel.SelectedCourse

            };
            _instructorServices.Update(instructor);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var instructor = _instructorServices.GetByIdWithDetails(id);

            if (instructor == null)
                return NotFound();

            var viewModel = new InstructorWithDetails
            {
                Id = instructor.Id,
                Name = instructor.Name,
                Salary = instructor.Salary,
                Address = instructor.Address,

                SelectedCourse = instructor.CourseId,
                courseName = instructor.Course?.Name ?? "N/A",

                SelectedDepartment = instructor.DeptId,
                DepartmentName = instructor.Department?.Name ?? "N/A"
            };

            return View(viewModel);
        }

    }
}
