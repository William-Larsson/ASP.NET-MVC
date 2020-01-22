using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Inlämning_1.Models {

    public class MoviesModel {

        [DisplayName("Ditt namn:")]
        [StringLength(40, ErrorMessage ="Namnet får maximalt innehålla 40 tecken.")]
        public string Name { get; set; }


        [DisplayName("Välj film:")]
        [Required(ErrorMessage = "* måste väljas.")]
        public List<SelectListItem> ListOfMovies { get; set; }


        [DisplayName("Antal biljetter:")]
        [Required(ErrorMessage = "* måste ifyllas.")]
        [Range(0, 10, ErrorMessage = "Du kan maximalt köpa 10 biljetter.")]
        public int Tickets { get; set; }


        [DisplayName("Vill du ha popcorn?")]
        [Required(ErrorMessage = "* måste väljas.")] /// eventuellt ta bort pga false i kontstruktor?
        public Boolean Popcorn { get; set; }

        public MoviesModel() {
            Name = "";
            Tickets = 0;
            Popcorn = false;
            ListOfMovies = new List<SelectListItem> {
                new SelectListItem("Inception", "Inception"),
                new SelectListItem("Frozen", "Frozen"),
                new SelectListItem("Life of Brian", "Life of Brian"),
                new SelectListItem("Liar Liar", "Liar liar"),
                new SelectListItem("Die Hard 2", "Die Hard 2")
            };
        }
    }
}
