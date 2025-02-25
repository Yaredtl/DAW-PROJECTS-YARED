package edu.ejercicio5.PersistenciaAnimales5.models;

import jakarta.persistence.*;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.Size;

import java.util.List;

@Entity
public class Clase {

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO) //PARA QUE LA ID SE HAGA AUTOINCREMENTAL
    private int Id;

    @NotBlank
    @Size(min = 2, max = 15)
    private String Nombre;

    @OneToMany(mappedBy = "Clase", //UNA CLASE TENDRA VARIOS ANIMALES SE TIENE QUE LLAMAR IGUAL QUE @MANYTOONE
               cascade = CascadeType.ALL,
               orphanRemoval = true)
    private List<Animal> animals;

    public Clase(){} //SIEMPRE TENER UNO VACIO PARA EL GETMAPPING
    public Clase(int id, String nombre, List<Animal> animals) {
        Id = id;
        Nombre = nombre;
        this.animals = animals;
    }

    public int getId() {
        return Id;
    }

    public void setId(int id) {
        Id = id;
    }

    public @NotBlank @Size(min = 2, max = 15) String getNombre() {
        return Nombre;
    }

    public void setNombre(@NotBlank @Size(min = 2, max = 15) String nombre) {
        Nombre = nombre;
    }

    public List<Animal> getAnimals() {
        return animals;
    }

    public void setAnimals(List<Animal> animals) {
        this.animals = animals;
    }
}
