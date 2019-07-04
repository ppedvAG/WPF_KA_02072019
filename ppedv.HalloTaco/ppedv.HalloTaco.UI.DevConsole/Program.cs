using ppedv.HalloTaco.Logic;
using ppedv.HalloTaco.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.HalloTaco.UI.DevConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("🌮🌮🌮 Hallo Taco v0.1 🌮🌮🌮");

            var core = new Core();
            foreach (var t in core.Repository.GetAll<Taco>())
            {
                Console.WriteLine($"{t.Name} {t.Preis:c} {t.Fleischart}");
            }

            Console.WriteLine("Ende");
            Console.ReadKey();
        }
    }
}
