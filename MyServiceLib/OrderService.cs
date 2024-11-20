// using System;
// using System.Net.Http;
// using System.Text;
// using System.Text.Json;
// using System.Threading.Tasks;
// using lesson2.Modells;
using MyModelsLib;
using MyModelsLib.Interface;

namespace MyServiceLib;


   public class OrderService : IOrderService
    {

    private IOrderService O;
public List<Order> OrderList=new List<Order>(){
    new Order("yoram",105),
    new Order("abir",103),
    new Order("jeq",107),
    new Order("yosef",109)
};


public string SOGetById(int id){
    foreach(Order p in OrderList)
        if(p.Id==id)return "the name of worker is: "+p.NameOfCustumer ;
    return null;
}}