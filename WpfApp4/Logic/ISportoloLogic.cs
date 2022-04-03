using System.Collections.Generic;
using WpfApp4.Models;

namespace WpfApp4.Logic
{
    public interface ISportoloLogic
    {
        int AllSportolo { get; }
        double AllSportolomarket { get; }

        void Add(Sporotlo Selected);
        void Delete(Sporotlo Selected);
        void Edit(Sporotlo Selected);
        void Load(IList<Sporotlo> sportolok,IList<Sporotlo> Verseny);
        void Save(string filename, string date);
    }
}