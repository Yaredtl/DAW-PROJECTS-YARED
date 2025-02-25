package edu.ejercicio5.PersistenciaAnimales5.services;


import edu.ejercicio5.PersistenciaAnimales5.models.Clase;
import edu.ejercicio5.PersistenciaAnimales5.repositories.ClaseRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Primary;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Primary
@Service
public class ClaseServicesImp2 implements ClaseServices{
    @Autowired
    private ClaseRepository claseRepository;

    public List<Clase> listClase(){return claseRepository.findAll();}

    public Optional<Clase> getClase(int id) { return claseRepository.findById(id);}

    public  void crearClase(Clase clase){ claseRepository.save(clase);}

    public void updateClase(Clase clase){claseRepository.save(clase);}

    public void deleteClase(int id){ claseRepository.deleteById(id);}

}
