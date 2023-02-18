const adminPanelButton = document.querySelector(".admin-panel");

window.addEventListener("load", () => {
  const role = getUserRoleFromToken();
  console.log(role);
  if (role === "1") {
    adminPanelButton.style.display = "block";
  }
});

function getUserRoleFromToken() {
  const token = localStorage.getItem("token");
  const t = JSON.parse(atob(token.split(".")[1]));
  return t["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
}

