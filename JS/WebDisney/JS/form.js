
document.addEventListener('DOMContentLoaded', () => {
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
    const zonaEnvioSelect = document.getElementById('zona-envio');
    const metodosEnvioContainer = document.getElementById('metodos-envio');
    const form = document.getElementById('checkout-form');
    const sameData = document.getElementById('igual-envio')
    const nombre = document.getElementById('nombre')
    const direccion = document.getElementById('direccion')
    const nombrefac = document.getElementById('nombre-facturacion')
    const direccionfac = document.getElementById('direccion-facturacion')
    // Recuperar datos guardados
    sameData.addEventListener("click", () => {
        if (sameData.checked) {
            nombrefac.value = nombre.value;
            direccionfac.value = direccion.value;
            localStorage.setItem('datosFacturacion', JSON.stringify({
                nombre: nombre.value,
                direccion: direccion.value
            }));
        } else {
            nombrefac.value = '';
            direccionfac.value = '';
            localStorage.removeItem('datosFacturacion');
        }
    });
    const savedData = JSON.parse(localStorage.getItem('formData'));

    if (savedData) {
        document.getElementById('nombre').value = savedData.nombre;
        document.getElementById('email').value = savedData.email;
        document.getElementById('direccion').value = savedData.direccion;
        document.getElementById('zona-envio').value = savedData.zonaEnvio;
        document.getElementById('telefono').value = savedData.telefono;

        if (savedData.igualEnvio) {
            // document.getElementById('igual-envio').checked = true;
            document.getElementById('nombre-facturacion').value = savedData.nombreFacturacion;
            document.getElementById('direccion-facturacion').value = savedData.direccionFacturacion;
        }
    }

    const metodosEnvio = {
        zona1: [{ id: 'normal', nombre: 'Envío Normal', precio: 5.0 }],
        zona2: [
            { id: 'normal', nombre: 'Envío Normal', precio: 5.0 },
            { id: 'rapido', nombre: 'Envío Rápido', precio: 10.0 }
        ],
        zona3: null
    };

    zonaEnvioSelect.addEventListener('change', () => {
        const zonaSeleccionada = zonaEnvioSelect.value;
        metodosEnvioContainer.innerHTML = '';

        if (!zonaSeleccionada) return;

        const opciones = metodosEnvio[zonaSeleccionada];

        if (opciones === null) {
            const mensaje = document.createElement('span');
            mensaje.textContent = 'Lo sentimos, no realizamos envíos a esta zona.';
            mensaje.style.color = 'red';
            metodosEnvioContainer.appendChild(mensaje);
        } else {
            const selectMetodo = document.createElement('select');
            selectMetodo.id = 'metodo-envio';
            selectMetodo.name = 'metodo-envio';
            selectMetodo.required = true;

            const opcionDefault = document.createElement('option');
            opcionDefault.value = '';
            opcionDefault.textContent = 'Seleccione un método de envío';
            selectMetodo.appendChild(opcionDefault);

            opciones.forEach(opcion => {
                const optionElement = document.createElement('option');
                optionElement.value = opcion.id;
                optionElement.textContent = `${opcion.nombre} - €${opcion.precio.toFixed(2)}`;
                selectMetodo.appendChild(optionElement);
            });

            selectMetodo.addEventListener('change', () => {
                localStorage.setItem('metodoEnvio', selectMetodo.value);
            });

            metodosEnvioContainer.appendChild(selectMetodo);
        }
    });

    form.addEventListener('submit', (event) => {
        event.preventDefault();

        const zonaSeleccionada = zonaEnvioSelect.value;
        const metodoEnvioSeleccionado = document.getElementById('metodo-envio')?.value;

        if (!zonaSeleccionada || (metodosEnvio[zonaSeleccionada] && !metodoEnvioSeleccionado)) {
            alert('Por favor, complete todos los campos requeridos y seleccione un método de envío válido.');
            return;
        }

        if (metodosEnvio[zonaSeleccionada] === null) {
            alert('No se realizan envíos a la zona seleccionada.');
            return;
        }

        const formData = {
            nombre: document.getElementById('nombre').value,
            email: document.getElementById('email').value,
            direccion: document.getElementById('direccion').value,
            zonaEnvio: zonaSeleccionada,
            telefono: document.getElementById('telefono').value,
            igualEnvio: document.getElementById('igual-envio').checked,
            nombreFacturacion: document.getElementById('nombre-facturacion').value,
            direccionFacturacion: document.getElementById('direccion-facturacion').value
        };

        localStorage.setItem('formData', JSON.stringify(formData));
        window.location.href = 'descuento.html';
        
    });
});
