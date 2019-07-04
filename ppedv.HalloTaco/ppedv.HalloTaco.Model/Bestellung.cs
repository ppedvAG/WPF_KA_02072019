using System;
using System.Collections.Generic;

namespace ppedv.HalloTaco.Model
{
    public class Bestellung : Entity
    {
        public DateTime Datum { get; set; } = DateTime.Now;
        public virtual HashSet<BestellItem> Items { get; set; } = new HashSet<BestellItem>();
    }
}
