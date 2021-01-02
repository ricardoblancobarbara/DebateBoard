using DebateBoard.Models;
using DebateBoard.Services;
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
            var service = new ArticleService();
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
            if (ModelState.IsValid)
            {
                var service = new ArticleService();
                service.CreateArticle(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Article/Details/{id}
        public ActionResult Details(int id)
        {
            var service = new ArticleService();
            var model = service.GetArticleById(id);
            return View(model);
        }


    }
}