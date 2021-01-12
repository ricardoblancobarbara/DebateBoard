using DebateBoard.Data;
using DebateBoard.Models;
using DebateBoard.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DebateBoard.Controllers
{
    [Authorize]
    public class ArticleController : Controller
    {
        // GET: Article/Index
        public ActionResult Index()
        {
            var service = CreateArticleService();
            var model = service.GetArticles();
            return View(model);
        }

        // GET: Article/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Article/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticleCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateArticleService();
            if (service.CreateArticle(model))
            {
                TempData["SaveResult"] = "Your article was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Article could not be created.");
            return View(model);
        }

        // GET: Article/Details/{id}
        public ActionResult Details(int id)
        {
            var service = CreateArticleService();
            var model = service.GetArticleById(id);
            return View(model);
        }

        // GET: Article/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateArticleService();
            var detail = service.GetArticleById(id);
            var model =
                new ArticleEdit
                {
                    ArticleId = detail.ArticleId,
                    Title = detail.Title,
                    Content = detail.Content
                };
            return View(model);
        }

        // POST: Article/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ArticleEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.ArticleId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateArticleService();
            if (service.UpdateArticle(model))
            {
                TempData["SaveResult"] = "Your article was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your article could not be updated.");
            return View(model);
        }

        // GET: Article/Delete/{id}
        public ActionResult Delete(int id)
        {
            var service = CreateArticleService();
            var model = service.GetArticleById(id);
            return View(model);
        }
        // POST: Article/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateArticleService();
            service.DeleteArticle(id);
            TempData["SaveResult"] = "Your article was deleted";
            return RedirectToAction("Index");
        }

        private ArticleService CreateArticleService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ArticleService(userId);
            return service;
        }
        



    }
}