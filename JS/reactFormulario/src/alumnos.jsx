import { useState, useEffect } from "react";



async function Ejercicio3(){
const AlumnoForm = ({ alumnos, setAlumnos }) => {
//estos datos por si se va a crear un nuevo alumno 
const [nombre, setNombre] = useState("");
const [grupo, setGrupo] = useState("");
const [id, setId] = useState(0);
const [errores, setErrores] = useState({});
const navigate = useNavigate();
const { alumnoId } = useParams();
let listaId = []
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
    setAlumnos([...alumnos, { id: parseInt(id), nombre, grupo }], listaId.push(id));
    navigate("/");
};

return (
    alert({listaId})
);
};
}
export default Ejercicio3;