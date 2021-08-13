namespace E_Store.Classes
{
    using E_Store.Data.Models;
    using Models.Person;
    
    using AutoMapper;
    
    public class AutomapperConfigurationProfile : Profile
    {
        public AutomapperConfigurationProfile()
        {
            CreateMap<BasePersonViewModel, PersonDetail>();
            CreateMap<BasePersonViewModel, Address>();
            CreateMap<BasePersonViewModel, BankAccount>();
            CreateMap<PersonEditViewModel, PersonDetail>();
            CreateMap<PersonEditViewModel, Address>();
            CreateMap<PersonEditViewModel, BankAccount>();
            CreateMap<PersonRegisterViewModel, PersonDetail>();
            CreateMap<PersonRegisterViewModel, Address>();
            CreateMap<PersonRegisterViewModel, BankAccount>();
            CreateMap<Address, PersonEditViewModel>();
            CreateMap<BankAccount, PersonEditViewModel>();
            CreateMap<PersonEditViewModel, PersonRegisterViewModel>();
            CreateMap<PersonEditViewModel, PersonRegisterViewModel>()
                .ForMember(prvm => prvm.Countries, 
                    opt => opt.Ignore());
        }
    }
}