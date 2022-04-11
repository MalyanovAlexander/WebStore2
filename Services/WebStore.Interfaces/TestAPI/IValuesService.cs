using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Interfaces.TestAPI
{
    public interface IValuesService
    {
        IEnumerable<string> GetValues();

        int Count();

        string? GetById(string id);

        void Add(string value);

        void Edit(int id, string value);

        bool Delete(int id);
    }
}
