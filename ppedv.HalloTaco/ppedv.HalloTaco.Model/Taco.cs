namespace ppedv.HalloTaco.Model
{
    public class Taco : Artikel
    {
        public bool IstWeich { get; set; }
        public Fleischart Fleischart { get; set; }
        public Tortillaart Tortillaart { get; set; }
        public Größe Größe { get; set; }
    }

    public enum Größe
    {
        Groß,
        Klein
    }
    public enum Tortillaart
    {
        Weize,
        Mais,
        Pappe
    }

    public enum Fleischart
    {
        Vegetarisch,
        Rind,
        Huhn,
        Schwein,
        Pferd,
        Kalb,
        Katze
    }
}
