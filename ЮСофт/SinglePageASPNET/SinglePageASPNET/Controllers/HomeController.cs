using Microsoft.AspNetCore.Mvc;
using SinglePageASPNET.Models;
using System.Linq;

namespace SinglePageASPNET.Controllers
{
    public class HomeController : Controller
    {
        Context db;
        IEnumerable<ForRowOvers> forRowOversList;
        public HomeController(Context context)
        {
            db = context;
            forRowOversList = db.ForOverRows;
        }
        public IActionResult Index()
        {
            ViewBag.MaxCount = 15;
            ViewBag.ThisPage = 0;
            ViewBag.MaxPages = (int)Math.Ceiling((double)this.forRowOversList.Count() / (double)ViewBag.MaxCount);
            return View(this.forRowOversList.ToList().GetRange(0, ViewBag.MaxCount));
        }

        public IActionResult LastTo(string _maxCount)
        {
            int newMaxCount = int.Parse(_maxCount);
            int maxLegnth = this.forRowOversList.Count();
            int maxCountList = ((int)Math.Ceiling(this.forRowOversList.Count() / (double)newMaxCount) - 1) * newMaxCount;
            var lastSegments = this.forRowOversList.ToList().GetRange(maxCountList, maxLegnth - maxCountList);
            ViewBag.ThisPage = (int)Math.Ceiling(this.forRowOversList.Count() / (double)newMaxCount)-1;
            ViewBag.MaxCount = maxLegnth - maxCountList;
            ViewBag.MaxPages = (int)Math.Ceiling(this.forRowOversList.Count() / (double)newMaxCount);
            ViewBag.PrevLast = newMaxCount;
            return View("Index", lastSegments);
        }
        public IActionResult FirstTo(string _maxCount)
        {

            int maxCount = int.Parse(_maxCount);
            var firstSegments = this.forRowOversList.Take<ForRowOvers>(maxCount);
            ViewBag.ThisPage = 0;
            ViewBag.MaxCount = maxCount;
            ViewBag.MaxPages = (int)Math.Ceiling((double)this.forRowOversList.Count() / (double)ViewBag.MaxCount);
            return View("Index", firstSegments);
        }
        public IActionResult NextTo(string _thisPage, string _maxCount)
        {
            int maxCount = int.Parse(_maxCount);
            int thisPage = int.Parse(_thisPage);
            
            int maxLegnth = this.forRowOversList.Count();
            int maxPages = (int)Math.Ceiling(this.forRowOversList.Count() / (double)maxCount);
            if (thisPage == maxPages)
            {
                int maxCountList = ((int)Math.Ceiling(this.forRowOversList.Count() / (double)maxCount) - 1) * maxCount;
                var nextSegmentss = this.forRowOversList.ToList().GetRange(maxCountList, maxLegnth - maxCountList);
                ViewBag.PrevLast = maxCount;
                ViewBag.MaxCount = maxLegnth - maxCountList;
                ViewBag.MaxPages = (int)Math.Ceiling(this.forRowOversList.Count() / (double)maxCount);
                ViewBag.ThisPage = thisPage;
                return View("Index", nextSegmentss);
            }
            ViewBag.ThisPage = thisPage + 1;
            
            List<ForRowOvers> nextSegments;
            if (thisPage == maxPages-2)
            {
                int maxCountList = ((int)Math.Ceiling(this.forRowOversList.Count() / (double)maxCount) - 1) * maxCount;
                nextSegments = this.forRowOversList.ToList().GetRange(maxCountList, maxLegnth - maxCountList);
                ViewBag.PrevLast = maxCount;
                ViewBag.MaxCount = maxLegnth - maxCountList;
            }
            else
            {
                nextSegments = this.forRowOversList.ToList().GetRange(maxCount * (thisPage + 1), maxCount);
                ViewBag.MaxCount = maxCount;
            }
            
            ViewBag.MaxPages = (int)Math.Ceiling(this.forRowOversList.Count() / (double)maxCount);
            return View("Index", nextSegments);
        }

        public IActionResult BackTo(string _thisPage, string _maxCount)
        {

            int maxCount = int.Parse(_maxCount);
            int thisPage = int.Parse(_thisPage);
            int maxPages = (int)Math.Ceiling(this.forRowOversList.Count() / (double)maxCount);
            List<ForRowOvers> backSegments;
            if (thisPage == 0)
            {
                ViewBag.ThisPage = thisPage < 1 ? 0 : thisPage - 1;
                backSegments = this.forRowOversList.ToList().GetRange(maxCount * (thisPage), maxCount);
                ViewBag.MaxCount = maxCount;
                ViewBag.MaxPages = maxPages;
                return View("Index", backSegments);
            }
            
            if (thisPage == maxPages)
            {
                ViewBag.ThisPage = thisPage - 1;
                backSegments = this.forRowOversList.ToList().GetRange(maxCount * (thisPage - 2), maxCount);
            }
            else if (thisPage<2)
            {
                ViewBag.ThisPage = thisPage < 1 ? 0 : thisPage - 1;
                backSegments = this.forRowOversList.ToList().GetRange(maxCount * (thisPage - 1), maxCount);
            }
            else   
            {
                ViewBag.ThisPage = thisPage < 1 ? 0 : thisPage - 1;
                backSegments = this.forRowOversList.ToList().GetRange(maxCount * (thisPage - 1), maxCount);
            }
            ViewBag.MaxCount = maxCount;
            ViewBag.MaxPages = maxPages;
            return View("Index", backSegments);
        }

        public IActionResult CountRows(string countRows, string _thisPage)
        {
            ViewBag.MaxCount = int.Parse(countRows);
            ViewBag.ThisPage = int.Parse(_thisPage);
            ViewBag.MaxPages = (int)Math.Ceiling((double)this.forRowOversList.Count() / (double)ViewBag.MaxCount);
            return View("Index", this.forRowOversList.ToList().GetRange(int.Parse(_thisPage)* int.Parse(countRows), int.Parse(countRows)));
        }
    }
}
