package edu.ejercicio5.PersistenciaAnimales5.models;

import jakarta.persistence.*;
import jakarta.validation.constraints.*;

@Entity
public class Animal {

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO) //PARA QUE LA ID SE HAGA AUTOINCREMENTAL
    private int Id;
    @NotBlank
    @Size(min = 3, max = 12)
    private String Nombre;
    @NotNull
    @Min(0)
    @Max(150)
    private int vidaMedia;
    @NotNull
    private boolean Extinto;

    @ManyToOne          //UN ANIMAL PERTENECERA A UNA CLASE
    private Clase Clase;

    public Animal(){}
    public Animal(int id, String nombre, int vidaMedia, boolean extinto,Clase clase) {
        Id = id;
        Extinto = extinto;
        this.vidaMedia = vidaMedia;
        Nombre = nombre;
        this.Clase = clase;
    }


    public int getId() {
        return Id;
    }

    public void setId(int id) {
        Id = id;
    }

    public boolean isExtinto() {
        return Extinto;
    }

    public void setExtinto(boolean extinto) {
        Extinto = extinto;
    }

    public int getVidaMedia() {
        return vidaMedia;
    }

    public void setVidaMedia(int vidaMedia) {
        this.vidaMedia = vidaMedia;
    }

    public String getNombre() {
        return Nombre;
    }

    public void setNombre(String nombre) {
        Nombre = nombre;
    }

    public Clase getClase() {
        return Clase;
    }

    public void setClase(Clase clase) {
        this.Clase = clase;
    }
}
