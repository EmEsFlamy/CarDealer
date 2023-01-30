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
    .then((x) => (x = x.json()))
    .then((x) => {
      user = x;
      localStorage.setItem("user", JSON.stringify(user));
      console.log(user);
    });
}
function register() {
  let email = document.forms["RegisterForm"]["email"].value;
  let password = document.forms["RegisterForm"]["password"].value;
  let name = document.forms["RegisterForm"]["name"].value;
  let surname = document.forms["RegisterForm"]["surname"].value;
  let verifypassword = document.forms["RegisterForm"]["verifyPassword"].value;
  if (password !== verifypassword) {
    // dodać informacje o tym, że hasła są różne
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
  }).then(() => console.log("zarejestrowano"));
}
