using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using MyModelsLib;
using MyModelsLib.Interface;
using MyFileServiceLib;
using  MyFileServiceLib.Interface;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
namespace lesson2.Controllers;
// using MyFileServiceLib;
// using  MyFileServiceLib.Interface;


public class MyPizzaController : BaseCcntroller
{

IPizzaService _M;
IFileService<MyPizza> _File;
public MyPizzaController(IPizzaService p, IFileService<MyPizza> f)
{
    _M = p;
    _File = f;
}

// [Route("[action]/{add}")]
// [HttpPost]
// public IActionResult Add(int id,bool isGlotan,string nameOfPizza){
//     var PizzaAdd=_M.SAdd(id,isGlotan,nameOfPizza);
//     if(!PizzaAdd){
//        return NotFound();
//     }
//      return Ok();
// }



[Route("[action]/{id}")]
[HttpGet]
// public async Task<ActionResult> GetById(int id){
// await _M.SGetById(id);
// return Ok();
// }

public IActionResult GetById([Range(1,1000)]int id){
    var PizzaName = _M.SGetById(id);
    Console.WriteLine(PizzaName);
    if (PizzaName==null){
        return NotFound("this pizza is not found");
    }
     return Ok(PizzaName);
}


[Route("[action]")]
[HttpPost]
[Authorize(Policy = "SuperWorker")]
public IActionResult Post([FromQuery]string nameOfPizza,int id,bool glotan ){
 var add = _M.SPost(nameOfPizza,id,glotan); 
 if  (add)
        return Ok();
  return NotFound();
}


[Route("[action]/{id}/{name}")]
[HttpPut]
[Authorize(Policy = "SuperWorker")]
public IActionResult putName(int id, string name){
   var d=_M.SputName(id, name);
        if(d) 
             return Ok();
    return NotFound();  
  
}

[Route("[action]/{id}/{glotan}")]
[HttpPut]
[Authorize(Policy = "SuperWorker")]
public void putGlotan(int id, bool glotan){
    _M.SputGlotan(id, glotan);
  
}

[Route("[action]/{id}")]
[HttpDelete]
[Authorize(Policy = "SuperWorker")]
public void Del(int id){
   _M.SDel(id);
  
}


}

