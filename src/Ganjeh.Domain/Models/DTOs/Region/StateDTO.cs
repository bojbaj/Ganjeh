namespace Ganjeh.Domain.Models.DTOs.Region
{
    public class StateDTO : BaseListItemDTORecord
    {
        public CountryDTO Country { get; set; }
    }
}