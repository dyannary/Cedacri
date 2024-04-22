using MvcBasics.Data.Enum;
using MvcBasics.Models;

namespace MvcBasics.Dtos.Club;

public class CreateClubDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Address Address { get; set; }    
    public IFormFile Image { get; set; }
    public ClubCategory ClubCategory { get; set; }
}
