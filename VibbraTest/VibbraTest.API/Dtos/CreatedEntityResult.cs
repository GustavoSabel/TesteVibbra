namespace VibbraTest.API.Dtos
{
    public struct CreatedEntityResult
    {
        public CreatedEntityResult(int revenueId)
        {
            Id = revenueId;
        }

        public int Id { get; }
    }
}
