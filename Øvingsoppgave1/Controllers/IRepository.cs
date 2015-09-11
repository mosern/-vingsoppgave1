using Øvingsoppgave1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Øvingsoppgave1.Controllers
{
    public interface IRepository
    {
        List<Product> getAll();
        void Save(Product p);
    }
}
