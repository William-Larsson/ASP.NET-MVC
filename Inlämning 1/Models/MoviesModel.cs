using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Inlämning_1.Models {

    /// <summary>
    /// A model that will store all the relevant information
    /// about going to the movies,
    /// </summary>
    public class MoviesModel {

        [DisplayName("Ditt namn:")]
        [StringLength(50, ErrorMessage ="Namnet får maximalt innehålla 50 tecken.")]
        public string Name { get; set; }


        [DisplayName("Film")]
        public string Movie { get; set; }


        [DisplayName("Antal biljetter:")]
        [Required(ErrorMessage = "* måste ifyllas.")]
        [Range(1, 10, ErrorMessage = "Du måste minst köpa en biljett, men inte fler än 10.")]
        public int Tickets { get; set; }


        [DisplayName("Vill du ha popcorn?")]
        [Required(ErrorMessage = "* måste väljas.")]
        public Boolean Popcorn { get; set; }

        /// <summary>
        /// Constructor, init values before using them
        /// in a view.
        /// </summary>
        public MoviesModel() {
            Name = "";
            Tickets = 0;
            Popcorn = false;
        }
    }
}
