using Dapper;
using Microsoft.AspNetCore.Mvc;
using VetApi.Models;

[ApiController]
[Route("api/[controller]")]
public class MedicineController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok(Context.Listeleme<MedicineModel>("MedicineViewAll"));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        DynamicParameters param = new DynamicParameters();
        param.Add("@MedicineId", id);
        return Ok(Context.Listeleme<MedicineModel>("MedicineViewById", param).FirstOrDefault());
    }

    [HttpPost]
    public IActionResult EditCreate(MedicineModel medicine)
    {
        DynamicParameters param = new DynamicParameters();
        param.Add("@MedicineId", medicine.MedicineId);
        param.Add("@MedName", medicine.MedName);
        param.Add("@UsageDescription", medicine.UsageDescription);
        param.Add("@MedicineType", medicine.MedicineType);
        Context.ExecuteReturn("MedicineEditCreate", param);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        DynamicParameters param = new DynamicParameters();
        param.Add("@MedicineId", id);
        Context.ExecuteReturn("MedicineDelete", param);
        return Ok();
    }

    [HttpGet("searchbyname")]
    public IActionResult SearchByName(string keyword)
    {
        DynamicParameters param = new DynamicParameters();
        param.Add("@Keyword", keyword);
        return Ok(Context.Listeleme<MedicineModel>("MedicineSearchByName", param));
    }

    [HttpGet("searchbytype")]
    public IActionResult SearchByType(string keyword)
    {
        DynamicParameters param = new DynamicParameters();
        param.Add("@Keyword", keyword);
        return Ok(Context.Listeleme<MedicineModel>("MedicineSearchByType", param));
    }
}