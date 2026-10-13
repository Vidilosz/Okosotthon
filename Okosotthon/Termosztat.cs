using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class Termosztat : OkosEszkoz,IIdozitheto, IStatisztika
    {
        private int idozito;
        public double JelenlegiHomerseklet { get; private set; } = 21.0;
        public double CelHomerseklet { get; private set; }

        public Termosztat(string azonosito, string nev, double celHomerseklet)
            : base(azonosito, nev)
        {
            this.CelHomerseklet = celHomerseklet;
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            if (parancs != null && parancs.StartsWith("BEALLIT_HOMERSEKLET:"))
            {
                string ertekResz = parancs.Substring("BEALLIT_HOMERSEKLET:".Length);
                if (double.TryParse(ertekResz, NumberStyles.Any, CultureInfo.InvariantCulture, out double ujCel))
                {
                    this.CelHomerseklet = ujCel;
                    this.UtolsoFrissites = DateTime.Now;
                }
            }
        }

        public override string AllapotJelentes()
        {
            return $"Termosztát [{Nev}] (ID: {Azonosito}) - Jelenlegi: {JelenlegiHomerseklet}°C, Cél: {CelHomerseklet}°C";
        }

        protected override bool OnTesztFuttatasa()
        {
            return this.CelHomerseklet >= 5.0 && this.CelHomerseklet <= 35.0;
        }

        public void IdozitestBeallit(int perc)
        {
            this.idozito=perc;
        }

        public int GetMaradtIdo()
        {
            return idozito;
        }

        public string StatisztikatKeszit()
        {
            return $"Termosztát [{Nev}] (ID: {Azonosito}) - Jelenlegi: {JelenlegiHomerseklet}°C, Cél: {CelHomerseklet}";
        }
    }
}
