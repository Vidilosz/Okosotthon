namespace Okosotthon
{
    public class Program
    {
        static void Main(string[] args)
        {
            OkosotthonKozpont kozpont = new OkosotthonKozpont();

            Termosztat termosztat = new Termosztat("TERM_01", "Nappali Termosztát", 22.5);
            OkosZar zar = new OkosZar("ZAR_01", "Bejárati Ajtó", "1234");

            kozpont.EszkozHozzaadasa(termosztat);
            kozpont.EszkozHozzaadasa(zar);

            // Offline állapotban a diagnosztika 0 sikeres tesztet ad
            Console.WriteLine($"Diagnosztika csatlakozás előtt: {kozpont.RendszerDiagnosztikaFuttatasa()} sikeres.");

            // Eszközök csatlakoztatása a hálózathoz
            kozpont.OsszesCsatlakoztatasa();
            Console.WriteLine($"Diagnosztika csatlakozás után: {kozpont.RendszerDiagnosztikaFuttatasa()} sikeres.");

            // Parancsok végrehajtása
            termosztat.ParancsVegrehajtasa("BEALLIT_HOMERSEKLET:24.0");
            zar.ParancsVegrehajtasa("NYITAS:1234");

            Console.WriteLine(termosztat.AllapotJelentes());
            Console.WriteLine(zar.AllapotJelentes());
        }
    }
}
