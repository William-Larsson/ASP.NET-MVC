using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json; // Convert objects to Json for session variable
using Inlämning_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

/// <summary>
/// This is the controller class for the application, following
/// the ASP.NET MVC program structure.
/// </summary>
public class MyAppController : Controller {

    readonly List<SelectListItem> GradeList = new List<SelectListItem>() {
        new SelectListItem { Text = "Väldigt nöjd", Value = "0" },
        new SelectListItem { Text = "Mycket nöjd", Value = "1" },
        new SelectListItem { Text = "Nöjd", Value = "2" },
        new SelectListItem { Text = "Missnöjd", Value = "3" },
        new SelectListItem { Text = "Mycket missnöjd", Value = "4" }
    };


    [HttpGet]
    public IActionResult Index() {
        MoviesModel mm = new MoviesModel();
        //set a session variable
        string str = JsonConvert.SerializeObject(mm);
        HttpContext.Session.SetString("MoviesModel", str);

        List<SelectListItem> Movies = new List<SelectListItem> {
            new SelectListItem("Inception", "Inception"),
            new SelectListItem("Frozen", "Frozen"),
            new SelectListItem("Life of Brian", "Life of Brian"),
            new SelectListItem("Liar Liar", "Liar liar"),
            new SelectListItem("Die Hard 2", "Die Hard 2"),
            new SelectListItem("Batman Begins", "Batman Begins")
        };

        ViewData["moviesInList"] = Movies;
        return View(mm);
    }


    [HttpPost]
    public IActionResult Purchase(IFormCollection Collection) {
        string str = HttpContext.Session.GetString("MoviesModel");
        MoviesModel mm = JsonConvert.DeserializeObject<MoviesModel>(str);
        mm.Name = Collection["Name"];
        mm.Movie = Collection["MoviesList"]; // Idk if this will work...
        mm.Tickets = int.Parse(Collection["Tickets"]);
        mm.Popcorn = Convert.ToBoolean(Collection["Popcorn"].ToString().Split(',')[0]);

        return View(mm);
    }


    [HttpGet]
    public IActionResult Grade() {
        ViewBag.GradeList = GradeList;
        return View();
    }


    [HttpPost]
    public IActionResult GradeRespons(IFormCollection Collection) {
        int GradeValue = Convert.ToInt32(Collection["Grade"]);
        string GradeText = GradeList[GradeValue].Text;
        GradeModel gm = new GradeModel(GradeValue, GradeText);

        ViewBag.FirstRespons = gm.GetFirstLineRespons();
        ViewBag.SecondRespons = gm.GetSecondLineRespons();

        return View();
    }
}



