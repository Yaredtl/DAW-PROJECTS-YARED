package edu.ejercicio5.PersistenciaAnimales5.models;

import jakarta.persistence.CascadeType;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.JoinTable;
import jakarta.persistence.ManyToMany;

import java.util.List;

public class User {
    private int id;
    private String username;
    private String password;

    @ManyToMany(cascade = {CascadeType.ALL})
    @JoinTable(
            name = "User_Role",
            joinColumns = {@JoinColumn(name = "user_id")},
            inverseJoinColumns = {@JoinColumn (name = "role_id")}
    )
    private List<Role> roleList;

    public User(int id, String username, String password, List<Role> roleList) {
        this.id = id;
        this.username = username;
        this.password = password;
        this.roleList = roleList;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }
}
