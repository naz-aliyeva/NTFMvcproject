using System.ComponentModel.DataAnnotations.Schema;

namespace NFTMVCPROJECT.View_Models;

public class CollectionVM
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CategoryName { get; set; }
    public int Items { get; set; }
    public IFormFile ImgFile { get; set; }

}
