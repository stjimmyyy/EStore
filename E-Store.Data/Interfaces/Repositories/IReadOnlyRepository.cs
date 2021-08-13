namespace E_Store.Data.Interfaces.Repositories
{
    using System.Collections.Generic;
    using Models;
    public interface IReadOnlyRepository
    {
        List<Country> GetCountries();
        List<Bank> GetBanks();
    }
}