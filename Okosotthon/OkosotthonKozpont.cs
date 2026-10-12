using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class OkosotthonKozpont
    {
        private readonly List<OkosEszkoz> eszkozok = new List<OkosEszkoz>();

        public void EszkozHozzaadasa(OkosEszkoz eszkoz)
        {
            if (eszkoz != null)
            {
                this.eszkozok.Add(eszkoz);
            }
        }

        public void OsszesCsatlakoztatasa()
        {
            foreach (var eszkoz in this.eszkozok)
            {
                eszkoz.Csatlakozas();
            }
        }

        public int RendszerDiagnosztikaFuttatasa()
        {
            int sikeresTesztek = 0;
            foreach (var eszkoz in this.eszkozok)
            {
                if (eszkoz.DiagnosztikaFuttatasa())
                {
                    sikeresTesztek++;
                }
            }
            return sikeresTesztek;
        }
    }
}
