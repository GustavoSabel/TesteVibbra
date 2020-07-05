using VibbraTest.Domain.Revenues;
using VibbraTest.Infra.Base;

namespace VibbraTest.Infra.Repositories
{
    public class RevenueRepository : RepositoryBase<Revenue>, IRevenueRepository
    {
        public RevenueRepository(VibbraContext context) : base(context, context.Revenue) { }
    }
}
