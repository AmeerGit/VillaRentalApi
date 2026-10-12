using System.ComponentModel.DataAnnotations;

public class Villa
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = "";

    public double Rate { get; set; }


    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
