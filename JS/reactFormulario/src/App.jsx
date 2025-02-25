import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import { BrowserRouter ,Routes, Route} from 'react-router-dom'
import './App.css'
import Layout from './Layout'
import AlumnoList from './AlumnoList'  // Importa el componente AlumnoList
import AlumnoForm from './AlumnoForm'
import Recetas from './recetas'

function App() {
  const estudiantes =[
    {id:1, grupo:"A",nombre:"Juan"},
    {id:2, grupo:"B",nombre:"Adrían"},
    {id:3, grupo:"A",nombre:"María"},
    {id:4, grupo:"B",nombre:"Carla"},
  ]
  const [alumnos, setAlumnos] = useState(estudiantes);

  return (
    <>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Layout />}>
            <Route path="/" element={<AlumnoList/>} />
            <Route path="/añadir" element={<AlumnoForm alumnos={alumnos} setAlumnos={setAlumnos}/>}/>
            <Route path="/editar/:alumnoId" element={<AlumnoForm alumnos={alumnos} setAlumnos={setAlumnos}/>}/>
            <Route path="/recetas" element={<Recetas/>}/>
          </Route>
        </Routes>
      </BrowserRouter>
    </>
  )
}

export default App
