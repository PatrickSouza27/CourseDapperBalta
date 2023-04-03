using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulos4N.Entities
{
    public class Curso
    {
        public int IdCurso { get; set; }
        public string Name { get; set; }
        public Curso() { }

        public Curso(int id, string name, int fk)
        {
            IdCurso = id;
            Name = name;
        }
        public override string ToString()
        {
            return "\t| " + IdCurso + " - " + Name + "\t |";
        }
    }
}
