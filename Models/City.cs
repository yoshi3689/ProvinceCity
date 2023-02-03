using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class City {
    [Key]
    public int CityId { get; set; }
    public int Population { get; set; }
    public string? CityName { get; set; }
    public string? ProvinceCode { get; set; }

    [ForeignKey("ProvinceCode")]
    public Province? Province { get; set; }
}