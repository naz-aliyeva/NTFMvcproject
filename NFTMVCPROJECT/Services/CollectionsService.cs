using NFTMVCPROJECT.Contexts;
using NFTMVCPROJECT.Models;
using NFTMVCPROJECT.View_Models;

namespace NFTMVCPROJECT.Services;
public class CollectionsService
{
    private readonly AppDbContext _context;

    public CollectionsService()
    {
        _context = new AppDbContext();
    }

    #region Create
    public void CreateCollection(CollectionVM collectionVM)

    {

        Collection collection = new Collection();


        //string fileName = Guid.NewGuid().ToString()+ CollectionVM.ImgFile.FileName;

        string fileName = Path.GetFileNameWithoutExtension(CollectionVM.ImgFile.FileName);
        string extension = Path.GetExtension(CollectionVM.ImgFile.FileName);
        string resultName = fileName + Guid.NewGuid().ToString() + extension;
        string uploadedImg = ;
        FileStream stream = new FileStream();
        collectionVM.ImgFile.CopyTo();
        new CollectionVM.ImgUrl = resultName;

        _context.collections.Add(collection);
        _context.SaveChanges();
    }
    #endregion

    #region Read 
    public Collection GetCollectionById(int id)
    {
        Collection? collection = _context.collections.Find(id);
        if (collection is null)
        {
            throw new Exception($"Database daxilinde {id} id-e sahib data tapilmadi");
        }
        return collection;
    }

    public List<Collection> GetAllCollection()
    {
        List<Collection> collection = _context.collections.ToList();
        return collection;
    }
    #endregion
    #region Update
    public void UpdateCollection(int id, Collection collection)
    {
        if (collection is null)
        {
            throw new Exception($"id-ler ust uste dusur");
        }

    }
    #endregion

    #region Delete 
    public void DeleteCollection(int id)
    {
        Collection? collection = _context.collections.Find(id);
        if (collection is null)
        {
            throw new Exception($"Database daxilinde {id} id-e sahib data tapilmadi");
        }
        _context.collections.Remove(collection);
        _context.SaveChanges();

    }
    #endregion
}