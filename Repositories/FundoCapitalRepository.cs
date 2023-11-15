using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Uniciv.Api.Models;

namespace Uniciv.Api.Repositories
{
    public class FundoCapitalRepository : IFundoCapitalRepository
    {
        private readonly List<FundoCapital> _storage;

        public FundoCapitalRepository()
        {
            _storage = new List<FundoCapital>();
        }

        public void Adicionar(FundoCapital fundoCapital)
        {
            _storage.Add(fundoCapital);
        }

        public void Alterar(FundoCapital fundoCapital)
        {
            var index = _storage.FindIndex(f => f.Id == fundoCapital.Id);
            _storage[index] = fundoCapital;
        }

        public IEnumerable<FundoCapital> ListarFundos()
        {
            return _storage;
        }

        public FundoCapital? ObterPorId(Guid id)
        {
            return _storage.FirstOrDefault(f => f.Id == id);
        }

        public void RemoverFundo(FundoCapital fundoCapital)
        {
            _storage.Remove(fundoCapital);
        }
    }

}