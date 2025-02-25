document.addEventListener("DOMContentLoaded", () => {
    const body = document.body
    const botoncontraste = document.getElementById("theme")
    const temaGuardado = localStorage.getItem("tema")
    if (temaGuardado === "oscuro") {
        body.classList.add("oscuro")
    }
    botoncontraste.addEventListener("click", () => {
        const esOscuro = body.classList.toggle("oscuro") 
        if (esOscuro) {
            localStorage.setItem("tema", "oscuro")
        } else {
            localStorage.setItem("tema", "claro")
        }
    })
    let index = 0;
const totalSlides = document.querySelector(".carousel-inner").children.length;
const slidesToShow = 1
const slideWidth = 59 / slidesToShow; // Ancho del carrusel ajustado
function moveSlide(direction) {
    const slides = document.querySelector(".carousel-inner");

    index += direction;

    if (index > totalSlides - slidesToShow) {
        index = 0; // Reinicia el carrusel al final
    }
    if (index < 0) {
        index = totalSlides - slidesToShow; // Vuelve al último slide si está en negativo
    }

    slides.style.transform = `translateX(-${index * slideWidth}%)`;
}

// Movimiento automático cada 10 segundos
setInterval(() => {
    moveSlide(1);
}, 5000);

})