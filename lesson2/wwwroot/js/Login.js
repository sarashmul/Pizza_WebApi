var baseURL = "http://localhost:5125";
// function load() {
//     fetch(baseURL + "/lesson2")
//         .then((res) => res.json())
//         .then((data) => fillpizzaTbl(data))
//         .catch((error) => console.log(error))

// }
// function fillpizzaTbl(data) {
//     var table = document.getElementById('pizzalist');
//     data.forEach(function (pizza) {
//         var tr = document.createElement('tr');
//         tr.innerHTML = '<td>' + pizza.id + '</td>' +
//             '<td>' + pizza.name + '</td>' +
//             '<td>' + pizza.isglotan + '</td>' ;
//         var tBody = table.getElementsByTagName('tbody')[0];
//         tBody.appendChild(tr);
//     });
// }
function login() {
    var user={};
    user.Password=document.getElementById('password').value;
    user.Name=document.getElementById('name').value;
    console.log(user);


    // const myHeaders = new Headers();
    // myHeaders.append("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJSb2xlIjoiQWRtaW4iLCJleHAiOjE3Mzk4ODMyOTYsImlzcyI6Imh0dHBzOi8vTXlQaXp6YS5jb20iLCJhdWQiOiJodHRwczovL015UGl6emEuY29tIn0.uwa85bMwQWj4t0UJp6WkVDp6oL2RQdWOoP4tpqzCUGY");
    
    // const requestOptions = {
    //   method: "POST",
    //   headers: myHeaders,
    //   redirect: "follow"
    // };
    
    // fetch("http://localhost:5125/Login/Login?name=sara&password=329", requestOptions)
    //   .then((response) => response.text())
    //   .then((result) => console.log(result))
    //   .catch((error) => console.error(error));

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
        .then((result) => console.log(result))
        .catch((error) => console.error(error))
        const token=result.token
        ;


}