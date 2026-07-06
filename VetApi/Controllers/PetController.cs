using Dapper;
using Microsoft.AspNetCore.Mvc;
using VetApi.Models;

[ApiController]
[Route("api/[controller]")]
public class PetController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok(Context.Listeleme<PetModel>("PetViewAll"));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        DynamicParameters param = new DynamicParameters();
        param.Add("@PetId", id);
        return Ok(Context.Listeleme<PetModel>("PetViewById", param).FirstOrDefault());
    }

    [HttpPost]
    public IActionResult EditCreate(PetModel pet)
    {
        DynamicParameters param = new DynamicParameters();
        param.Add("@PetId", pet.PetId);
        param.Add("@PetName", pet.PetName);
        param.Add("@PetType", pet.PetType);
        param.Add("@Age", pet.Age);
        param.Add("@Address", pet.Address);
        param.Add("@OwnerPhone", pet.OwnerPhone);
        Context.ExecuteReturn("PetEditCreate", param);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        DynamicParameters param = new DynamicParameters();
        param.Add("@PetId", id);
        Context.ExecuteReturn("PetDelete", param);
        return Ok();
    }

    [HttpGet("searchbyname")]
    public IActionResult SearchByName(string keyword)
    {
        DynamicParameters param = new DynamicParameters();
        param.Add("@Keyword", keyword);
        return Ok(Context.Listeleme<PetModel>("PetSearchByName", param));
    }

    [HttpGet("searchbytype")]
    public IActionResult SearchByType(string keyword)
    {
        DynamicParameters param = new DynamicParameters();
        param.Add("@Keyword", keyword);
        return Ok(Context.Listeleme<PetModel>("PetSearchByType", param));
    }
}