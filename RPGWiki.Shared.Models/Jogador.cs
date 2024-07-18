using RPGWiki.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWiki_Console
{
    public class Jogador
    {
        public Jogador(string nome, int moedas)
        {
            Nome = nome;
            Moedas = moedas;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Moedas { get; set; }
        public virtual ICollection<Personagem> personagens { get; set; } = new List<Personagem>();
        public virtual ICollection<Missao> missoes { get; set; } = new List<Missao>();

        public void AddPersonagem(Personagem personagem) {
        
            personagens.Append(personagem);
        }

        public void ShowPersonagem() {

            Console.WriteLine($"Personagem de {Nome}");
            foreach (var p in personagens)
            {
                Console.WriteLine(p);
            }
        }

        public void AddMissao(Missao missao)
        {

            missoes.Append(missao);
        }

        public void ShowMissao()
        {

            Console.WriteLine($"Missão de {Nome}");
            foreach (var p in missoes)
            {
                Console.WriteLine(p);
            }
        }

        public override string ToString()
        {
            return $@"ID: {Id} | Nome: {Nome}, Moedas: {Moedas}";
        }

    }
}
