using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulos4N.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Curso> Cursos { get; set; }
        public Categoria() {
            Cursos = new List<Curso>();                        
        }
        public Categoria(int id, string name)
        {
            Id= id;
            Name= name;
        }
        public override string ToString()
        {
            return Id + " - " + Name + "\t |";
        }

    }
}
