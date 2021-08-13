namespace E_Store.Business.Interfaces
{
    using System.Collections.Generic;
    using Data.Models;

    public interface IReadOnlyManager
    {
        List<Country> GetAllCountries();
        List<Bank> GetAllBanks();
    }
}