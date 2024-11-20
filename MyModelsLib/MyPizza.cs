
namespace MyModelsLib;

public class MyPizza
{
    public string NameOfPizza { get; set; }
    public int Id { get; set; }
    public bool IsGlotan { get; set; }

    public MyPizza(string nameOfPizza, int id, bool isGlotan){
        NameOfPizza = nameOfPizza;
        Id = id;
        IsGlotan = isGlotan;
    }
}