using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;

using MyModelsLib.Interface;
namespace lesson2.Controllers;

public class WorkerController : BaseCcntroller
{

IWorkerService _w;
public WorkerController (IWorkerService w)
{
    _w = w;
}

[Route("[action]/{id}")]
[HttpGet]
// public async Task<ActionResult> GetById(int id){
// await _M.SGetById(id);
// return Ok();
// }

public IActionResult WGetById(int id){
    var Worker = _w.SWGetById(id);
    if (Worker==null){
        return NotFound();
    }
     return Ok();
}


[Route("[action]")]
[HttpPost]
public IActionResult WPost(string nameOfWorker,int id,int hourS ){
 var add = _w.SWPost(nameOfWorker,id,hourS); 
 if  (add)
        return Ok();
  return NotFound();
}


[Route("[action]/{id}/{name}")]
[HttpPut]
public IActionResult WputName(int id, string name){
   var d=_w.SWputName(id, name);
        if(d) 
             return Ok();
    return NotFound();  
  
}

[Route("[action]/{id}/{glotan}")]
[HttpPut]
public void WputHours (int id, int hours ){
    _w.SWputHours(id, hours);
  
}

[Route("[action]/{id}")]
[HttpDelete]
public void Del(int id){
   _w.SWDel(id);
  
}
}

