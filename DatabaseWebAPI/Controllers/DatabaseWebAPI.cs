using DatabaseGateway.DatabaseDataHandler;
using DatabaseGateway.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseWebAPI.Controllers;

[Authorize]
[ApiController]
public class DatabaseWebAPI : ControllerBase
{
    private readonly IDataManager _iDataManager;

    public DatabaseWebAPI([FromServices] IDataManager dataManager)
    {
        _iDataManager = dataManager;
    }

    [HttpGet("Greenhouse/{userEmail}")]
    public async Task<ActionResult<List<Greenhouse>>> GetGreenhouses([FromRoute] string userEmail)
    {
        try
        {
            {
                List<Greenhouse> greenhouses = _iDataManager.GetGreenhouses(userEmail).Result;
                return Ok(greenhouses);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500,e.Message);
        }
    }

    [HttpGet("GreenhouseById/{greenhouseId}")]
    public async Task<ActionResult<Greenhouse>> GetGreenhouse(int greenhouseId)
    {
        try
        {
            {
                Greenhouse greenhouse = _iDataManager.GetGreenhouse(greenhouseId).Result;
                return Ok(greenhouse);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPut]
    [Route("Greenhouse")]
    public async Task UpdateGreenhouse([FromBody] Greenhouse greenhouse)
    {
        try
        {
            {
                await _iDataManager.UpdateGreenhouse(greenhouse);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    [HttpPost]
    [Route("Greenhouse")]
    public async Task CreateGreenhouse([FromBody] Greenhouse greenhouse)
    {
        try
        {
            {
                await _iDataManager.CreateGreenhouse(greenhouse);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    
    [HttpDelete]
    [Route("Greenhouse/{greenhouseId}")]
    public async Task RemoveGreenhouse([FromRoute] int greenhouseId)
    {
        try
        {
            {
                await _iDataManager.RemoveGreenhouse(greenhouseId);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    [HttpGet]
    [Route("Plants/{greenhouseId}")]
    public async Task<ActionResult<List<Plant>>> GetPlants([FromRoute] int greenhouseId)
    {
        try
        {
            {
                List<Plant> plants = _iDataManager.GetPlants(greenhouseId).Result;
                return Ok(plants);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500,e.Message);
        }
    }
    [HttpPut]
    [Route("Plants")]
    public async Task UpdatePlant([FromBody] Plant plant)
    {
        try
        {
            {
                await _iDataManager.UpdatePlant(plant);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    [HttpDelete]
    [Route("Plants/{plantId}")]
    public async Task RemovePlant([FromRoute] int plantId)
    {
        try
        {
            {
                await _iDataManager.RemovePlant(plantId);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    [HttpPost]
    [Route("Plants")]
    public async Task CreatePlant([FromBody] Plant plant)
    {
        try
        {
            {
                await _iDataManager.CreatePlant(plant);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    [HttpGet]
    [Route("Logs/{greenhouseId}")]
    public async Task<ActionResult<List<Log>>> GetAllLogs([FromRoute] int greenhouseId)
    {
        try
        {
            {
                List<Log> logs = _iDataManager.GetAllLogs(greenhouseId).Result;
                return Ok(logs);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500,e.Message);
        }
    }
    [HttpGet]
    [Route("Logs/LastUpdate/{greenhouseId}")]
    public async Task<ActionResult<Log>> GetLastLog([FromRoute] int greenhouseId)
    {
        try
        {
            {
                Log log = _iDataManager.GetLastLog(greenhouseId).Result;
                return Ok(log);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500,e.Message);
        }
    }
    [HttpGet]
    [Route("LogsById/{logId}")]
    public async Task<ActionResult<Log>> GetLog(int logId)
    {
        try
        {
            {
                Log log = _iDataManager.GetLog(logId).Result;
                return Ok(log);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500,e.Message);
        }
    }

    [HttpGet]
    [Route("Routine/{plantId}")]
    public async Task<ActionResult<List<Routine>>> GetAllRoutines([FromRoute] int plantId)
    {
        try
        {
            {
                List<Routine> routines = _iDataManager.GetAllRoutines(plantId).Result;
                return Ok(routines);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500,e.Message);
        }
    }

    [HttpGet]
    [Route("Actuator")]
    public async Task<ActionResult<bool>> SetActuatorTrue([FromRoute] int greenhouseId)
    {
        try
        {
            {
                bool result = _iDataManager.SetActuatorTrue(greenhouseId).Result;
                return Ok(result);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500,e.Message);
        }
    }
}
