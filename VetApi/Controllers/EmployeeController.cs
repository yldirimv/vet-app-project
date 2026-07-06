using Dapper;
using Microsoft.AspNetCore.Mvc;
using VetApi.Models;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok(Context.Listeleme<EmployeeModel>("EmployeeViewAll"));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        DynamicParameters param = new DynamicParameters();
        param.Add("@EmployeeId", id);
        return Ok(Context.Listeleme<EmployeeModel>("EmployeeViewById", param).FirstOrDefault());
    }

    [HttpPost]
    public IActionResult EditCreate(EmployeeModel employee)
    {
        DynamicParameters param = new DynamicParameters();
        param.Add("@EmployeeId", employee.EmployeeId);
        param.Add("@NameSurname", employee.NameSurname);
        param.Add("@Email", employee.Email);
        param.Add("@Password", employee.Password);
        param.Add("@Branch", employee.Branch);
        param.Add("@PhoneNumber", employee.PhoneNumber);
        Context.ExecuteReturn("EmployeeEditCreate", param);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        DynamicParameters param = new DynamicParameters();
        param.Add("@EmployeeId", id);
        Context.ExecuteReturn("EmployeeDelete", param);
        return Ok();
    }

    [HttpPost("login")]
    public IActionResult Login(EmployeeModel employee)
    {
        DynamicParameters param = new DynamicParameters();
        param.Add("@Email", employee.Email);
        param.Add("@Password", employee.Password);
        var result = Context.Listeleme<EmployeeModel>("EmployeeLoginCheck", param).FirstOrDefault();

        if (result == null)
            return Unauthorized("Email veya şifre hatalı.");

        return Ok(result);
    }

    [HttpGet("searchbyname")]
    public IActionResult SearchByName(string keyword)
    {
        DynamicParameters param = new DynamicParameters();
        param.Add("@Keyword", keyword);
        return Ok(Context.Listeleme<EmployeeModel>("EmployeeSearchByName", param));
    }

    [HttpGet("searchbybranch")]
    public IActionResult SearchByBranch(string keyword)
    {
        DynamicParameters param = new DynamicParameters();
        param.Add("@Keyword", keyword);
        return Ok(Context.Listeleme<EmployeeModel>("EmployeeSearchByBranch", param));
    }
}