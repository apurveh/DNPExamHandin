using System.ComponentModel.DataAnnotations;

namespace EfcDataAccess.Model;

public class Show
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public string Genre { get; set; }
}