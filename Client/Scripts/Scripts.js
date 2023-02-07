const APIURL = "https://localhost:7160/api/";

let user = undefined;

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
    .then((x) => {
      x = x.json();
    })
    .then((x) => {
      if (typeof x === null) {
        let msg1 = document.getElementById("msg1");
        msg1.style.display = "block";
        return;
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
  localStorage.setItem("carType", carType);
  redirect("home.html","cars.html")
  
}

function redirect(oldUrl, newUrl) {
  let url = window.location.href;
  url = url.replace(oldUrl, newUrl);
  window.location.href = url;
}
