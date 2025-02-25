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
    const cart = [
        { id: 1, name: "Figura Mufasa", price: 19.99, quantity: 1, selected: true },
        { id: 2, name: "Peluche Stitch", price: 17.99, quantity: 0, selected: false },
        { id: 3, name: "Entradas premium", price: 74.99, quantity: 0, selected: false, outOfStock: true },
        { id: 4, name: "FunkoPeterVerse", price: 34.99, quantity: 1, selected: true },
        { id: 5, name: "Taza Dori", price: 21.99, quantity: 0, selected: false },
    ];
    const subtotalElem = document.querySelector(".subtotal");
    const igicElem = document.querySelector(".igic");
    const totalElem = document.querySelector(".total");
    const nextButton = document.querySelector(".next");

    function updateCartDisplay() {
        let subtotal = 0;
        cart.forEach((product) => {
            // Asegurarnos de que el elemento exista antes de trabajar con él
            const productElem = document.querySelector(`.producto[data-id='${product.id}']`);
            
            if (productElem) {
                // Verificar si el producto está seleccionado y no está fuera de stock
                if (product.selected && !product.outOfStock) {
                    subtotal += product.price * product.quantity;
                    productElem.classList.remove("deselected");
                } else {
                    productElem.classList.add("deselected");
                }
        
                // Actualizar los valores solo si el elemento existe
                const cantidadElem = productElem.querySelector(".cantidad");
                if (cantidadElem) {
                    cantidadElem.textContent = product.quantity;
                }
        
                const selectProductElem = productElem.querySelector(".select-product");
                if (selectProductElem) {
                    selectProductElem.checked = product.selected;
                }
            } else {
                console.warn(`Elemento con data-id='${product.id}' no encontrado en el DOM.`);
            }
        });

        const igic = subtotal * 0.07;
        const total = subtotal + igic;

        subtotalElem.textContent = `${subtotal.toFixed(2)}€`;
        igicElem.textContent = `${igic.toFixed(2)}€`;
        totalElem.textContent = `${total.toFixed(2)}€`;

        const hasSelectedProducts = cart.some((product) => product.selected && product.quantity > 0);
        nextButton.disabled = !hasSelectedProducts;

        localStorage.setItem("cart", JSON.stringify(cart));
        localStorage.setItem("total", total.toFixed(2));
    }

    function modifyQuantity(productId, change) {
        const product = cart.find((p) => p.id === productId);
        if (product && !product.outOfStock) {
            product.quantity = Math.max(0, product.quantity + change);
            updateCartDisplay();
        }
    }
    function toggleSelection(productId) {
        const product = cart.find((p) => p.id === productId);
        if (product && !product.outOfStock) {
            product.selected = !product.selected;
            updateCartDisplay();
        }
    }
    function deleteProduct(productId) {
        const productIndex = cart.findIndex((p) => p.id === productId);
        if (productIndex > -1) {
            cart.splice(productIndex, 1);
            document.querySelector(`.producto[data-id='${productId}']`).remove();
            updateCartDisplay();
        }
    }
    function attachEventListeners() {
        document.querySelectorAll(".less").forEach((button) => {
            button.addEventListener("click", (e) => {
                const productId = parseInt(e.target.closest(".producto").dataset.id);
                modifyQuantity(productId, -1);
            });
        });
        document.querySelectorAll(".more").forEach((button) => {
            button.addEventListener("click", (e) => {
                const productId = parseInt(e.target.closest(".producto").dataset.id);
                modifyQuantity(productId, 1);
            });
        });
        document.querySelectorAll(".select-product").forEach((checkbox) => {
            checkbox.addEventListener("change", (e) => {
                const productId = parseInt(e.target.closest(".producto").dataset.id);
                toggleSelection(productId);
            });
        });
        document.querySelectorAll(".delete").forEach((button) => {
            button.addEventListener("click", (e) => {
                const productId = parseInt(e.target.closest(".producto").dataset.id);
                deleteProduct(productId);
            });
        });
    }
    attachEventListeners();
    updateCartDisplay();
});



