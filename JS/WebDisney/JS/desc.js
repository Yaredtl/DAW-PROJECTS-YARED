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
    // Recuperar datos del localStorage
    const carritoTotal = localStorage.getItem('total');
    const totalCompraInput = document.getElementById('total-compra');
    if (carritoTotal) {
        totalCompraInput.value = parseFloat(carritoTotal).toFixed(2);
    } else {
        totalCompraInput.value = '0.00';
    }

    // Cargar datos de descuento si existen
    const mensajeDescuento = document.getElementById('mensaje-descuento');
    const codigoDescuentoInput = document.getElementById('codigo-descuento');
    const aplicarDescuentoBtn = document.getElementById('aplicar-descuento');

    const descuentoValido = {
        "DESCUENTO10": 10,
        "DESCUENTO20": 20
    };

    const codigoDescuento = localStorage.getItem('codigoDescuento');
    const descuentoAplicado = localStorage.getItem('descuentoAplicado');

    if (codigoDescuento && descuentoValido[codigoDescuento]) {
        // Si hay un código de descuento válido almacenado, lo aplicamos automáticamente
        codigoDescuentoInput.value = codigoDescuento;
        const totalActual = parseFloat(totalCompraInput.value);
        const descuento = descuentoValido[codigoDescuento];
        const nuevoTotal = totalActual - descuento;
        totalCompraInput.value = nuevoTotal.toFixed(2);
        mensajeDescuento.textContent = `Código válido. Descuento de €${descuento} aplicado.`;
        mensajeDescuento.style.color = 'green';
    }

    // Si ya se aplicó un descuento, se actualiza la vista y el total
    if (descuentoAplicado) {
        const totalActual = parseFloat(totalCompraInput.value);
        const descuento = parseFloat(descuentoAplicado);
        const nuevoTotal = totalActual - descuento;
        totalCompraInput.value = nuevoTotal.toFixed(2);
        mensajeDescuento.textContent = `Descuento de €${descuento} aplicado.`;
        mensajeDescuento.style.color = 'green';
    }

    aplicarDescuentoBtn.addEventListener('click', () => {
        const codigo = codigoDescuentoInput.value.trim().toUpperCase();
        const totalActual = parseFloat(totalCompraInput.value);

        if (descuentoValido[codigo]) {
            const descuento = descuentoValido[codigo];
            const nuevoTotal = totalActual - descuento;

            totalCompraInput.value = nuevoTotal.toFixed(2);
            mensajeDescuento.textContent = `Código válido. Descuento de €${descuento} aplicado.`;
            mensajeDescuento.style.color = 'green';
            
            // Guardar código de descuento y descuento en localStorage
            localStorage.setItem('codigoDescuento', codigo);
            localStorage.setItem('descuentoAplicado', descuento.toFixed(2));
        } else {
            mensajeDescuento.textContent = 'Código de descuento no válido.';
            mensajeDescuento.style.color = 'red';
        }
    });

    // Recuperar método de pago y detalles
    const metodoPagoRadios = document.getElementsByName('metodo-pago');
    const detallesPago = document.querySelectorAll('.pago-detalle');
    const form = document.getElementById('checkout-form');

    const metodoPagoGuardado = JSON.parse(localStorage.getItem('metodoPago'));
    if (metodoPagoGuardado) {
        const metodoSeleccionado = metodoPagoGuardado.metodo.toLowerCase();
        const radioSeleccionado = document.querySelector(`input[name="metodo-pago"][value="${metodoSeleccionado}"]`);
        if (radioSeleccionado) {
            radioSeleccionado.checked = true;
            detallesPago.forEach(detalle => detalle.style.display = 'none');
            const metodoSeleccionadoDetalle = document.querySelector(`#pago-${metodoSeleccionado}`);
            if (metodoSeleccionadoDetalle) {
                metodoSeleccionadoDetalle.style.display = 'block';
            }
        }

        // Rellenar detalles según el método de pago
        if (metodoPagoGuardado.metodo === 'Tarjeta') {
            document.getElementById('numero-tarjeta').value = metodoPagoGuardado.numeroTarjeta;
            document.getElementById('fecha-caducidad').value = metodoPagoGuardado.fechaCaducidad;
            document.getElementById('cvc').value = metodoPagoGuardado.cvc;
        } else if (metodoPagoGuardado.metodo === 'PayPal') {
            document.getElementById('email-paypal').value = metodoPagoGuardado.email;
        } else if (metodoPagoGuardado.metodo === 'Transferencia Bancaria') {
            // Si se guardó justificante, muestra el nombre del archivo
            if (metodoPagoGuardado.justificante) {
                const nombreArchivo = metodoPagoGuardado.justificante;
                document.getElementById('justificante-pdf').dataset.archivo = nombreArchivo; // Guardamos el nombre en un atributo
            }
        }
    }

    metodoPagoRadios.forEach(radio => {
        radio.addEventListener('change', () => {
            detallesPago.forEach(detalle => detalle.style.display = 'none');
            const metodoSeleccionado = document.querySelector(`#pago-${radio.value}`);
            if (metodoSeleccionado) {
                metodoSeleccionado.style.display = 'block';
            }
        });
    });

    form.addEventListener('submit', (event) => {
        event.preventDefault();

        let metodoSeleccionado = false;
        metodoPagoRadios.forEach(radio => {
            if (radio.checked) metodoSeleccionado = radio.value;
        });

        if (!metodoSeleccionado) {
            alert('Seleccione un método de pago.');
            return;
        }

        const datosPago = {};
        const datosFacturacion = {
            nombre: document.getElementById('nombre-tarjeta')?.value || "",
            direccion: "N/A"
        };

        if (metodoSeleccionado === 'tarjeta') {
            const numero = document.getElementById('numero-tarjeta').value;
            const fecha = document.getElementById('fecha-caducidad').value;
            const cvc = document.getElementById('cvc').value;

            if (!/^\d{16}$/.test(numero)) {
                alert('El número de tarjeta debe tener 16 dígitos.');
                return;
            }
            if (!/^\d{2}\/\d{2}$/.test(fecha)) {
                alert('La fecha de caducidad debe tener el formato MM/AA.');
                return;
            }
            if (!/^\d{3}$/.test(cvc)) {
                alert('El CVC debe tener 3 dígitos.');
                return;
            }

            datosPago.metodo = 'Tarjeta';
            datosPago.numeroTarjeta = numero;
            datosPago.fechaCaducidad = fecha;
            datosPago.cvc = cvc;
        }

        if (metodoSeleccionado === 'paypal') {
            const email = document.getElementById('email-paypal').value;
            if (!/\S+@\S+\.\S+/.test(email)) {
                alert('Ingrese un correo electrónico válido para PayPal.');
                return;
            }

            datosPago.metodo = 'PayPal';
            datosPago.email = email;
        }

        if (metodoSeleccionado === 'transferencia') {
            const archivo = document.getElementById('justificante-pdf').files[0];
            if (!archivo) {
                alert('Suba un archivo PDF como justificante.');
                return;
            }

            datosPago.metodo = 'Transferencia Bancaria';
            datosPago.justificante = archivo.name; // Guardamos el nombre del archivo subido
        }

        // Guardar datos en localStorage
        localStorage.setItem('metodoPago', JSON.stringify(datosPago));
        localStorage.setItem('datosFacturacion', JSON.stringify(datosFacturacion));
        localStorage.setItem('precioFinal', totalCompraInput.value);
        localStorage.setItem('codigoDescuento', codigoDescuentoInput.value); // Guardar código de descuento
        localStorage.setItem('descuentoAplicado', descuentoAplicado || '0'); // Guardar descuento aplicado

        alert('Compra realizada con éxito. Los datos han sido guardados.');
        window.location.href = "confirmacion.html";
    });
});