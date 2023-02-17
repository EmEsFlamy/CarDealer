const carlist = document.querySelector("#car-list");
const template = document.querySelector("#car-template");
const reserveButton = document.querySelector("#reserveButton");

let cars = undefined;
let selectedCar = undefined;
let startDate;
let endDate;

window.addEventListener("load", () => {
  const carType = localStorage.getItem("carType");
  const url = APIURL + "Car/getCarsByType?carType=" + carType;
  const token = localStorage.getItem("token");
  fetch(url, {
    method: "GET",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${token}`,
    },
  })
    .then((x) => (x = x.json()))
    .then((x) => (cars = x))
    .then(() => {
      carlist.innerHTML = "";
      if (cars.length === 0) {
        let msg = document.getElementById("msg2");
        msg.style.display = "block";
      }
      cars.forEach((car, index) => {
        createCarDiv(car, index);
      });
      createCarsEventListener();
    });
});

function createCarDiv(car, index) {
  const clone = template.content.cloneNode(true);
  const mark = clone.querySelector("#car-mark");
  const model = clone.querySelector("#car-model");
  const price = clone.querySelector("#car-price");
  const radioValue = clone.getElementById("car-value");
  mark.innerHTML = car.mark;
  model.innerHTML = car.model;
  price.innerHTML = car.price;
  radioValue.value = index;
  carlist.appendChild(clone);
}

function createCarsEventListener() {
  const cc = carlist.querySelectorAll(".car-container");
  cc.forEach((car) => {
    car.addEventListener("click", (e) => {
      if (e.target.matches("input")) {
        const index = e.target.value;
        selectedCar = cars.at(index);
      }
    });
    car.addEventListener("change", (e) => {
      if (e.target.matches("input")) {
        selectCar(car);
      }
    });
  });
}

function selectCar(car) {
  startDate = car.querySelector(".start-date").value;
  endDate = car.querySelector(".end-date").value;
  if (
    startDate.length === 0 ||
    endDate.length === 0 ||
    new Date(startDate).getTime() > new Date(endDate).getTime()
  ) {
    reserveButton.disabled = true;
    return;
  }
  reserveButton.disabled = false;
}

function makeOrder() {
  const data = {
    userId: getUserIdFromToken(),
    carId: selectedCar.id,
    startDate: startDate,
    endDate: endDate,
  };
  const token = localStorage.getItem("token");
  fetch(APIURL + "order", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${token}`,
    },
    body: JSON.stringify(data),
  });
  alert("Order done!");
  redirect("cars.html", "home.html");
}

function getUserIdFromToken() {
  const token = localStorage.getItem("token");
  const t = JSON.parse(atob(token.split(".")[1]));
  return t[
    "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"
  ];
}
