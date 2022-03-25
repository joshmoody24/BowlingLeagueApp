using BowlingLeagueApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeagueApp.Controllers
{
    public class HomeController : Controller
    {

        private IBowlingRepository _repo { get; set; }

        public HomeController(IBowlingRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            List<Bowler> bowlers = _repo.Bowlers.Include(b => b.Team).ToList<Bowler>();
            return View(bowlers);
        }

        [HttpGet]
        public IActionResult CreateBowler()
        {
            ViewBag.Teams = _repo.Teams.ToList();
            ViewBag.EditMode = false;
            return View("BowlerForm", new Bowler());
        }

        [HttpPost]
        public IActionResult CreateBowler(Bowler bowler)
        {
            if (ModelState.IsValid)
            {
                _repo.AddBowler(bowler);
                return RedirectToAction("Index");
            }
            else return View(bowler);
        }

        [HttpGet]
        public IActionResult EditBowler(int id)
        {
            ViewBag.Teams = _repo.Teams.ToList();
            ViewBag.EditMode = true;
            Bowler bowler = _repo.Bowlers.Include(b => b.Team).FirstOrDefault(b => b.BowlerID == id);
            return View("BowlerForm", bowler);
        }

        [HttpPost]
        public IActionResult EditBowler(Bowler bowler)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateBowler(bowler);
                return RedirectToAction("Index");
            }
            else return View(bowler);
        }

        public IActionResult DeleteConfirmation(int id)
        {
            Bowler bowler = _repo.Bowlers.FirstOrDefault(b => b.BowlerID == id);
            if (bowler != null) return View(bowler);
            else return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteConfirmation(Bowler bowler)
        {
            if (bowler != null) _repo.RemoveBowler(bowler);
            return RedirectToAction("Index");
        }
    }
}
