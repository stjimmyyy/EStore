namespace E_Store.Business.Managers
{
    using E_Store.Data.Interfaces.Repositories;

    using Interfaces;
    using Data.Models;
    
    public class PersonManager : IPersonManager
    {
        private readonly IPersonRepository personRepository;
        private readonly IPersonDetailRepository personDetailRepository;
        private readonly IAddressRepository addressRepository;
        private readonly IBankAccountRepository bankAccountRepository;

        public PersonManager(
            IPersonRepository personRepository,
            IPersonDetailRepository personDetailRepository,
            IAddressRepository addressRepository,
            IBankAccountRepository bankAccountRepository)
        {
            this.personRepository = personRepository;
            this.personDetailRepository = personDetailRepository;
            this.addressRepository = addressRepository;
            this.bankAccountRepository = bankAccountRepository;
        }

        public Person FindById(int id) => this.personRepository.FindById(id);
        public Person FindByUserId(string id) => this.personRepository.FindByUserId(id);

        public Person InsertOrEdit(PersonDetail personDetail, Address address, Address deliveryAddress, BankAccount bankAccount,
            bool deliveryAddressIsAddress, int? personId = null, string userId = null, bool save = true)
        {
            this.personDetailRepository.Insert(personDetail);
            this.addressRepository.Insert(address);
            
            if(!deliveryAddressIsAddress)
                this.addressRepository.Insert(deliveryAddress);
            
            if(!string.IsNullOrEmpty(bankAccount.AccountNumber))
                this.bankAccountRepository.Insert(bankAccount);

            var oldPersonDetailId = 0;
            var oldAddressId = 0;
            var oldDeliveryAddressId = 0;
            int? oldBankAccountId = null;

            var person = personId == null
                ? null
                : this.personRepository.FindById(personId.Value);

            var create = person == null;

            if (create)
            {
                person = new Person() {UserId = userId};
            }
            else
            {
                oldPersonDetailId = person.PersonDetailId;
                oldAddressId = person.AddressId;
                oldDeliveryAddressId = person.DeliveryAddressId;
                oldBankAccountId = person.BankAccountId;
            }

            person.PersonDetailId = personDetail.Id;
            person.AddressId = address.Id;
            person.DeliveryAddressId = deliveryAddressIsAddress
                ? address.Id
                : deliveryAddress.Id;

            person.BankAccountId = !string.IsNullOrEmpty(bankAccount.AccountNumber)
                ? (int?) bankAccount.Id
                : null;

            if (save)
            {
                if (create)
                {
                    this.personRepository.Insert(person);
                }
                else
                {
                    this.personRepository.Update(person);
                }

                try
                {
                    this.personDetailRepository.Delete(oldPersonDetailId);
                }
                catch
                {
                    // ignored
                }

                try
                {
                    this.addressRepository.Delete(oldAddressId);
                }
                catch
                {
                    //ignored
                }

                if (oldDeliveryAddressId != oldAddressId)
                {
                    try {this.addressRepository.Delete(oldDeliveryAddressId);}
                    catch
                    {
                        // ignored
                    }
                }

                if (oldBankAccountId != null)
                {
                    try
                    {
                        this.bankAccountRepository.Delete(oldBankAccountId.Value);
                    }
                    catch
                    {
                        //ignored
                    }
                }
            }

            return person;
        }

        public void InsertOrEdit(Person person)
        {
            this.personRepository.Update(person);
        }
    }
}