using ppedv.HalloTaco.Logic;
using ppedv.HalloTaco.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.HalloTaco.UI.WPF.ViewModels
{
    public class TacoViewModel : ViewModelBase
    {

        public List<Taco> TacoList { get; set; }

        private Taco selectedTaco;
        public Taco SelectedTaco
        {
            get => selectedTaco;
            set
            {
                selectedTaco = value;
                OnPropertyChanged(nameof(SelectedTaco));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(RabattPreis));
            }
        }

        public decimal RabattPreis
        {
            get
            {
                if (SelectedTaco == null)
                    return 0;

                return core.CalcRabatt(SelectedTaco);
            }
        }

        public decimal Price
        {
            get
            {
                return selectedTaco == null ? 0 : selectedTaco.Preis;
            }
            set
            {
                if (selectedTaco != null)
                {
                    selectedTaco.Preis = value;
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(RabattPreis));
                }
            }
        }

        Core core = new Core();


        public IEnumerable<Fleischart> Fleischarten { get; set; }
        public IEnumerable<Tortillaart> Tortillaarten { get; set; }

        public TacoViewModel()
        {
            TacoList = new List<Taco>(core.Repository.GetAll<Taco>());
            Fleischarten = Enum.GetValues(typeof(Fleischart)).Cast<Fleischart>();
            Tortillaarten = Enum.GetValues(typeof(Tortillaart)).Cast<Tortillaart>();
        }
    }
}
