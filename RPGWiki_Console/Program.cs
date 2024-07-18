using RPGWiki.Shared.Data.BD;
using RPGWiki_Console;

Dictionary<string, Jogador> RPGDict = new Dictionary<string, Jogador>();

var JogadorDAL = new DAL<Jogador>(new RPGWikiContext());
//var PersonagemDAL = new DAL<Personagem>(new RPGWikiContext());


bool exit = false;

while (!exit) {

    Console.WriteLine("Você chegou na RPGWiki:\n");
    Console.WriteLine("Digite 1 para registrar um Jogador");
    Console.WriteLine("Digite 2 para registrar um Personagem");
    Console.WriteLine("Digite 3 para mostrar todos os Personagens");
    Console.WriteLine("Digite 4 para mostrar um Personagem");
    Console.WriteLine("Digite -1 para sair \n");

    Console.Write("Digite sua opção: ");
    int option = int.Parse(Console.ReadLine());

    switch (option)
    {
        case 1:
            JogadorRegister();
            break;
        case 2:
            PersonagemRegister();
            break;
        case 3:
            JogadorGet();
            break;
        case 4:
            PersonagemGet();
            break;
        case -1:
            Console.WriteLine("Fechando ...");
            exit = true;
            break;

        default:
            Console.WriteLine("Escolha inválida");
            break;
    }
    Thread.Sleep(1000);
    Console.Clear();
}

void PersonagemGet()
{
    Console.Clear();
    Console.WriteLine("Listagem de Personagens \n");
    Console.Write("Digite o nome do Jogador para listar um Personagem: ");
    string JogadorName = Console.ReadLine();
    var targetJogador = JogadorDAL.ReadByName(a => a.Nome.Equals(JogadorName));
    if (targetJogador is not null)
    {
        targetJogador.personagens = new List<Personagem>();
        foreach (var personagem in targetJogador.personagens)
        {
            Console.WriteLine(personagem);
        }
    }
    else { Console.WriteLine($"Jogador {JogadorName} não encontrado."); }
}

void JogadorGet()
{
    Console.Clear();
    Console.WriteLine("Listagem de Jogadores \n");
    foreach (var jogador in JogadorDAL.Read())
    {
        Console.WriteLine(jogador);
    }
    Console.ReadKey();
}

void PersonagemRegister()
{
    Console.Clear();
    Console.WriteLine("Registro de Personagem \n");
    Console.Write("Digite o nome do Jogador para criar um novo Personagem: ");
    string JogadorName = Console.ReadLine();
    var targetJogador = JogadorDAL.ReadByName(a => a.Nome.Equals(JogadorName));
    if (targetJogador is not null) {

        Console.WriteLine($"Qual o nome do novo Personagem? ");
        string personagemNome = Console.ReadLine();
        Jogador j = RPGDict[JogadorName];
        targetJogador.AddPersonagem(new Personagem(personagemNome));
        JogadorDAL.Update(targetJogador);
        Console.WriteLine($"Personagem {personagemNome} do jogador {JogadorName} adicionado! ");
    }
    else { Console.WriteLine($"Jogador {JogadorName} não encontrado."); }
}

void JogadorRegister()
{
    Console.Clear();
    Console.WriteLine("Registro de Jogadores \n");
    Console.Write("Digite o nome do Jogador: ");
    string name = Console.ReadLine();
    Console.Write("Digite o número de moedas iniciais: ");
    int moedas = int.Parse(Console.ReadLine());
    Jogador j = new Jogador(name, moedas);
    JogadorDAL.Create(j);
    Console.WriteLine($"Jogador {name} adicionado!");
}