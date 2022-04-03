using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfApp4.Models;
using System.Threading.Tasks;

namespace WpfApp4.Service
{
    public class Edit : IEdit
    {
        public void Editservice(Sporotlo Selected)
        {
            new Editor(Selected).ShowDialog();
        }
    }
}
