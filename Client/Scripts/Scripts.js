const APIURL = "https://localhost:7160/api/";

let user = undefined;
let cars = undefined;

function login() {
  let email = document.forms["LoginForm"]["email"].value;
  let password = document.forms["LoginForm"]["password"].value;
  const data = { email: email, password: password };
  fetch(APIURL + "user/login", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(data),
  })
    .then((x) => (x = x.json()))
    .then((x) => {
      if (typeof x === null) {
        //uzytkownik o takim emailu nie istnieje, wyswietlic informacje ze logowanie sie nie powiodlo
      }
      user = x;
      localStorage.setItem("user", JSON.stringify(user));
      redirect("login.html", "home.html");
    });
}
function register() {
  let email = document.forms["RegisterForm"]["email"].value;
  let password = document.forms["RegisterForm"]["password"].value;
  let name = document.forms["RegisterForm"]["name"].value;
  let surname = document.forms["RegisterForm"]["surname"].value;
  let verifypassword = document.forms["RegisterForm"]["verifyPassword"].value;
  if (password !== verifypassword) {
    let msg = document.getElementById("msg");
    msg.style.display = "block";
    return;
  }
  const data = {
    email: email,
    password: password,
    name: name,
    surname: surname,
  };
  fetch(APIURL + "user/register", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(data),
  }).then(() => {
    alert("Register Succeed!");
    redirect("register.html", "login.html");
  });
}

function loadCars(carType) {
  let url = APIURL + "Car/getCarsByType?carType=" + carType;
  console.log(url);
  fetch(url, {
    method: "GET",
    headers: {
      "Content-Type": "application/json",
    },
  })
    .then((x) => (x = x.json()))
    .then((x) => (cars = x))
    .then(() => {
      //przeniesc do nowej strony html z listą aut
      //stworzyc nowa strone. stworzyc diva o klasie "car-list", a na dole template z autem
      //wyswietlic dane na stronie
    });
}

function redirect(oldUrl, newUrl) {
  let url = window.location.href;
  url = url.replace(oldUrl, newUrl);
  window.location.href = url;
}
