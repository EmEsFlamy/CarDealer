let cars = undefined;
let selectedCar = undefined;

window.addEventListener("load", () => {
  const carType = localStorage.getItem("carType");
  const url = APIURL + "Car/getCarsByType?carType=" + carType;
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
      const carlist = document.querySelector("#car-list");
      const template = document.querySelector("#car-template");
      carlist.innerHTML = "";
      if (cars.length === 0) {
        let msg = document.getElementById("msg2");
        msg.style.display = "block";
      }
      cars.forEach((car, index) => {
        const clone = template.content.cloneNode(true);
        const name = clone.querySelector("#car-name");
        const price = clone.querySelector("#car-price");
        const radioValue = clone.getElementById("car-value");
        name.innerHTML = car.mark;
        price.innerHTML = car.price;
        radioValue.value = index;
        carlist.appendChild(clone);
      });
    });
});


