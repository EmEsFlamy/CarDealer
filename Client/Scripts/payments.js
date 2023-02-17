const paymentList = document.querySelector("#paymentList");
const template = document.querySelector("#payment-template");

let payments = undefined;
let paymentId = undefined;

window.addEventListener("load", () => {
  const url = APIURL + "Payment/GetAllUnpaid";
  const token = localStorage.getItem("token");
  fetch(url, {
    method: "GET",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${token}`,
    },
  })
    .then((x) => (x = x.json()))
    .then((res) => {
      payments = res;
      paymentList.innerHTML = "";
      res.forEach((payment, index) => {
        createPaymentDiv(payment, index);
      });
      createPaymentsEventListener();
    });
});

function createPaymentDiv(payment, index) {
  const clone = template.content.cloneNode(true);
  const name = clone.querySelector(".userName");
  const surname = clone.querySelector(".userSurname");
  const mark = clone.querySelector(".carMark");
  const model = clone.querySelector(".carModel");
  const startDate = clone.querySelector(".startDate");
  const endDate = clone.querySelector(".endDate");
  const price = clone.querySelector(".carPrice");
  const radioValue = clone.getElementById("payment-value");
  radioValue.value = index;
  name.innerHTML = payment.userName;
  surname.innerHTML = payment.userSurname;
  mark.innerHTML = payment.mark;
  model.innerHTML = payment.model;
  startDate.innerHTML = payment.startDate;
  endDate.innerHTML = payment.endDate;
  price.innerHTML = payment.price;
  paymentList.appendChild(clone);
}

function createPaymentsEventListener() {
  const cc = paymentList.querySelectorAll(".payment-container");
  cc.forEach((payment) => {
    payment.addEventListener("click", (e) => {
      if (e.target.matches("input")) {
        const index = e.target.value;
        selectedPaymentId = payments.at(index).paymentId;
        console.log(selectedPaymentId);
      }
    });
  });
}

function pay() {
  const data = {
    id: selectedPaymentId
  };
  const token = localStorage.getItem("token")
  fetch(APIURL + "payment/MarkAsPaid", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      "Authorization": `Bearer ${token}`
    },
    body: JSON.stringify(data),
  });
}
