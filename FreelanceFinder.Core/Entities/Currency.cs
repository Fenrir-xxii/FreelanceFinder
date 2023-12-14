namespace FreelanceFinder.Core.Entities
{
    public class Currency : BaseEntity
    {
        public string Title { get; set; }
        public string CurrencyISOCode { get; set; }
        public int CurrencyISONumber { get; set; }
    }
}
