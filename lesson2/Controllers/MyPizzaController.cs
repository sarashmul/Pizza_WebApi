using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using MyModelsLib.Interface;
namespace lesson2.Controllers;

public class MyPizzaController : BaseCcntroller
{

IPizzaService _M;
public MyPizzaController(IPizzaService p)
{
    _M = p;
}

[Route("[action]/{id}")]
[HttpGet]
// public async Task<ActionResult> GetById(int id){
// await _M.SGetById(id);
// return Ok();
// }

public IActionResult GetById(int id){
    var PizzaName = _M.SGetById(id);
    if (PizzaName==null){
        return NotFound();
    }
     return Ok();
}


[Route("[action]")]
[HttpPost]
public IActionResult Post(string nameOfPizza,int id,bool glotan ){
 var add = _M.SPost(nameOfPizza,id,glotan); 
 if  (add)
        return Ok();
  return NotFound();
}


[Route("[action]/{id}/{name}")]
[HttpPut]
public IActionResult putName(int id, string name){
   var d=_M.SputName(id, name);
        if(d) 
             return Ok();
    return NotFound();  
  
}

[Route("[action]/{id}/{glotan}")]
[HttpPut]
public void putGlotan(int id, bool glotan){
    _M.SputGlotan(id, glotan);
  
}

[Route("[action]/{id}")]
[HttpDelete]
public void Del(int id){
   _M.SDel(id);
  
}
}

