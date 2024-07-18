using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWiki_Console
{
    public class Personagem
    {
        public Personagem(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Nivel { get; set; }
        public int Vida { get; set; }
        public virtual Jogador? Jogador { get; set; }

        public override string ToString()
        {
            return $@"Nome: {Name}";
        }

    }
}
