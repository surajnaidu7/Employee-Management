using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeRepository repository = new EmployeeRepository();

        public ActionResult Index()
        {
            var employees = repository.GetAllEmployees();
            return View(employees);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                repository.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public ActionResult Edit(int id)
        {
            var employee = repository.GetEmployeeById(id);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public ActionResult Delete(int id)
        {
            var employee = repository.GetEmployeeById(id);
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repository.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var employee = repository.GetEmployeeById(id);
            return View(employee);
        }
    }
}