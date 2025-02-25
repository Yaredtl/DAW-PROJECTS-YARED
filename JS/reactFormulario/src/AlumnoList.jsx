// import { Link } from "react-router-dom";
import { useState, useEffect } from "react";
import './AlumnoList.css';
/*Loader pillado de css-loaders.com*/
import { Link } from "react-router-dom";
const AlumnoList = () => {

  const [alumnos, setAlumnos] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    fetch("http://localhost:3000/alumnos")
      .then((response) => {
        if (response.ok) {
          return response.json();
        }
        throw response;
      })
      .then((data) => {
        setAlumnos(data);
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
    <>
        <br/>
        <div>
          <h2>Alumnos FETCH/SPINNER</h2>
          <ul>
            {alumnos.map((alumno) => (
              <li key={alumno.id}>
                {alumno.nombre} - {alumno.grupo}<br></br>
                <Link to={`/editar/${alumno.id}`}>Editar</Link>
                {/*<button onClick={() => handleDelete(alumno.id)}>Eliminar</button>   */}
              </li>
            ))}
          </ul>
          <Link to="/añadir">Añadir Alumno</Link>
        </div>
        </>
      );
};
export default AlumnoList;