// using System;
// using System.Net.Http;
// using System.Text;
// using System.Text.Json;
// using System.Threading.Tasks;
// using lesson2.Modells;
using System.Configuration;
using MyModelsLib;
using MyModelsLib.Interface;
using MyFileServiceLib;
using MyFileServiceLib.Interface;
namespace MyServiceLib;


public class PizzaService : IPizzaService 
{
    
    private IPizzaService I;
    IFileService<MyPizza> _File;
    public PizzaService( IFileService<MyPizza> f)
    {
        _File = f;
    }
    private string _path=@"H:\webapi\lesson8\WebApi\lesson2\pizzacollections.json";
    public List<MyPizza> Pizzalist=new List<MyPizza>(){
    new MyPizza("bazzal",105,true),
    new MyPizza("pitriot",103,false),
    new MyPizza("agvania",107,true),
    new MyPizza("zeitim",109,true)
};

// public bool SAdd(int id,bool isGlotan,string nameOfPizza){
//     MyPizza p=new MyPizza(nameOfPizza,id,isGlotan);
//     return true;
// }
public MyPizza SGetById(int id){
      var PizzaList= _File.Read(_path);
        foreach (MyPizza p in PizzaList)
        if(p.Id==id)return p;
     return null;
}

    //File.Create("PizzaJson.json");

public bool SPost(string nameOfPizza,int id,bool glotan ){
        MyPizza pizza =new MyPizza(nameOfPizza, id, glotan);
        _File.Write(pizza,@"H:\webapi\lesson8\WebApi\lesson2\pizzacollections.json");
        if(this.SGetById(id)!=null)
           return true;
        return false;
}


public bool SputName(int id, string name){
        var PizzaList = _File.Read(_path);

    foreach (MyPizza p in PizzaList)
            if (p.Id == id)
            {
                p.NameOfPizza = name;
                _File.Update(PizzaList, _path);
                return true;
            }
        return false;

    }


public void SputGlotan(int id, bool glotan){
        var PizzaList = _File.Read(_path);

    foreach (MyPizza p in PizzaList)
            if (p.Id == id)
            {
                p.IsGlotan = glotan;
                _File.Update(PizzaList,_path);
                
            }
}


public void SDel(int id){
        var PizzaList = _File.Read(_path);

       foreach(var i in Pizzalist){
           if(i.Id==id) {
            Pizzalist.Remove(i);
            _File.Update(PizzaList, _path);
           }
                
            }
  
}

   } 
