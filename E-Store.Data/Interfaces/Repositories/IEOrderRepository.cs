namespace E_Store.Data.Interfaces.Repositories
{
    using Models;
    using Classes;
    
    public interface IEOrderRepository : IRepository<EOrder>
    {
        EOrder FindOrderByIdTokenState(int id, string token, OrderState orderState);
    }
}