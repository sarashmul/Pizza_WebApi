namespace MyModelsLib;

public class Order
{
    public string NameOfCustumer { get; set; }
    public int Id { get; set; }
   

    public Order(string nameOfWorker, int id){
        NameOfCustumer = nameOfWorker;
        Id = id;
    }
}