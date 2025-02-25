package edu.ejercicio5.PersistenciaAnimales5.repositories;

import edu.ejercicio5.PersistenciaAnimales5.models.User;
import org.springframework.data.jpa.repository.JpaRepository;

public interface UserRepository extends JpaRepository<User,Integer> {
}
