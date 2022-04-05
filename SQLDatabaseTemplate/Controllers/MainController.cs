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
    [HttpGet("modelOne/")]
    public async Task<ActionResult<IEnumerable<ModelOne>>> GetAllModelOne()
    {
      List<ModelOne> modelOneList = await _modelOne.GetAll();
      return Ok(modelOneList);
    }
    [HttpGet("modelOne/{id}")]
    public async Task<ActionResult<IEnumerable<ModelOne>>> GetModelOneRecord(int id)
    {
      Debug.WriteLine($"ID: {id}");

      ModelOne getModelOne = await _modelOne.GetModelOne(id);
      return Ok(getModelOne);
    }
    [HttpPost("modelOne")]
    public async Task<ActionResult<IEnumerable<ModelOne>>> PostModelOneRecord(ModelOne modelOne)
    {
      ModelOne createModelOne = await _modelOne.Create(modelOne);
      return Ok(createModelOne);
    }
    [HttpPut("modelOne/{id}")]
    public async Task<ActionResult> PutModelOneRecord(int id, ModelOne modelOne)
    {
      //Debug.WriteLine($"Put MODEL ONE: {modelOne.Text}");
      //ModelOne retrievedModelOne  = await _modelOne.GetModelOne(id);
      await _modelOne.UpdateModelOne(id, modelOne);
      return Ok(modelOne);
    }
    [HttpDelete("modelOne/{id}")]
    public async Task<ActionResult<IEnumerable<ModelOne>>> DeleteModelOne(int id)
    {
      ModelOne modelOne = await _modelOne.DeleteModelOneRecord(id);
      return Ok(modelOne);
    }

  }
  
}
