using System;
using System.Collections.Generic;
using System.Linq;
using WpfApp4.Models;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.Messaging;
using Newtonsoft.Json;
using System.IO;
using WpfApp4.Service;

namespace WpfApp4.Logic
{
    public class SportoloLogic : ISportoloLogic
    {
        private IList<Sporotlo> Sporotlok { get; set; }
        private IList<Sporotlo> Verseny { get; set; }

        private IMessenger Messenger { get; set; }
        private Edit Editor { get; set; }

        public SportoloLogic(IMessenger messenger)
        {
            Messenger = messenger;
            //Editor = edit;
        }
        public int AllSportolo { get { return Verseny != null ? Verseny.Count : 0; } }

        public double AllSportolomarket { get { return (Verseny == null || Verseny.Count == 0) ? 0 : Verseny.Sum(x => x.Értek); } }


        public void Load(IList<Sporotlo> sportolok,IList<Sporotlo> verseny)
        {
            Sporotlok = sportolok;
            Verseny = verseny;
            Sporotlok.Add(new Sporotlo() { Nev = "béla", Versenyszam = 1, EgyeniCsucs = 2, Egyesület = "ads", Engedely = true, IdeLegjobb = 3 });
            Sporotlok.Add(new Sporotlo() { Nev = "Sany", Versenyszam = 2, EgyeniCsucs = 2, Egyesület = "asdsa", Engedely = false, IdeLegjobb = 3 });
            Sporotlok.Add(new Sporotlo() { Nev = "ASDSAD", Versenyszam = 3, EgyeniCsucs = 2, Egyesület = "ads", Engedely = true, IdeLegjobb = 3 });

        }
        public void Add(Sporotlo Selected)
        {

            if (Verseny.Contains(Selected))
            {

            }
            else
            {
                Verseny.Add(Selected);
                Messenger.Send("Added", "Info");
            }

        }
        public void Delete(Sporotlo Selected)
        {
            if (Verseny.Contains(Selected))
            {
                Verseny.Remove(Selected);
                Messenger.Send("Deleted", "Info");
            }
        }
        public void Edit(Sporotlo Selected)
        {
            Editor.Editservice(Selected);
        }
        public void Save(string filename, string date)
        {
            var save = JsonConvert.SerializeObject(Verseny);
            StreamWriter streamWriter = new StreamWriter("" + filename + " " + date + ".json");
            streamWriter.Write(save);
            streamWriter.Close();
        }

    }
}
