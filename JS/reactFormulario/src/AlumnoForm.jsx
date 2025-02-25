import { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";

const AlumnoForm = ({ alumnos, setAlumnos }) => {
  //estos datos por si se va a crear un nuevo alumno 
  const [nombre, setNombre] = useState("");
  const [grupo, setGrupo] = useState("");
  const [id, setId] = useState(0);
  const [errores, setErrores] = useState({});
  const navigate = useNavigate();
  const { alumnoId } = useParams();

  const grupos = ["A", "B"];  // Grupos disponibles

  useEffect(() => {
    if (alumnoId) {
      const alumno = alumnos.find(alumno => alumno.id === parseInt(alumnoId));
      if (alumno) {
        setId(alumno.id);
        setNombre(alumno.nombre);
        setGrupo(alumno.grupo);
      }
    }
  }, [alumnoId, alumnos]);

  const handleSubmit = (e) => {
    e.preventDefault();

    let erroresValidacion = {};
    if (!nombre || nombre.length < 4 || nombre.length > 20) {
      erroresValidacion.nombre = "El nombre debe tener entre 4 y 20 caracteres.";
    }
    if (!id || alumnos.some(alumno => alumno.id === id)) {
      erroresValidacion.id = "El ID debe ser único.";
    }
    if (!grupo) {
      erroresValidacion.grupo = "El grupo es obligatorio.";
    }

    if (Object.keys(erroresValidacion).length > 0) {
      setErrores(erroresValidacion);
      return;
    }

    if (alumnoId) {
      // Editar alumno existente
      setAlumnos(alumnos.map(alumno => 
        alumno.id === parseInt(alumnoId) ? { id, nombre, grupo } : alumno
      ));
    } else {
      // Añadir nuevo alumno
      setAlumnos([...alumnos, { id: parseInt(id), nombre, grupo }]);
    }
    navigate("/");
  };

  return (
    <form onSubmit={handleSubmit}>
      <div>
        <label>ID:</label>
        <input
          type="number"
          value={id}
          onChange={(e) => setId(e.target.value)}
          disabled={!!alumnoId}
        />
        {errores.id && <span>{errores.id}</span>}
      </div>

      <div>
        <label>Nombre:</label>
        <input
          type="text"
          value={nombre}
          onChange={(e) => setNombre(e.target.value)}
        />
        {errores.nombre && <span>{errores.nombre}</span>}
      </div>

      <div>
        <label>Grupo:</label>
        <select
          value={grupo}
          onChange={(e) => setGrupo(e.target.value)}
        >
          <option value="">Seleccione un grupo</option>
          {grupos.map(grupo => (
            <option key={grupo} value={grupo}>{grupo}</option>
          ))}
        </select>
        {errores.grupo && <span>{errores.grupo}</span>}
      </div>

      <button type="submit">Guardar</button>
    </form>
  );
};

export default AlumnoForm;
