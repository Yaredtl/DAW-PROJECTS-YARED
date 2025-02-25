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
    const resumenCompra = document.getElementById('resumen-compra');
    const confirmarCompraBtn = document.getElementById('confirmar-compra');

    // Recuperar datos de localStorage
    const datosEnvio = JSON.parse(localStorage.getItem('datosEnvio')) || {};
    const datosFacturacion = JSON.parse(localStorage.getItem('formData')) || {};
    const metodoEnvio = localStorage.getItem('metodoEnvio') || 'No seleccionado';
    const metodoPago = JSON.parse(localStorage.getItem('metodoPago')) || {};
    const precioFinal = localStorage.getItem('precioFinal') || '0.00';

    // Crear el resumen de compra
    const bloquesInformacion = [
        {
            titulo: 'Datos de Facturación',
            contenido: `
                <p>Nombre: ${datosFacturacion.nombre || 'No proporcionado'}</p>
                <p>Dirección: ${datosFacturacion.direccion || 'No proporcionado'}</p>
                <a href="formulario.html#datos-facturacion">Editar</a>
            `
        },
        {
            titulo: 'Método de Envío',
            contenido: `
                <p>Método seleccionado: ${metodoEnvio}</p>
                <a href="formulario.html#metodos-envio">Editar</a>
            `
        },
        {
            titulo: 'Método de Pago',
            contenido: `
                <p>Método: ${metodoPago.metodo || 'No seleccionado'}</p>
                ${metodoPago.metodo === 'Tarjeta' ? `
                    <p>Número de Tarjeta: **** **** **** ${metodoPago.numeroTarjeta.slice(-4)}</p>
                    <p>Fecha de Caducidad: ${metodoPago.fechaCaducidad}</p>
                ` : ''}
                ${metodoPago.metodo === 'PayPal' ? `
                    <p>Email: ${metodoPago.email}</p>
                ` : ''}
                ${metodoPago.metodo === 'Transferencia Bancaria' ? `
                    <p>Justificante: ${metodoPago.justificante || 'No proporcionado'}</p>
                ` : ''}
                <a href="descuento.html">Editar</a>
            `
        },
        {
            titulo: 'Precio Final',
            contenido: `
                <p>Total a Pagar: €${parseFloat(precioFinal).toFixed(2)}</p>
            `
        }
    ];
    bloquesInformacion.forEach(bloque => {
        const divBloque = document.createElement('div');
        divBloque.classList.add('bloque-informacion');
        divBloque.innerHTML = `
            <h2>${bloque.titulo}</h2>
            ${bloque.contenido}
        `;
        resumenCompra.appendChild(divBloque);
    });
    
    confirmarCompraBtn.addEventListener('click', () => {
        alert('¡Compra confirmada! Gracias por su compra.'); 
    });
});
