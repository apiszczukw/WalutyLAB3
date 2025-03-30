using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalutyLAB3.Klasy
{
    public class PozycjaTabA
    {
        public string NazwaWaluty { get; set; }

        public string Przelicznik { get; set; }

        public string KodWaluty { get; set; }

        public string KursSredni { get; set; }

        public decimal Kurs { get
            {
                decimal kurs;
                string separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

                decimal.TryParse(KursSredni.Replace(",", separator), out kurs);

                return kurs;
            }
                }
    }
}
