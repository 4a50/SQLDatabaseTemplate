using Microsoft.AspNetCore.Mvc;
using SQLDatabaseTemplate.Models;
using SQLDatabaseTemplate.ServiceRepositories.Interfaces;
using System.Diagnostics;

namespace SQLDatabaseTemplate.Controllers
{
  [Route("[Controller]")]
  [ApiController]

  public class MainController : Controller
  {
    private readonly IConfiguration _config;
    private readonly IModelOne _modelOne;
    public MainController(IConfiguration config, IModelOne repo )
    {
      _config = config;
      _modelOne = repo;
    }
    [HttpGet("modelOne/{id}")]
    public async Task<ActionResult<IEnumerable<ModelOne>>> GetModelOneRecord(int id)
    {
      Debug.WriteLine($"ID: {id}");

      ModelOne getModelOne = await _modelOne.GetModelOne(id);
      return Ok(getModelOne);
    }


  }
  
}
