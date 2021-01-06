namespace Ganjeh.Domain.Models.DTOs.Region
{
    public class StateDTO : BaseSimpleRecord
    {
        CountryDTO Country { get; set; }
    }
}