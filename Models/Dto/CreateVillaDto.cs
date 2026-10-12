using System.ComponentModel.DataAnnotations;

public class CreateVillaDto
{
    [Required]
    public string Name { get; set; } = "";

    public double Rate { get; set; }
}