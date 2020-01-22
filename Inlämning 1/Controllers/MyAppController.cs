using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json; // Convert objects to Json for session variable
using Inlämning_1.Models;
using Microsoft.AspNetCore.Http;

/// <summary>
/// Things to do:
/// 1. (Klart?) Ändra grundraouting 
/// 2. Skicka data: manipulera/uppdatera/beräkna i controller, mata in/interagera med i views, möjligtvis spara/hämta i model (utan databaskoppling).
/// 3. Spara data med sessionsvariabel och/eller cookies
/// 4. skicka data med ViewBag
/// 5. skicka data med ViewData
/// 6. (Klar, se Index nedan) Skicka data genom "return View(model_instans)" i controller
/// 7. (klart?) Någon slags partial i minst två views 
/// 8. tre olika typer av inmatning (textbox, dropdownlist, radiobuttons osv..)
/// 9. enkel validering av en eller flera inputfält.
/// </summary>
public class MyAppController : Controller {
    
    [HttpGet]
    public IActionResult Index() {
        MoviesModel mm = new MoviesModel();

        //set a session variable
        string str = JsonConvert.SerializeObject(mm);
        HttpContext.Session.SetString("test1", str);


        return View(mm);
    }

    [HttpPost]
    public IActionResult Purchase() {
        //do stuff depending on value from index
        return View();
    }

    public IActionResult Grade() {
        return View();
    }

    public IActionResult GradeRespons() {
        return View();
    }

    
}



