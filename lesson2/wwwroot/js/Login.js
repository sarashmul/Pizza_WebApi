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
    user.Id=document.getElementById('password').value;
    user.Name=document.getElementById('name').value;
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
      
      fetch(`${baseURL}/MyPizza/Post?nameOfPizza=${pizza.Name}&id=${pizza.Id}&glotan=${pizza.IsGlotan}`, requestOptions)
        .then((response) => response.text())
        .then((result) => console.log(result))
        .catch((error) => console.error(error));


}