namespace E_Store.Data.Interfaces.Repositories
{
    using Classes;
    using Data;
    using Models;
    
    public class EOrderRepository : BaseRepository<EOrder>, IEOrderRepository
    {
        public EOrderRepository(EStoreDbContext context) : base(context)
        {
        }

        public EOrder FindOrderByIdTokenState(int id, string token, OrderState orderState)
        {
            var result = FindById(id);

            if (result == null || result.Token != token || result.StateId != orderState)
                return null;

            return result;
        }
    }
}