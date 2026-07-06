using Dapper;
using Microsoft.AspNetCore.Mvc;
using VetApi.Models;

[ApiController]
[Route("api/[controller]")]
public class TreatmentController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok(Context.Listeleme<TreatmentModel>("TreatmentViewAll"));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        DynamicParameters param = new DynamicParameters();
        param.Add("@TreatmentId", id);
        return Ok(Context.Listeleme<TreatmentModel>("TreatmentViewById", param).FirstOrDefault());
    }

    [HttpPost]
    public IActionResult EditCreate(TreatmentModel treatment)
    {
        DynamicParameters param = new DynamicParameters();
        param.Add("@TreatmentId", treatment.TreatmentId);
        param.Add("@TreatmentName", treatment.TreatmentName);
        param.Add("@TreatmentDate", treatment.TreatmentDate);
        param.Add("@PetId", treatment.PetId);
        param.Add("@EmployeeId", treatment.EmployeeId);
        param.Add("@MedicineId", treatment.MedicineId);
        Context.ExecuteReturn("TreatmentEditCreate", param);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        DynamicParameters param = new DynamicParameters();
        param.Add("@TreatmentId", id);
        Context.ExecuteReturn("TreatmentDelete", param);
        return Ok();
    }

    [HttpGet("searchbydate")]
    public IActionResult SearchByDate(DateTime date)
    {
        DynamicParameters param = new DynamicParameters();
        param.Add("@Date", date);
        return Ok(Context.Listeleme<TreatmentModel>("TreatmentSearchByDate", param));
    }

    [HttpGet("searchbypetname")]
    public IActionResult SearchByPetName(string keyword)
    {
        DynamicParameters param = new DynamicParameters();
        param.Add("@Keyword", keyword);
        return Ok(Context.Listeleme<TreatmentModel>("TreatmentSearchByPetName", param));
    }

    [HttpGet("searchbypettype")]
    public IActionResult SearchByPetType(string keyword)
    {
        DynamicParameters param = new DynamicParameters();
        param.Add("@Keyword", keyword);
        return Ok(Context.Listeleme<TreatmentModel>("TreatmentSearchByPetType", param));
    }

    [HttpGet("searchbydoctorname")]
    public IActionResult SearchByDoctorName(string keyword)
    {
        DynamicParameters param = new DynamicParameters();
        param.Add("@Keyword", keyword);
        return Ok(Context.Listeleme<TreatmentModel>("TreatmentSearchByDoctorName", param));
    }

    [HttpGet("bymonth")]
    public IActionResult GetByMonth()
    {
        return Ok(Context.Listeleme<TreatmentByMonthModel>("TreatmentByMonth"));
    }
}