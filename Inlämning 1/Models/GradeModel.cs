using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlämning_1.Models {
    /// <summary>
    /// A model class for building a resons based 
    /// on user input from the view.
    /// </summary>
    public class GradeModel {

        public int value;
        public string text;

        public GradeModel(int value, string text) {
            this.value = value;
            this.text = text.ToLower();
        }

        public string GetFirstLineRespons() {
            string emotion;

            if (value <= 2) {
                emotion = "glada";
            } else emotion = "ledsna";

            return "Vi blir " + emotion +
                " att höra att du är " + text + ".";
        }

        public string GetSecondLineRespons() {
            return "Ditt betyg betyder mycket för oss och " +
                "vi strävar alltid efter att förbättra " +
                "vår tjänst.";
        }

    }
}
