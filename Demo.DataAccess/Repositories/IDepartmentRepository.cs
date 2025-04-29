
namespace Demo.DataAccess.Repositories
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll(bool WithTracking);
        Department? GetById(int id);
        int Insert(Department department);
        int Remove(Department department);
        int Update(Department department);
    }
}