import { useState, useEffect } from 'react';
import axios from 'axios';

function App() {
  // 1. ESTADO
  const [equipos, setEquipos] = useState([]);
  
  // OJO: Verifica que este sea el puerto exacto que te dio Swagger
  const API_URL = "http://localhost:5171/api/Equipos";

  // 2. EFECTO (Cargar al iniciar)
  useEffect(() => {
    cargarEquipos();
  }, []);

  // 3. FUNCIONES LÓGICAS
  const cargarEquipos = async () => {
    try {
      const response = await axios.get(API_URL);
      setEquipos(response.data);  
    } catch (error) {
      console.error("Error al cargar:", error);
    }
  };

  // 4. RENDERIZADO VISUAL
  return (
    <div style={{ padding: '20px', fontFamily: 'Arial' }}>
      <h1>Administrador de Equipos</h1>
      <button onClick={cargarEquipos}>Recargar Lista</button>

      <hr />

      <h2>Lista Actual</h2>
      {equipos.length === 0 ? (
        <p>No hay equipos registrados.</p>
      ) : (
        <ul>
          {equipos.map((equipo) => (
            <li key={equipo.id}>
              <strong>{equipo.nombre}</strong> - {equipo.descripcion} 
              {/* Nota: Asegúrate de usar los nombres exactos de las propiedades de tu C# */}
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}

export default App;