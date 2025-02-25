package edu.ejercicio5.PersistenciaAnimales5.repositories;

import edu.ejercicio5.PersistenciaAnimales5.models.Animal;
import org.springframework.data.jpa.repository.JpaRepository;

public interface AnimalRepository extends JpaRepository<Animal,Integer> {
 //DENTRO DEL JPA, VA <MODELO QUE USAMOS, TIPO DE CLAVE PRIMARIA>
}
