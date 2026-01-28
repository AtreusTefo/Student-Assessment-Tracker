using Microsoft.AspNetCore.Mvc;
using StudentAssessmentTracker.Data;
using StudentAssessmentTracker.Models;

namespace StudentAssessmentTracker.Controllers;

public class StudentsController : Controller
{
    private readonly ApplicationDbContext _context;

    public StudentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: /Students
    public IActionResult Index(string sortOrder)
    {
        var students = _context.Students.AsQueryable();

        switch (sortOrder)
        {
            case "fname":
                students = students.OrderBy(s => s.FirstName);
                break;
            case "lname":
                students = students.OrderBy(s => s.LastName);
                break;
            case "total":
                students = students.OrderByDescending(s => s.Total);
                break;
            case "percent":
                students = students.OrderByDescending(s => s.Percentage);
                break;
        }

        return View(students.ToList());
    }

    // GET: /Students/Create
    public IActionResult Create() => View();

    // POST: /Students/Create
    [HttpPost]
    public IActionResult Create(Student student)
    {
        if (ModelState.IsValid)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        return View(student);
    }

    // GET: /Students/Edit/5
    public IActionResult Edit(int id)
    {
        var student = _context.Students.Find(id);
        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }

    // POST: /Students/Edit/5
    [HttpPost]
    public IActionResult Edit(Student student)
    {
        if (student == null)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        return View(student);
    }

    // GET: /Students/Delete/5
    public IActionResult Delete(int id)
    {
        var student = _context.Students.Find(id);
        if (student != null)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }
}
