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
        public int FK_Categoria { get; set; }
        public Categoria FK_CategoriaObj { get; set; }
        public Curso() { }

        public Curso(int id, string name, int fk, Categoria fK_Categoria)
        {
            IdCurso = id;
            Name = name;
            FK_Categoria = fk;
            FK_CategoriaObj = fK_Categoria;
        }
        public override string ToString()
        {
            return "\t| " + IdCurso + " - " + Name + " - " + FK_Categoria;
        }
    }
}
