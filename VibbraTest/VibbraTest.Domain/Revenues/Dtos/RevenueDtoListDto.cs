using System.Collections.Generic;

namespace VibbraTest.Domain.Revenues.Dtos
{
    public class RevenueDtoListDto
    {
        public RevenueDtoListDto(List<RevenueDto> revenues)
        {
            Revenues = revenues;
        }

        public int Count => Revenues.Count;
        public List<RevenueDto> Revenues { get; set; }
    }
}
