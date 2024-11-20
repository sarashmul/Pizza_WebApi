
namespace MyModelsLib;

public class Worker
{
    public string NameOfWorker { get; set; }
    public int Id { get; set; }
    public int Hours { get; set; }

    public Worker(string nameOfWorker, int id, int hours){
        NameOfWorker = nameOfWorker;
        Id = id;
        Hours = hours;
    }
}