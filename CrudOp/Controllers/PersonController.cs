using Microsoft.AspNetCore.Mvc;
using CrudOp.Models;
using System.Linq;

namespace CrudOp.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Person
        public IActionResult Index()
        {
            return View(_context.People.ToList());
        }

        // GET: Person/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                _context.People.Add(person);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // GET: Person/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var person = _context.People.Find(id);
            if (person == null) return NotFound();

            return View(person);
        }

        // POST: Person/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Update(person);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // GET: Person/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var person = _context.People.Find(id);
            if (person == null) return NotFound();

            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var person = _context.People.Find(id);
            if (person != null)
            {
                _context.People.Remove(person);
                _context.SaveChanges();
            }

            return RedirectToAction("Index"); // Redirects to Person List (Index.cshtml)
        }
    }
}
