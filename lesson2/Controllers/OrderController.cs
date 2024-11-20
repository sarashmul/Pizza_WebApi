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
    if (Order==null){
        return NotFound();
    }
     return Ok();
}}