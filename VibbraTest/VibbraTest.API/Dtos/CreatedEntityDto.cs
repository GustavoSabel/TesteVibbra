namespace VibbraTest.API.Dtos
{
    public struct CreatedEntityDto
    {
        public CreatedEntityDto(int revenueId)
        {
            Id = revenueId;
        }

        public int Id { get; }
    }
}
