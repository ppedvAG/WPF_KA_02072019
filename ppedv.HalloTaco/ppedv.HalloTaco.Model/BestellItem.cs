namespace ppedv.HalloTaco.Model
{
    public class BestellItem : Entity
    {
        public virtual Bestellung Bestellung { get; set; }
        public virtual Artikel Artikel { get; set; }
        public int Menge { get; set; } = 1;
    }
}
