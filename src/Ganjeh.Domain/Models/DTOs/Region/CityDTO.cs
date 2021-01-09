namespace Ganjeh.Domain.Models.DTOs.Region
{
    public class CityDTO : BaseSimpleRecord
    {
        public StateDTO State { get; set; }
    }
}