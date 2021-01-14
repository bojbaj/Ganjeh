namespace Ganjeh.Domain.Models.DTOs.Region
{
    public class CityDTO : BaseListItemDTORecord
    {
        public StateDTO State { get; set; }
    }
}