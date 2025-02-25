import React from 'react';
import { Outlet, Link } from 'react-router-dom';
import './Layout.css'
function Layout(){
  return (
    <div>
      <header>
        <h1>Gestión de Alumnos</h1>
        <nav>
          <Link to="/">Lista de Alumnos</Link>
          <Link to="/añadir">Añadir Alumno</Link>
        </nav>
      </header>
      <main>
        <Outlet />
      </main>

      <footer>
        <p>&copy; Alumnos - Gabriel Yared</p>
      </footer>
    </div>
  );
};

export default Layout;
