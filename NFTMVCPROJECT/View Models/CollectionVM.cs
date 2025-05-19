using System.ComponentModel.DataAnnotations;

namespace NFTMVCPROJECT.View_Models;

public class CollectionVM
{
    [Required(ErrorMessage = "Ad yazilmayib")]
    public string Name { get; set; }
    public string CategoryName { get; set; }
    public int Items { get; set; }
    public IFormFile ImgFile { get; set; }

}
