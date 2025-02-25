package edu.ejercicio5.PersistenciaAnimales5.models;

import jakarta.persistence.ManyToMany;

import java.util.List;

public class Role {
    private int roleId;
    private String rolName;

    @ManyToMany(mappedBy = "roleList")
    private List<User> userList;
    public Role(int roleId, String rolName) {
        this.roleId = roleId;
        this.rolName = rolName;
    }

    public int getRoleId() {
        return roleId;
    }

    public void setRoleId(int id) {
        this.roleId = id;
    }

    public String getRolName() {
        return rolName;
    }

    public void setRolName(String rolName) {
        this.rolName = rolName;
    }
}
