namespace E_Store.Business.Managers
{
    using System.Collections.Generic;
    using E_Store.Data.Interfaces.Repositories;
    
    using Data.Models;
    using Interfaces;
    
    public class ReadOnlyManager : IReadOnlyManager
    {
        private readonly IReadOnlyRepository repository;

        public ReadOnlyManager(IReadOnlyRepository repository)
            => this.repository = repository;

        public List<Country> GetAllCountries()
            => this.repository.GetCountries();

        public List<Bank> GetAllBanks()
            => this.repository.GetBanks();
    }
}