package edu.ejercicio5.PersistenciaAnimales5.services;


import edu.ejercicio5.PersistenciaAnimales5.models.Animal;
import edu.ejercicio5.PersistenciaAnimales5.repositories.AnimalRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Primary;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Primary
@Service
public class AnimalServicesImp2 implements AnimalServices{
    @Autowired
    private AnimalRepository animalRepository;

    public List<Animal> listAnimal(){return animalRepository.findAll();}

    public Optional<Animal> getAnimal(int id) { return animalRepository.findById(id);}

    public  void crearAnimal(Animal animal){ animalRepository.save(animal);}

    public void updateAnimal(Animal animal){ animalRepository.save(animal);}

    public void deleteAnimal(int id){ animalRepository.deleteById(id);}

}
