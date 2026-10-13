using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    internal class OkosKozpontiRiaszto : OkosEszkoz, IHangjelzo, IIdozitheto, IStatisztika
    {
        public OkosKozpontiRiaszto(string azonosito, string nev) : base(azonosito, nev)
        {
        }

        public override string AllapotJelentes()
        {
            throw new NotImplementedException();
        }

        public void Csipog(int hosszu)
        {
            throw new NotImplementedException();
        }

        public int GetMaradtIdo()
        {
            throw new NotImplementedException();
        }

        public void IdozitestBeallit(int perc)
        {
            throw new NotImplementedException();
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            throw new NotImplementedException();
        }

        public string StatisztikatKeszit()
        {
            throw new NotImplementedException();
        }

        public void VeszjelzesInditasa()
        {
            throw new NotImplementedException();
        }

        protected override bool OnTesztFuttatasa()
        {
            throw new NotImplementedException();
        }
    }
}
