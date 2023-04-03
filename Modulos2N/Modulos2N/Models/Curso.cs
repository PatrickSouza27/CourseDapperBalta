using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulos2N.Models
{
    public class Curso
    {
        public string Nome { get; set; }
        public int CategoriaId { get; set; }

        public override string ToString()
        {
            return CategoriaId + " - " + Nome;
        }
    }
}
