using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4.Models;

namespace WpfApp4.VM
{
    public class EditorWindowViewModel
    {
        public Sporotlo a { get; set; }
        public void SetUp(Sporotlo sporotlo)
        {
            a = sporotlo;
        }
        public EditorWindowViewModel()
        {

        }
    }
}
