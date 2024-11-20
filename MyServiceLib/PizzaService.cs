// using System;
// using System.Net.Http;
// using System.Text;
// using System.Text.Json;
// using System.Threading.Tasks;
// using lesson2.Modells;
using MyModelsLib;
using MyModelsLib.Interface;

namespace MyServiceLib;



   public class PizzaService : IPizzaService
    {

    private IPizzaService I;
public List<MyPizza> Pizzalist=new List<MyPizza>(){
    new MyPizza("bazzal",105,true),
    new MyPizza("pitriot",103,false),
    new MyPizza("agvania",107,true),
    new MyPizza("zeitim",109,true)
};


public string SGetById(int id){
    foreach(MyPizza p in Pizzalist)
        if(p.Id==id)return "the pizza is: "+p.NameOfPizza + ",glotan?"+p.IsGlotan;
    return null;
}



public bool SPost(string nameOfPizza,int id,bool glotan ){
Pizzalist.Add(new MyPizza(nameOfPizza,id,glotan));
if(this.SGetById(id)!=null)
   return true;
return false;
}


public bool SputName(int id, string name){
    foreach(MyPizza p in Pizzalist)
        if(p.Id==id) {
             p.NameOfPizza = name;
             return true;
        }
    return false;    
  
}


public void SputGlotan(int id, bool glotan){
    foreach(MyPizza p in Pizzalist)
        if(p.Id==id)  p.IsGlotan = glotan;
  
}


public void SDel(int id){
    foreach(var i in Pizzalist){
        if(i.Id==id)  Pizzalist.Remove(i);}
  
}

   } 
