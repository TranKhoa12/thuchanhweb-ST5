using webbantrasua.Models;

namespace webbantrasua.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
    }
}
