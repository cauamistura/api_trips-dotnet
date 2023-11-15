using Uniciv.Api.Models;

namespace Uniciv.Api.Repositories
{
    public interface IFundoCapitalRepository
    {
        void Adicionar(FundoCapital fundoCapital);
        void Alterar(FundoCapital fundoCapital);
        IEnumerable<FundoCapital> ListarFundos();
        FundoCapital? ObterPorId(Guid id);
        void RemoverFundo(FundoCapital fundoCapital);
    }
}   