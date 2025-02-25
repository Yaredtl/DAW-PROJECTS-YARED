package edu.ejercicio5.PersistenciaAnimales5.services;

import edu.ejercicio5.PersistenciaAnimales5.models.Animal;

import java.util.List;
import java.util.Optional;

public interface AnimalServices {

    List<Animal> listAnimal();
    Optional<Animal> getAnimal(int id);
    void crearAnimal(Animal animal);
    void updateAnimal(Animal animal);
    void deleteAnimal(int id);
}
