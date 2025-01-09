// using System;
// using System.Collections.Generic;
// using System.IdentityModel.Tokens.Jwt;
// using System.Linq;
// using System.Security.Claims;
// using System.Text;
// using System.Threading.Tasks;
// using Microsoft.IdentityModel.Tokens;
// //using lesson2.login.ILoginService;
// using MyModelsLib;
// using MyModelsLib.Interface;
// using MyFileServiceLib;
// using MyFileServiceLib.Interface;
// using lesson2.login;
// namespace lesson2.login;




// public class LoginService:ILoginService{

//      private readonly ILoginService _I; 
//       public IFileService<Worker> _File;
//     public LoginService(ILoginService I, IFileService<Worker> f)
//     {
//         _I=I;
//         _File = f;
//     }
//     private readonly string _path=@"H:\webapi\lesson8\WebApi\lesson2\workers.json";
//     public bool IsExist(string username, string password) {
//        var WorkerList= _File.Read(_path);
//         foreach (Worker p in WorkerList){
//             if (p.Password.Equals(password))
//             return true;
//         }
       
//      return false;

//     }
// }





// using System.Collections.Generic;
// using MyModelsLib;
// using MyModelsLib.Interface;

// namespace lesson2.login
// {
//     public class LoginService : ILoginService
//     {
//         private readonly IFileService<Worker> _fileService; 
//         private readonly string _path = @"H:\webapi\lesson8\WebApi\lesson2\workers.json";

//         public LoginService(IFileService<Worker> fileService)
//         {
//             _fileService = fileService;
//         }

//         public bool IsExist(string username, string password)
//         {
//             var workerList = _fileService.Read(_path);
//             foreach (Worker worker in workerList)
//             {
//                 if (worker.NameOfWorker.Equals(username) && worker.Password.Equals(password))
//                     return true;
//             }

//             return false;
//         }
//     }
// }



 using System;
// using System.Collections.Generic;
// using System.IdentityModel.Tokens.Jwt;
// using System.Linq;
// using System.Security.Claims;
// using System.Text;
// using System.Threading.Tasks;
// using Microsoft.IdentityModel.Tokens;
// //using lesson2.login.ILoginService;
// using MyModelsLib;
// using MyModelsLib.Interface;
// using MyFileServiceLib;
// using MyFileServiceLib.Interface;

// using System.Collections.Generic;
 using MyModelsLib;
// using MyModelsLib.Interface;
 using MyFileServiceLib;
 using MyFileServiceLib.Interface;
// using lesson2.login;
using MyModelsLib.Interface;


namespace lesson2.login

{

public class LoginService : ILoginService

{

private readonly IFileService<Worker> _fileService;


public LoginService(IFileService<Worker> fileService) => _fileService = fileService;


public bool IsExist(string username, string password)

{

var workerList = _fileService.Read(@"H:\webapi\lesson8\WebApi\lesson2\workers.json");

foreach (Worker worker in workerList)

{

if (worker.NameOfWorker.Equals(username) && worker.Password.Equals(password))

return true;

}

return false;

}

}

}