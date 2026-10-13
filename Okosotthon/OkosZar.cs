using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class OkosZar : OkosEszkoz, IHangjelzo, IStatisztika
    {
        public bool ZartE { get; private set; } = true;
        private string pinKod;

        public OkosZar(string azonosito, string nev, string pinKod)
            : base(azonosito, nev)
        {
            this.pinKod = pinKod;
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            if (parancs == null) return;

            if (parancs.StartsWith("NYITAS:"))
            {
                string megadottPin = parancs.Substring("NYITAS:".Length);
                if (megadottPin == this.pinKod)
                {
                    this.ZartE = false;
                    this.UtolsoFrissites = DateTime.Now;
                }
            }
            else if (parancs == "ZARAS")
            {
                this.ZartE = true;
                this.UtolsoFrissites = DateTime.Now;
            }
        }

        public override string AllapotJelentes()
        {
            string allapot = this.ZartE ? "ZÁRVA" : "NYITVA";
            return $"Okoszár [{Nev}] (ID: {Azonosito}) - Állapot: {allapot}";
        }

        protected override bool OnTesztFuttatasa()
        {
            return true;
        }

        public override void GyariBeallitasokVisszaallitasa()
        {
            base.GyariBeallitasokVisszaallitasa();
            this.pinKod = "0000";
            this.ZartE = true;
        }

        public void Csipog(int hosszu)
        {
            Console.Beep(12000,hosszu);

        }

        public void VeszjelzesInditasa()
        {
            Console.Beep(12000, 1000);
            Console.Beep(15000, 3000);
            Console.Beep(13000, 1000);
        }

        public string StatisztikatKeszit()
        {
            return $"Okoszár [{Nev}] (ID: {Azonosito}) - Állapot: {(ZartE ? "ZÁRVA" : "NYITVA")}, Utolsó frissítés: {UtolsoFrissites}";
        }
    }
}
