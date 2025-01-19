var baseURL = "http://localhost:5125";
var token="";


function login() {
    var user={};
    user.Password=document.getElementById('password').value;
    user.Name=document.getElementById('namel').value;
    console.log(user);




    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");
    var raw = JSON.stringify(user);

    const requestOptions = {
        method: "POST",
        // redirect: "follow"
        headers: myHeaders,
        body: raw
      };
      fetch(`${baseURL}/Login/Login?name=${user.Name}&password=${user.Password}`, requestOptions)
        .then((response) => response.text())
        .then((result) =>{
          token = result;
          document.getElementById('loginSection').style.display = 'none'; // Hide login section
          document.getElementById('pizzaSection').style.display = 'block'; // Show pizza section
      })
        .catch((error) => console.error(error))
        
        ;


}



function addPizza() {
  console.log("(token in add)", token);
    var pizza={};
    pizza.Id=document.getElementById('id').value;
    pizza.Name=document.getElementById('name').value;
    pizza.IsGlotan=document.getElementById('glotan').value;
    console.log(pizza);
    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");
    myHeaders.append("Authorization", `Bearer ${token}`);

    var raw = JSON.stringify(pizza);

    const requestOptions = {
        method: "POST",
        // redirect: "follow"
        headers: myHeaders,
        body: raw
      };
      
      fetch(`${baseURL}/MyPizza/Post?nameOfPizza=${pizza.Name}&id=${pizza.Id}&glotan=${pizza.IsGlotan}`, requestOptions)
        .then((response) => response.text())
        .then((result) => console.log(result))
        .catch((error) => console.error(error));


}










// function afterPost(params) {
//     alert("");
//     load();
// }

//לפןנקצית get
// const requestOptions = {
//     method: "GET",
//     redirect: "follow"
//   };
  
//   fetch("http://localhost:5125/MyPizza/GetById/105", requestOptions)
//     .then((response) => response.text())
//     .then((result) => console.log(result))
//     .catch((error) => console.error(error));