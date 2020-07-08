using System;
using System.Threading.Tasks;
using VibbraTest.Domain.Customers.Commands;
using VibbraTest.Domain.Exceptions;
using VibbraTest.Domain.ValueObjects;

namespace VibbraTest.Domain.Customers
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> InsertAsync(InsertUpdateCustomerCommand command)
        {
            var cnpj = new Cnpj(command.Cnpj);

            var existingCustomer = await _customerRepository.GetByCnpjAsync(cnpj);
            if (existingCustomer != null)
                throw new BusinessException($"Customer already exists with CNPJ {cnpj}");

            var customer = new Customer
            {
                Cnpj = cnpj,
                CommercialName = command.CommercialName,
                LegalName = command.LegalName
            };
            _customerRepository.Add(customer);
            await _customerRepository.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateAsync(int id, InsertUpdateCustomerCommand command)
        {
            var cnpj = new Cnpj(command.Cnpj);

            var customer = await _customerRepository.GetAsync(id);
            if (customer == null)
                throw new EntityNotFoundException("Customer");

            if (customer.Cnpj != cnpj)
            {
                var existingCustomer = await _customerRepository.GetByCnpjAsync(cnpj);
                if (existingCustomer != null)
                    throw new BusinessException($"Customer already exists with CNPJ {cnpj}");
            }

            customer.Cnpj = cnpj;
            customer.CommercialName = command.CommercialName;
            customer.LegalName = command.LegalName;

            await _customerRepository.SaveChangesAsync();
            return customer;
        }

        public async Task ArchiveAsync(int id)
        {
            var customer = await _customerRepository.GetAsync(id);
            if (customer == null)
                throw new EntityNotFoundException("Customer");

            if (customer.Archived == true)
                throw new BusinessException($"Customer {customer.CommercialName} is alread archived");

            customer.Archived = true;

            await _customerRepository.SaveChangesAsync();
        }
    }
}
