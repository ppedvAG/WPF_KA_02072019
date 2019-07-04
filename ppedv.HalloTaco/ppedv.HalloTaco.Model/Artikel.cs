using System.Collections.Generic;

namespace ppedv.HalloTaco.Model
{
    public class Artikel : Entity
    {
        public string Name { get; set; }
        public decimal Preis { get; set; }
        public virtual HashSet<BestellItem> Items { get; set; } = new HashSet<BestellItem>();

    }
}
