using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class NoteController : Controller
    {
        private const string AdminRolesString = RoleNames.Admins + "," + RoleNames.SuperAdmins;

        public ActionResult Index()
        {
            ICollection<Note> model = Repo.Notes;
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create([Bind(Include = "Text")] Note note)
        {
            note.Id = Guid.NewGuid();
            note.Author = User.Identity.Name;

            Repo.Notes.Add(note);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = AdminRolesString)]
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            Note note = Repo.Notes.FirstOrDefault(n => n.Id == id);
            if (note == null)
            {
                return HttpNotFound();
            }

            Repo.Notes.Remove(note);
            return RedirectToAction("Index", "Note");
        }
    }
}