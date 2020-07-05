using System.Threading.Tasks;
using VibbraTest.Domain.Customers;
using VibbraTest.Domain.Exceptions;
using VibbraTest.Domain.Revenues.Commands;

namespace VibbraTest.Domain.Revenues
{
    public class RevenueService
    {
        private readonly IRevenueRepository _revenueRepository;
        private readonly ICustomerRepository _customerRepository;

        public RevenueService(IRevenueRepository revenueRepository, ICustomerRepository customerRepository)
        {
            _revenueRepository = revenueRepository;
            _customerRepository = customerRepository;
        }

        public async Task<Revenue> InsertAsync(int customerId, InsertUpdateRevenueCommand command)
        {
            var customer = await _customerRepository.GetAsync(customerId);
            if (customer == null)
                throw new BusinessException($"Empresa não encontrada");

            var revenue = new Revenue
            {
                Customer = customer,
                AccrualDate = command.AccrualDate,
                Amount = command.Amount,
                Description = command.Description,
                InvoiceId = command.InvoiceId,
                TransactionDate = command.TransactionDate
            };

            _revenueRepository.Add(revenue);
            await _revenueRepository.SaveChangesAsync();

            return revenue;
        }

        public async Task<Revenue> UpdateAsync(int revenueId, InsertUpdateRevenueCommand command)
        {
            var revenue = await _revenueRepository.GetAsync(revenueId);
            if (revenue == null)
                throw new BusinessException($"Receita não encontrada");

            revenue.AccrualDate = command.AccrualDate;
            revenue.Amount = command.Amount;
            revenue.Description = command.Description;
            revenue.InvoiceId = command.InvoiceId;
            revenue.TransactionDate = command.TransactionDate;

            await _revenueRepository.SaveChangesAsync();

            return revenue;
        }

        public async Task DeleteAsync(int revenueId)
        {
            await _revenueRepository.RemoveAsync(revenueId);
            await _revenueRepository.SaveChangesAsync();
        }
    }
}
