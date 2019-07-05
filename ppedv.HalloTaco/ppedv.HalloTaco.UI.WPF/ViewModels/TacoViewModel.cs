using ppedv.HalloTaco.Logic;
using ppedv.HalloTaco.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ppedv.HalloTaco.UI.WPF.ViewModels
{
    public class TacoViewModel : ViewModelBase,IDataErrorInfo
    {
        public string Error => "kwefbkfjew";

        public string this[string columnName] => throw new NotImplementedException();

        public ObservableCollection<Taco> TacoList { get; set; }

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
        private bool deleteDialogVisible;
        private string deleteDialogText;

        public IEnumerable<Fleischart> Fleischarten { get; set; }
        public IEnumerable<Tortillaart> Tortillaarten { get; set; }

        public SaveCommand SaveCommand { get; set; }

        public ICommand SaveCommandInCool { get; set; }
        public ICommand NewCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public bool DeleteDialogVisible
        {
            get => deleteDialogVisible; set
            {
                deleteDialogVisible = value;
                OnPropertyChanged(nameof(DeleteDialogVisible));
            }
        }

        public string DeleteDialogText
        {
            get => deleteDialogText; set
            {
                deleteDialogText = value;
                OnPropertyChanged(nameof(DeleteDialogText));
            }
        }
        public ICommand DeleteDialogResult { get; set; }

  

        public TacoViewModel()
        {
            TacoList = new ObservableCollection<Taco>(core.Repository.GetAll<Taco>());
            Fleischarten = Enum.GetValues(typeof(Fleischart)).Cast<Fleischart>();
            Tortillaarten = Enum.GetValues(typeof(Tortillaart)).Cast<Tortillaart>();

            SaveCommand = new SaveCommand(core);
            SaveCommandInCool = new RelayCommand(p => core.Repository.Save(), p => core.Repository.HasChanges);

            NewCommand = new RelayCommand(UserWantsToCreateNewTaco);
            DeleteCommand = new RelayCommand(UserWantsToDeleteSelectedTaco, p => SelectedTaco != null);

            DeleteDialogResult = new RelayCommand(UserResultOfDeleteDialog);
        }


        private void UserResultOfDeleteDialog(object obj)
        {
            if (obj is string s)
            {
                switch (s)
                {
                    case "jo":
                        DeleteSelectedTaco();
                        break;
                    case "lmaa":
                        DeleteSelectedTaco();
                        lmaa = true;
                        break;
                    default:
                        break;
                }

                DeleteDialogVisible = false;
            }
        }
        bool lmaa = false;
        private void DeleteSelectedTaco()
        {
            core.Repository.Delete(SelectedTaco);
            TacoList.Remove(SelectedTaco);
        }

        private void UserWantsToDeleteSelectedTaco(object obj)
        {
            if (selectedTaco != null)
            {
                if (!lmaa)
                {
                    //todo text aus resource holen
                    DeleteDialogText = $"Soll der Taco '{selectedTaco.Name}' wirklich gelöscht werden?";
                    DeleteDialogVisible = true;
                }
                else
                {
                    DeleteSelectedTaco();
                }
            }
        }

        private void UserWantsToCreateNewTaco(object obj)
        {
            var newTaco = new Taco() { Name = "NEU", Preis = 4.00m };
            core.Repository.Add(newTaco);
            TacoList.Add(newTaco);
            SelectedTaco = newTaco;
        }
    }
}
