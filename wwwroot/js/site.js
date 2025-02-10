document.addEventListener("DOMContentLoaded", function () {
    const toggleButton = document.getElementById("darkModeToggle");
    const body = document.body;

    // Check localStorage for dark mode preference
    if (localStorage.getItem("darkMode") === "enabled") {
        body.classList.add("dark-mode");
        toggleButton.innerHTML = "☀️"; // Sun icon when dark mode is enabled
        body.style.backgroundImage = "url('/images/night.jpg')"; // Dark mode background
    } else {
        body.style.backgroundImage = "url('/images/day.jpg')"; // Light mode background
        toggleButton.innerHTML = "🌙"; // Moon icon when dark mode is disabled
    }

    toggleButton.addEventListener("click", function () {
        body.classList.toggle("dark-mode");

        if (body.classList.contains("dark-mode")) {
            localStorage.setItem("darkMode", "enabled");
            toggleButton.innerHTML = "☀️"; // Sun icon when dark mode is enabled
            body.style.backgroundImage = "url('/images/night.jpg')"; // Dark mode background
        } else {
            localStorage.setItem("darkMode", "disabled");
            toggleButton.innerHTML = "🌙"; // Moon icon when dark mode is disabled
            body.style.backgroundImage = "url('/images/day.jpg')"; // Light mode background
        }
    });
});
