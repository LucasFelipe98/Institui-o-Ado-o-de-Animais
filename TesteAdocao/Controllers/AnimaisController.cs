using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TesteAdocao.Models;

namespace TesteAdocao.Controllers
{
    public class AnimaisController : Controller
    {
        private TesteAdocaoContext db = new TesteAdocaoContext();
        private static int? idanimal;
        private static int? idCategoria;
        // GET: Animals
        public ActionResult Index()
        {
            var animals = db.Animals.Include(a => a.Categoria);
            return View(animals.ToList());
        }

        public ActionResult AnimalPorCategoria(int id)
        {
            var animals = db.Animals.Include(a => a.Categoria).Where(x => x.CategoriaId == id);
            return View(animals.ToList());
        }

        // GET: Animals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // GET: Animals/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "CategoriaNome");
            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnimalId,AnimalNome,AnimalDescricao,AnimalCor,AnimalRaca,AnimalImagem,CategoriaId")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Animals.Add(animal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "CategoriaNome", animal.CategoriaId);
            return View(animal);
        }

        // GET: Animals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "CategoriaNome", animal.CategoriaId);
            return View(animal);
        }

        // POST: Animals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnimalId,AnimalNome,AnimalDescricao,AnimalCor,AnimalRaca,AnimalImagem,CategoriaId")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "CategoriaNome", animal.CategoriaId);
            return View(animal);
        }

        // GET: Animals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Animal animal = db.Animals.Find(id);
            db.Animals.Remove(animal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FileUpload()
        {
            if (Session["LoginAdministrador"] == null)
            {
                return RedirectToAction("Login", "Instituicao");
            }
            else
            {
                int arquivosSalvos = 0;
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFileBase arquivo = Request.Files[i];

                    //Suas validações ......

                    //Salva o arquivo
                    if (arquivo.ContentLength > 0)
                    {
                        var uploadPath = Server.MapPath("~/Content/Uploads");
                        string caminhoArquivo = Path.Combine(@uploadPath, Path.GetFileName(arquivo.FileName));

                        arquivo.SaveAs(caminhoArquivo);
                        arquivosSalvos++;
                    }
                }

                ViewData["Message"] = String.Format("{0} arquivo(s) salvo(s) com sucesso.",
                    arquivosSalvos);
                return View("Upload");
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
