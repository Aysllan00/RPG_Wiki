using RPGWiki.Shared.Models;

namespace RPGWiki.Requests
{
    public record JogadorRequest(string Nome, int Moedas, ICollection<MissaoRequest> Missoes = null);

}
