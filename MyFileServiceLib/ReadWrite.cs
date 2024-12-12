using System.Net;
using System.Security.AccessControl;
using System.IO;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using MyFileServiceLib;
using MyFileServiceLib.Interface;
using MyModelsLib;
namespace MyFileServiceLib;

public class ReadWrite<T> : IFileService<T>
{
    private readonly string _path;
    public ReadWrite(string path)
    {
       _path = path;
    }
    public List<T> Read(string _path)
    {
        var list = new List<T>();
        var text = File.ReadAllText(_path);
        if (!string.IsNullOrEmpty(text))
        {
            list = JsonConvert.DeserializeObject<List<T>>(text);
        }
        return list;
    }
    public void Write(T obj,string _path)
    {
        var list = Read(_path);
        list.Add(obj);
        File.WriteAllText(_path, JsonConvert.SerializeObject(list));
    }
    public void Update(List<T> list, string _path)
    {
       File.WriteAllText(_path, JsonConvert.SerializeObject(list));
    }

}

