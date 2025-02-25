import { useEffect } from "react";
import { useState } from "react";
import './recetas.css';
export  default function recetasapi() {
const [data, setData] = useState([]);
const [loading, setLoading] = useState(true);
const [error, setError] = useState(null);
useEffect(() => {
fetch("http://localhost:3000/recetas")
    .then((res) => {
        if (res.ok) {
            return res.json();
        }
        throw res;
    })
    .then((res) => {
    setData(res);
    setLoading(false);
    })
    .catch((error) => {
        setError("Error al cargar los datos");
        setLoading(false);
    });
}, []);
if (loading) {
    return <div className="loader-container">
        <div className="loader"></div>
        </div>;
}
if (error) {
    return <div className="error">{error}</div>;
}

return (
<div>
    <h1 className="title">Fetch Recetas API</h1>
    <div>
    <h2>Lista de Recetas</h2>
    <table>
        <thead>
        <tr>
            <th>ID</th>
            <th>Nombre</th>
            <th>Tipo de cocina</th>
            <th>Tiempo de preparación</th>
            <th>Tiempo de cocina</th>
            <th>Ingredientes</th>
        </tr>
        </thead>
        <tbody>
        {data.length > 0 && data.map((receta) => (
            <tr key={receta.id}>
                <td>{receta.id}</td>
                <td>{receta.name}</td>
                <td>{receta.cuisine}</td>
                <td>{receta.prepTimeMinutes} min</td>
                <td>{receta.cookTimeMinutes} min</td>
                <td>{receta.ingredients}</td>
            </tr>
            ))}
        </tbody>
    </table>
    </div>
</div>
);
}