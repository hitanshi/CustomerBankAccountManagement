using System;
using System.Collections.Generic;
using AutoMapper;
using CustomerBankingService.Application.Common.Mappings;
using CustomerBankingService.Domain.Entities;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace CustomerBankingService.Application.BankCustomers
{

    public class BankCustomerDto : IMapFrom<BankCustomer>
    {
        public BankCustomerDto()
        {
        }

        public static BankCustomerDto Create(
            int id,
            string firstName,
            string lastName,
            string idNumber,
            string gender)
        {
            return new BankCustomerDto
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                IdNumber = idNumber,
                Gender = gender,
            };
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string IdNumber { get; set; }

        public string Gender { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BankCustomer, BankCustomerDto>();
        }
    }
}