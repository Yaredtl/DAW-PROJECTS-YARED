package edu.ejercicio5.PersistenciaAnimales5.services;

import edu.ejercicio5.PersistenciaAnimales5.models.Clase;

import java.util.List;
import java.util.Optional;

public interface ClaseServices {

    List<Clase> listClase();
    Optional<Clase> getClase(int id);
    void crearClase(Clase clase);
    void updateClase(Clase clase);
    void deleteClase(int id);
}
