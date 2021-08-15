namespace E_Store.Business.Interfaces
{
    using Data.Models;
    public interface IPersonManager
    {

        Person FindById(int id);
        Person FindByUserId(string id);
        Person InsertOrEdit(
            PersonDetail personDetail,
            Address address,
            Address deliveryAddress,
            BankAccount bankAccount,
            bool deliveryAddressIsAddress,
            int? personId = null,
            string userId = null,
            bool save = true);
        void InsertOrEdit(Person person);
    }
}