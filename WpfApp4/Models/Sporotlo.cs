using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4.Models
{
    public class Sporotlo:ObservableObject
    {
        private string nev;
        private int ideLegjobb;
        private int egyeniCsucs;

        public string Nev
        {
            get { return nev; }
            set { SetProperty(ref nev, value); }
        }
        

        public int EgyeniCsucs
        {
            get { return egyeniCsucs; }
            set { SetProperty(ref egyeniCsucs, value); }
        }
        

        public int IdeLegjobb
        {
            get { return ideLegjobb; }
            set { SetProperty(ref ideLegjobb, value); }
        }

        private bool engedely;

        public bool Engedely
        {
            get { return engedely; }
            set { SetProperty(ref engedely, value); }
        }

        private string egyesület;

        public string Egyesület
        {
            get { return egyesület; }
            set { SetProperty(ref egyesület, value); }
        }
        private int versenyszam;

        public int Versenyszam
        {
            get { return versenyszam; }
            set { SetProperty(ref versenyszam, value); }
        }
        private int értek;

        public int Értek
        {
            get { return egyeniCsucs * ideLegjobb; }
        }





    }
}
