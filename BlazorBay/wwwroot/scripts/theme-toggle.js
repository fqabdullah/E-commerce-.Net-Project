document.addEventListener("DOMContentLoaded", function () {
    const toggleButton = document.getElementById("themeToggleBtn");
    const body = document.body;

    // Load saved theme preference
    const savedTheme = localStorage.getItem("theme");
    if (savedTheme === "dark") {
        body.classList.add("dark-mode");
        toggleButton.innerHTML = '<i class="bi bi-sun-fill"></i>';
    }

    if (toggleButton) {
        toggleButton.addEventListener("click", function () {
            const isDark = body.classList.toggle("dark-mode");
            localStorage.setItem("theme", isDark ? "dark" : "light");

            toggleButton.innerHTML = isDark
                ? '<i class="bi bi-sun-fill"></i>'
                : '<i class="bi bi-moon-stars"></i>';
        });
    } else {
        console.warn("Theme toggle button not found.");
    }
});
