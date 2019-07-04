using NUnit.Framework;
using ppedv.HalloTaco.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.HalloTaco.Data.EF.Tests
{
    [TestFixture]
    public class EfContextTests
    {
        [Test]
        public void EfContext_can_create_database()
        {
            using (var con = new EfContext())
            {
                if (con.Database.Exists())
                    con.Database.Delete();

                con.Database.Create();

                Assert.IsTrue(con.Database.Exists());
            }
        }

        [Test]
        public void EfContext_can_Taco()
        {
            var taco = new Taco()
            {
                Fleischart = Fleischart.Pferd,
                Größe = Größe.Groß,
                IstWeich = true,
                Tortillaart = Tortillaart.Pappe,
                Name = $"Testtaco_{Guid.NewGuid()}",
                Preis = 3.23m
            };

            var newName = $"NewTesttaco_{Guid.NewGuid()}";

            //INSERT
            using (var con = new EfContext())
            {
                con.Tacos.Add(taco);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                //check INSERT
                var loaded = con.Tacos.Find(taco.Id);
                Assert.IsNotNull(loaded);
                Assert.AreEqual(taco.Name, loaded.Name);

                //UPDATE
                loaded.Name = newName;
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                //check UPDATE
                var loaded = con.Tacos.Find(taco.Id);
                Assert.AreEqual(newName, loaded.Name);

                //DELETE
                con.Tacos.Remove(loaded);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                //check DELETE
                var loaded = con.Tacos.Find(taco.Id);
                Assert.IsNull(loaded);
            }

        }

    }
}
