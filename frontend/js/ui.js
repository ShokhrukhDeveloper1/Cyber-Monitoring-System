// ================================
// SIDEBAR ACTIVE LINK
// ================================
document.addEventListener("DOMContentLoaded", () => {
  const links = document.querySelectorAll(".sidebar-menu a");
  const currentPage = window.location.pathname.split("/").pop();

  links.forEach(link => {
    if (link.getAttribute("href") === currentPage) {
      link.classList.add("active");
    } else {
      link.classList.remove("active");
    }
  });
});

// ================================
// FAKE LOGIN
// ================================
function login() {
  const username = document.getElementById("username").value;
  const password = document.getElementById("password").value;

  if (!username || !password) {
    alert("Username and password required!");
    return;
  }

  localStorage.setItem("auth", "true");
  window.location.href = "pages/dashboard.html";
}

// ================================
// TABLE SEARCH FILTER
// ================================
document.addEventListener("DOMContentLoaded", () => {
  const input = document.getElementById("searchInput");
  if (!input) return;

  input.addEventListener("keyup", () => {
    const filter = input.value.toLowerCase();
    const rows = document.querySelectorAll("tbody tr");

    rows.forEach(row => {
      row.style.display = row.innerText.toLowerCase().includes(filter)
        ? ""
        : "none";
    });
  });
});

// ===== USER DROPDOWN =====
const userBtn = document.getElementById("userMenuBtn");
const dropdown = document.getElementById("userDropdown");

if (userBtn) {
  userBtn.addEventListener("click", () => {
    dropdown.style.display =
      dropdown.style.display === "block" ? "none" : "block";
  });
}

// tashqariga bosilsa yopiladi
document.addEventListener("click", (e) => {
  if (!e.target.closest(".dropdown")) {
    if (dropdown) dropdown.style.display = "none";
  }
});

// ===== LOGOUT =====
function logout() {
  // hozircha fake logout
  window.location.href = "../index.html";
}
