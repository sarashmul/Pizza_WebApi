// using System;
// using System.Net.Http;
// using System.Text;
// using System.Text.Json;
// using System.Threading.Tasks;
// using lesson2.Modells;

using MyModelsLib;
using MyModelsLib.Interface;

namespace MyServiceLib;



   public class WorkerService : IWorkerService
    {

    private IWorkerService W;
public List<Worker> WorkerList=new List<Worker>(){
    new Worker("yoram",105,5),
    new Worker("abir",103,7),
    new Worker("jeq",107,12),
    new Worker("yosef",109,10)
};


public string SWGetById(int id){
    foreach(Worker p in WorkerList)
        if(p.Id==id)return "the name of worker is: "+p.NameOfWorker + "count of work's hours: "+p.Hours;
    return null;
}



public bool SWPost(string nameOfWorker,int id,int hours ){
WorkerList.Add(new Worker(nameOfWorker,id,hours));
if(this.SWGetById(id)!=null)
   return true;
return false;
}


public bool SWputName(int id, string name){
    foreach(Worker p in WorkerList)
        if(p.Id==id) {
             p.NameOfWorker = name;
             return true;
        }
    return false;    
  
}


public void SWputHours(int id, int hours){
    foreach(Worker p in WorkerList)
        if(p.Id==id)  p.Hours = hours;
  
}



  public void SWDel(int id){
    foreach(var i in WorkerList){
        if(i.Id==id)  WorkerList.Remove(i);}
  
}

   } 
