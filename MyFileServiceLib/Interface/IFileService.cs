// using MyModelsLib.Interface;
namespace MyFileServiceLib.Interface;
public interface IFileService<T>{

    List<T> Read(string _path);
    
    void Write(T obj,string _path);

    void Update(List<T> list, string _path);
}