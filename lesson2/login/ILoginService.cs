
using MyModelsLib;

namespace lesson2.login;

    public interface ILoginService{
     
     public Worker IsExist(string username, string password);
    }
