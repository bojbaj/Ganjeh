namespace Ganjeh.Domain.Models.DTOs.Region
{
    public class StateDTO : BaseSimpleRecord
    {
        public CountryDTO Country { get; set; }
    }
}