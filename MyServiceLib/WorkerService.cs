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



   public class WorkerService : IWorkerService
    {

    private IWorkerService W;

    IFileService<Worker> _File;
    public WorkerService( IFileService<Worker> f)
    {
        _File = f;
    }
    private string _path=@"H:\webapi\lesson8\WebApi\lesson2\workers.json";
// public List<Worker> WorkerList1=new List<Worker>(){
//     new Worker("yoram",105,5,"admin"),
//     new Worker("abir",103,7,"superWorker"),
//     new Worker("jeq",107,12,"worker"),
//     new Worker("yosef",109,10,"worker")
// };


public Worker SWGetById(int id){
    var WorkerList= _File.Read(_path);
    foreach(Worker p in WorkerList)
        if(p.Id==id)return p;
    return null;
}



public bool SWPost(string nameOfWorker,int id,int hours,string role,string password){
Worker worker =new Worker(nameOfWorker, id, hours,role,password);
 _File.Write(worker,_path);
if(this.SWGetById(id)!=null)
   return true;
return false;
}


public bool SWputName(int id, string name){
     var WorkerList= _File.Read(_path);
    foreach(Worker p in WorkerList)
        if(p.Id==id) {
             p.NameOfWorker = name;
             _File.Update(WorkerList,_path);
             return true;
        }
    return false;    
  
}


public void SWputHours(int id, int hours){
    var WorkerList= _File.Read(_path);
    foreach(Worker p in WorkerList)
        if(p.Id==id) {
           p.Hours = hours;
           _File.Update(WorkerList,_path);
        } 
  
}



  public void SWDel(int id){
    var WorkerList = _File.Read(_path);
    foreach(var i in WorkerList){
        if(i.Id==id) { 
            WorkerList.Remove(i);
            _File.Update(WorkerList, _path);
            }
            }
  
}

   } 
