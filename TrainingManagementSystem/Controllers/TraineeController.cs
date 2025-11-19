using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainingManagementSystem.Models;

using TrainingManagementSystem.ViewModels.TraineeViewModels;

namespace TrainingManagementSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TraineeController : Controller
    {
        private readonly ITraineeServices _traineeServices;
        private readonly IDepartmentServices _departmentServices;
        private readonly ICourseServices _courseServices;

        public TraineeController(ITraineeServices traineeServices
            , IDepartmentServices departmentServices
            , ICourseServices courseServices)
        {
            _traineeServices = traineeServices;
            _departmentServices = departmentServices;
            _courseServices = courseServices;
        }

        public IActionResult Index()
        {
            var trainees = _traineeServices.GetAll().ToList();
            return View(nameof(Index), trainees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var departments = _departmentServices.GetAll()
                .Select(d => new SelectListItem
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                }).ToList();

            var courses = _courseServices.GetAll()
                .Select(d => new SelectListItem
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                }).ToList();

            var model = new CreateTraineeFormViewModel
            {
                Departments = departments,
                Courses = courses  
            };

            return View(nameof(Create), model);
        }

        [HttpPost]
        public IActionResult Create(CreateTraineeFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Create), model);
            }

            var trainee = new Trainee
            {
                Name = model.Name,
                Address = model.Address,
                Grade = model.Grade,
                DeptId = model.SelectedDepartment,
                CrsReslts = model.SelectedCourses?.Select(courseId => new CrsReslt
                {

                    CrsId = courseId,
                    Degree = null,
                    IsPassed = null,
                    DateCompleted = null
                }).ToList()

            };

            _traineeServices.Add(trainee);
            return RedirectToAction(nameof(Index));
        }

      
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var trainee = _traineeServices.GetByIdWithDetails(id);
            if (trainee == null)
                return NotFound();

            var departments = _departmentServices.GetAll()
                .Select(d => new SelectListItem
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                }).ToList();

           

            var courses = _courseServices.GetAll()
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString(),
                    Selected = trainee.CrsReslts.Any(cr => cr.CrsId == c.Id)
                }).ToList();


            var viewModel = new EditTraineeFormViewModel
            {
                Id = trainee.Id,
                Name = trainee.Name,
                Address = trainee.Address,
                Grade = trainee.Grade,
                SelectedDepartment = trainee.DeptId,
                Departments = departments,
                Courses = courses,
                SelectedCourses = trainee.CrsReslts?.Select(Cr => Cr.CrsId).ToList() ?? new List<int>()



            };

            return View(nameof(Edit), viewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditTraineeFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(nameof(Edit), viewModel);

            var trainee = new Trainee
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Address = viewModel.Address,
                Grade = viewModel.Grade,
                DeptId = viewModel.SelectedDepartment,
                 CrsReslts = viewModel.SelectedCourses?
              .Select(id => new CrsReslt { CrsId = id , TraineeId = viewModel.Id })
              .ToList()



            };

            _traineeServices.Update(trainee);
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


            _traineeServices.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var traineeWithDetails = _traineeServices.GetByIdWithDetails(id);

            if (traineeWithDetails == null)
                return NotFound();

            var viewModel = new TraineeWithDetails
            {
                Id = traineeWithDetails.Id,
                Name = traineeWithDetails.Name,
                Address = traineeWithDetails.Address,
                Grade = traineeWithDetails.Grade,
                SelectedDepartment = traineeWithDetails.DeptId,
                DepartmentName = traineeWithDetails.Department?.Name ?? "No Department",

                CrsResults = traineeWithDetails.CrsReslts?
                    .Select(r => new CrsResultsViewModel
                    {
                        CourseId = r.Course.Id,
                        CourseName = r.Course?.Name ?? "Unknown Course",
                        CourseDegree = r.Course.Degree,
                        CourseMinDegree = r.Course.MinDegree,
                        TraineeDegree = r.Degree,

                        IsPassed = r.Degree == null
                            ? (bool?)null  
                            : r.Degree >= r.Course.MinDegree,

                        DateCompleted = r.Degree == null
                            ? (DateTime?)null
                            : (r.Degree >= r.Course.MinDegree ? DateTime.Now : (DateTime?)null)
                    }).ToList() ?? new List<CrsResultsViewModel>()
            };

            return View(viewModel);
        }

    }
}
