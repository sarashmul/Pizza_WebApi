namespace MyModelsLib.Interface;
public interface IWorkerService{
  public string SWGetById(int id);
  public bool SWPost(string nameOfWorker,int id,int hours );
  public bool SWputName(int id, string name);
  public void SWputHours(int id, int hours);
  public void SWDel(int id);
}