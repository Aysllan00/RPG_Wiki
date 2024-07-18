using RPGWiki_Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWiki.Shared.Models
{
    public class Missao
    {
        public Missao(string name, int dificuldade)
        {
            Name = name;
            Dificuldade = dificuldade;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Dificuldade { get; set; }
        public virtual ICollection<Jogador> jogadores { get; set; } = new List<Jogador>();

        public override string ToString()
        {
            return $@"Nome: {Name}";
        }

    }
}
