using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektmunka1.Data
{
    public class Record
    {
        public int? Id { get; set; }
    }
    internal class Dolgozo:Record
    {
        public string Nev { get; set; }
        public string Lakcim { get; set; }
        public double Fizetes { get; set; }
        public string Pozicio { get;set; }
        public string Email { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}\nNév: {Nev}\nLakcim: {Lakcim}\nFizetés: {Fizetes}\nPozició: {Pozicio}\nEmail: {Email}";

        }

    }
}
