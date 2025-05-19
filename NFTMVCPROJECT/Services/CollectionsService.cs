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

        string fileName = Path.GetFileNameWithoutExtension(collectionVM.ImgFile.FileName);

        string extension = Path.GetExtension(collectionVM.ImgFile.FileName);

        string resultName = fileName + Guid.NewGuid().ToString() + extension;

        string uploadedImg = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", "uploadedImg");

        string combine = Path.Combine(uploadedImg, resultName);

        using FileStream stream = new FileStream(combine, FileMode.Create);
        collectionVM.ImgFile.CopyTo(stream);



        collection.ImgUrl = resultName;
        collection.CategoryName = collectionVM.CategoryName;
        collection.Name = collectionVM.Name;
        collection.Items = collectionVM.Items;

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
        return _context.collections.ToList();
    }
    #endregion
    #region Update
    public void UpdateCollection(int id, CollectionVM newCollection)
    {

        Collection oldCollection = _context.collections.Find(id);

        oldCollection.Name = newCollection.Name;
        oldCollection.Items = newCollection.Items;
        oldCollection.CategoryName = newCollection.CategoryName;


        //string fileName = Path.GetFileNameWithoutExtension(newCollection.ImgFile.FileName);

        //string extension = Path.GetExtension(newCollection.ImgFile.FileName);

        //string resultName = fileName + Guid.NewGuid().ToString() + extension;

        string uploadedImg = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", "uploadedImg");

        //using FileStream stream = new FileStream(Path.Combine(uploadedImg, resultName), FileMode.Create);
        using FileStream stream = new FileStream(Path.Combine(uploadedImg, oldCollection.ImgUrl), FileMode.Create);

        newCollection.ImgFile.CopyTo(stream);

        //oldCollection.ImgUrl = resultName;

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