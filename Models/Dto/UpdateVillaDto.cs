using System.ComponentModel.DataAnnotations;

public class UpdateVillaDto
{
    [Required]
    public string Name { get; set; } = "";

    public double Rate { get; set; }
}
