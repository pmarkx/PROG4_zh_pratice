using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using WpfApp4.Models;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.Input;
using WpfApp4.Logic;
using Microsoft.Toolkit.Mvvm.DependencyInjection;

namespace WpfApp4.VM
{
    public class MainWinodwViewModel:ObservableRecipient
    {
        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set 
            { 
                SetProperty(ref fileName, value);
                (Save as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        private string date;

        public string Date
        {
            get { return date; }
            set 
            {
                SetProperty(ref date, value);
                (Save as RelayCommand).NotifyCanExecuteChanged();
            }
        }


        public int AllSportolo { get { return Logic.AllSportolo; } }
        public double AllSportolomarket { get { return Logic.AllSportolomarket; } }
        private ObservableCollection<Sporotlo> sportolok;
        public ObservableCollection<Sporotlo> Sporotlok {
            get { return sportolok; } 
            set 
            {
                sportolok = value;
                (Load as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ObservableCollection<Sporotlo> Verseny { get; set; }

        private Sporotlo selectedSportoloFromSportolok;
        public Sporotlo SelectedSportoloFromSportolok { get { return selectedSportoloFromSportolok; } 
            set 
            {
                selectedSportoloFromSportolok = value;
                (Add as RelayCommand).NotifyCanExecuteChanged();
                //(Edit as RelayCommand).NotifyCanExecuteChanged();

            } 
        }
        private Sporotlo selectedSportoloFromVerseny;
        public Sporotlo SelectedSportoloFromVerseny { get { return selectedSportoloFromVerseny; }
            set 
            {
                selectedSportoloFromVerseny = value;
                (Delete as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand Load { get; set; }
        public ICommand Add { get; set; }
        public ICommand Delete { get; set; }
        public ICommand Save { get; set; }
        public ICommand Edit { get; set; }
        private ISportoloLogic Logic { get; set; }
        public MainWinodwViewModel() : this(IsDesignMode ? null : Ioc.Default.GetService<ISportoloLogic>())
        {

        }
        public static bool IsDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWinodwViewModel(ISportoloLogic logic)
        {
            Logic = logic;
            Load = new RelayCommand(
                () => logic.Load(Sporotlok,Verseny),
                () => Sporotlok.Count == 0
            );
            Sporotlok = new ObservableCollection<Sporotlo>();
            Verseny = new ObservableCollection<Sporotlo>();
            Add = new RelayCommand(
                () => logic.Add(selectedSportoloFromSportolok),
                () => selectedSportoloFromSportolok!=null&&selectedSportoloFromSportolok.Engedely==true
            );
            Delete = new RelayCommand(
                () => logic.Delete(selectedSportoloFromVerseny),
                () => selectedSportoloFromVerseny!=null
                );
            Save = new RelayCommand(
                () =>logic.Save(fileName,date)
                );
            Messenger.Register<MainWinodwViewModel, string, string>(this, "Info", (recepient, msg) =>
            {
                OnPropertyChanged(nameof(AllSportolo));
                OnPropertyChanged(nameof(AllSportolomarket));
            });
        }
    }
}
