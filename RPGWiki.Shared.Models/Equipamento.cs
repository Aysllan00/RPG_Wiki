using RPGWiki_Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWiki.Shared.Models
{
    public class Equipamento
    {
        public Equipamento(string name, string tipo)
        {
            Name = name;
            Tipo = tipo;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Tipo { get; set; }
        public virtual Jogador? Jogador { get; set; }

        public override string ToString()
        {
            return $@"Nome: {Name}";
        }
    }
}
