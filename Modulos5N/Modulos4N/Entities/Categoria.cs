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
        public Categoria() { }
        public Categoria(int id, string name)
        {
            Id= id;
            name= name;
        }
        public override string ToString()
        {
            return Id + " - " + Name + "\t |";
        }

    }
}
