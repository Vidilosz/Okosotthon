using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public abstract class OkosEszkoz
    {
        public string Azonosito { get; private set; }
        public string Nev { get; private set; }
        public bool OnlineE { get; private set; }
        public DateTime UtolsoFrissites { get; protected set; }

        public OkosEszkoz(string azonosito, string nev)
        {
            this.Azonosito = azonosito;
            this.Nev = nev;
            this.OnlineE = false;
            this.UtolsoFrissites = DateTime.Now;
        }

        public void Csatlakozas()
        {
            this.OnlineE = true;
            this.UtolsoFrissites = DateTime.Now;
        }

        public void KapcsolatBontasa()
        {
            this.OnlineE = false;
            this.UtolsoFrissites = DateTime.Now;
        }

        public bool DiagnosztikaFuttatasa()
        {
            if (!this.OnlineE)
            {
                return false;
            }

            return this.OnTesztFuttatasa();
        }

        public virtual void GyariBeallitasokVisszaallitasa()
        {
            this.OnlineE = false;
            this.UtolsoFrissites = DateTime.Now;
        }

        public abstract void ParancsVegrehajtasa(string parancs);
        public abstract string AllapotJelentes();
        protected abstract bool OnTesztFuttatasa();
    }
}
