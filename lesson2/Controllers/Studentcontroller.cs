using Microsoft.AspNetCore.Mvc;

namespace lesson2.Controllers;

public class Studentcontroller : BaseCcntroller
{
[Route("[action]")]
[HttpGet]
public string GetById(int id){
    return "the student is:" + id;
}
}