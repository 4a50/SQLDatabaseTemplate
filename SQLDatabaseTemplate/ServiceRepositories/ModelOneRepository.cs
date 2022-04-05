using Microsoft.EntityFrameworkCore;
using SQLDatabaseTemplate.DatabaseContext;
using SQLDatabaseTemplate.Models;
using SQLDatabaseTemplate.ServiceRepositories.Interfaces;

namespace SQLDatabaseTemplate.ServiceRepositories
{
  public class ModelOneRepository : IModelOne
  {
    private TemplateDbContext _context;
    public ModelOneRepository(TemplateDbContext context)
    {
      _context = context;
    }
    public async Task<ModelOne> Create(ModelOne modelOne)
    {
      _context.Entry(modelOne).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return modelOne;     
    }
    public async Task<ModelOne> DeleteModelOneRecord(int id)
    {
      var deleteModelOne = await _context.ModelOne.FirstOrDefaultAsync(i => i.Id == id);
      if (deleteModelOne != null)
      {
        _context.Entry(deleteModelOne).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
      }
      else { deleteModelOne = new ModelOne() { Id = 0, Text = "Not Found. Cannot Delete" }; }
      return deleteModelOne;      
    }
    public async Task<ModelOne> GetModelOne(int id)
    {
      var getItem = await _context.ModelOne.FirstOrDefaultAsync(s => s.Id == id);
      if (getItem == null) getItem = new ModelOne() { Id = 0, Text = "Not Found" };
      return getItem;
    }
    public async Task<ModelOne> UpdateModelOne(int id, ModelOne modelOne)
    {
      _context.Entry(modelOne).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return modelOne;
    }
  }
}
