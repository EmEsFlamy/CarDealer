const APIURL = "https://localhost:7160/api/";

function addCar() {
  const carType = Number(document.forms["CarsAddForm"]["CarType"].value);
  const mark = document.forms["CarsAddForm"]["Mark"].value;
  const model = document.forms["CarsAddForm"]["Model"].value;
  const price = document.forms["CarsAddForm"]["Price"].value;
  const data = {
    carType,
    mark,
    model,
    price,
  };
  const token = localStorage.getItem("token");
  fetch(APIURL + "car", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${token}`,
    },
    body: JSON.stringify(data),
  })
    .then((x) => {
      alert("Car created!");
      redirect("adminCarsAdd.html", "adminPanel.html");
    })
    .catch((err) => {});
}

function redirect(oldUrl, newUrl) {
  let url = window.location.href;
  url = url.replace(oldUrl, newUrl);
  window.location.href = url;
}
function backAdm() {
    redirect("adminCarsAdd.html", "adminPanel.html");
}
