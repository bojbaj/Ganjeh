namespace Ganjeh.Domain.Models.DTOs.Region
{
    public class CityDTO : BaseSimpleRecord
    {
        CountryDTO Country { get; set; }
        StateDTO State { get; set; }
    }
}