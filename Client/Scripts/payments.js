const paymentList = document.querySelector("#paymentList");
const template = document.querySelector("#payment-template");

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
      paymentList.innerHTML = "";
      res.forEach((payment) => {
        createPaymentDiv(payment);
      });
    });
});

function createPaymentDiv(payment) {
  const clone = template.content.cloneNode(true);
  const id = clone.querySelector(".paymentId");
  id.innerHTML = payment.id;
  paymentList.appendChild(clone);
}
