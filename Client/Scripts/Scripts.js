const APIURL = "https://localhost:7160/api/";

let timeout;
let passwordCheck = document.getElementById('registerPassword1');
let strengthBadge = document.getElementById('StrengthDisp');
let strongPassword = new RegExp('(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^A-Za-z0-9])(?=.{8,})')
let mediumPassword = new RegExp('((?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^A-Za-z0-9])(?=.{6,}))|((?=.*[a-z])(?=.*[A-Z])(?=.*[^A-Za-z0-9])(?=.{8,}))')

function login() {
  let email = document.forms["LoginForm"]["email"].value;
  let password = document.forms["LoginForm"]["password"].value;
  if (email === "" || password === "") return; 
  const data = { email, password };
  fetch(APIURL + "user/login", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(data),
  })
    .then((x) => {
      if (x.ok) return x.json();
      return Promise.reject(x);
    })
    .then((x) => {
      localStorage.setItem("token", x.token);
      redirect("login.html", "home.html");
    })
    .catch((err) => {
      let msg1 = document.getElementById("msg1");
      msg1.style.display = "block";
    });
}
function register() {
  const email = document.forms["RegisterForm"]["email"].value;
  const password = document.forms["RegisterForm"]["password"].value;
  const name = document.forms["RegisterForm"]["name"].value;
  const surname = document.forms["RegisterForm"]["surname"].value;
  const verifyPassword = document.forms["RegisterForm"]["verifyPassword"].value;
  if (password !== verifyPassword) {
    let msg = document.getElementById("msg");
    msg.style.display = "block";
    return;
  }
  const data = {
    email,
    password,
    name,
    surname,
  };
  fetch(APIURL + "user/register", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(data),
  })
    .then((x) => {
      if (x.ok) return x.json();
      return Promise.reject(x);
    })
    .then((x) => {
      if (x) {
        alert("Register Succeed!");
        redirect("register.html", "login.html");
      } else {
        let msg = document.getElementById("message");
        msg.style.display = "block";
      }
    })
    .catch((err) => {});
}

function StrengthChecker(PasswordParameter) {
  if(strongPassword.test(PasswordParameter)) {
      strengthBadge.style.backgroundColor = "green";
      strengthBadge.textContent = 'Strong';
  } else if(mediumPassword.test(PasswordParameter)) {
      strengthBadge.style.backgroundColor = 'yellow';
      strengthBadge.textContent = 'Medium';
  } else {
      strengthBadge.style.backgroundColor = 'red';
      strengthBadge.textContent = 'Weak';
  }
}

passwordCheck.addEventListener("input", () => {
  strengthBadge.style.display = 'block';
  clearTimeout(timeout);
  timeout = setTimeout(() => StrengthChecker(passwordCheck.value), 500);
  if(passwordCheck.value.length !== 0) {
      strengthBadge.style.display != 'block';
  } else {
      strengthBadge.style.display = 'none';
  }
});

function logOut() {
  localStorage.clear();
  redirectOnLogOut();
}

function loadCars(carType) {
  localStorage.setItem("carType", carType);
  redirect("home.html", "cars.html");
}

function redirect(oldUrl, newUrl) {
  let url = window.location.href;
  url = url.replace(oldUrl, newUrl);
  window.location.href = url;
}

function redirectOnLogOut() {
  let url = window.location.href;
  const oldUrl = url.split("/").at(-1);
  redirect(oldUrl, "login.html");
}
