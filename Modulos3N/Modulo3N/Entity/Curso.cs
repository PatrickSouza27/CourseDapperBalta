using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulos2N.Models
{
    public class Curso
    {
        public int ID { get; set; }
        public string? Nome { get; set; }
        public string? NomeCategoria { get; set; }

        public override string ToString()
        {
            return "| " + ID + " | " + Nome + " | " + NomeCategoria + " |";
        }
    }
}

