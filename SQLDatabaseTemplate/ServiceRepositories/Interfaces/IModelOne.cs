using SQLDatabaseTemplate.Models;

namespace SQLDatabaseTemplate.ServiceRepositories.Interfaces
{
  public interface IModelOne
  {
    Task<List<ModelOne>> GetAll();
    Task<ModelOne> Create(ModelOne modelOne);
    Task<ModelOne> GetModelOne(int id);
    Task<ModelOne> UpdateModelOne(int id, ModelOne modelOne);
    Task<ModelOne> DeleteModelOneRecord(int id);
  }
}
