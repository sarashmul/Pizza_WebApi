using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using MyModelsLib.Interface;
namespace lesson2.Controllers;

public class OrderController : BaseCcntroller
{

IOrderService  _o;
public OrderController (IOrderService o)
{
    _o = o;
}

[Route("[action]/{id}")]
[HttpGet]
// public async Task<ActionResult> GetById(int id){
// await _M.SGetById(id);
// return Ok();
// }

public IActionResult OGetById(int id){
    var Order = _o.SOGetById(id);
    if (Order!=null){
            Console.WriteLine("in if");

        return Ok(Order);
    }
        Console.WriteLine("after if");

     return NotFound();
}
    [Route("[action]")]
    [HttpPost]
    
    public IActionResult OPost(string nameOfWorker, int id ,string numCard, int date ,int cvv)
    {
        var add = _o.SOPost(nameOfWorker,id ,numCard,date ,cvv);
        if (add!=null)
            return Ok(add);
        return NotFound();
    }



}