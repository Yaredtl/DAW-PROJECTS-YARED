package edu.ejercicio5.PersistenciaAnimales5.controllers;

import edu.ejercicio5.PersistenciaAnimales5.models.Clase;
import edu.ejercicio5.PersistenciaAnimales5.services.ClaseServices;
import jakarta.validation.Valid;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.Banner;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.*;

@Controller
public class ClaseController {

    private ClaseServices claseServices; //HAY QUE LLAMAR A LA INTERFACE YA QUE SE CONECTA CON LOS DEMAS
    public ClaseController(ClaseServices claseServices){
        this.claseServices = claseServices;
    }
//INDEX
    @GetMapping("/Clase")
    public String listarClases(Model model){
        model.addAttribute("Clases", claseServices.listClase());
        return "Clase/index";
    }
    //CREAR

    @GetMapping("/Clase/create") //ESTO ES LA URL
    public String crearClase(Model model){
        model.addAttribute("Clase", new Clase());
        return "Clase/create"; //ESTO ES TEMPLATE/CLASE/CREATE
    }
    @PostMapping("/Clase/create")
    public String crearClase(@ModelAttribute("Clase") Clase clase){
        claseServices.crearClase(clase);
        return "redirect:/Clase"; //ESTO LO REDIRIGE AL GETMAPPING("/Clase")
    }

    //UPDATE

    @GetMapping("/Clase/update/{id}")
    public String updateClase(@PathVariable int id, Model model){//USAMOS PATH VARIABLE PARA PILLAR EL ID DEL URL
        model.addAttribute("Clase", claseServices.getClase(id).get());
        return "Clase/update";
    }
    @PostMapping("/Clase/update/{id}") //PARA UPDATE USAR POST NO PUT <- SOLO PARA APIS
    public String updateClase(@PathVariable int id, @Valid @ModelAttribute("Clase") Clase clase, BindingResult bindingResult){
        if (bindingResult.hasErrors()){
            System.out.println(bindingResult.getAllErrors());
            return "Clase/update";
        }
        else{
            claseServices.updateClase(clase);
            return "redirect:/Clase";
        }
    }

    //DELETE

    @PostMapping("/Clase/delete/{id}")
    public String deleteClase(@PathVariable int id){
        claseServices.deleteClase(id);
        return "redirect:/Clase";
    }

    //DETAILS

    @GetMapping("/Clase/details/{id}")
    public String detailClase(@PathVariable int id, Model model){
        Clase clase = claseServices.getClase(id).get();
        model.addAttribute("Clase", clase);
        return "Clase/details";
    }
}
