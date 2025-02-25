package edu.ejercicio5.PersistenciaAnimales5.controllers;

import edu.ejercicio5.PersistenciaAnimales5.models.Animal;
import edu.ejercicio5.PersistenciaAnimales5.services.AnimalServices;
import edu.ejercicio5.PersistenciaAnimales5.services.ClaseServices;
import jakarta.validation.Valid;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;

@Controller
public class AnimalController {

    private ClaseServices claseServices;
    private AnimalServices animalServicesImp;
    //HAY QUE LLAMAR A LA INTERFACE YA QUE SE CONECTA CON LOS DEMAS
    public AnimalController(AnimalServices animalServices, ClaseServices claseServices){
        this.claseServices = claseServices;
        animalServicesImp = animalServices;
    }
    // INDEX
    @GetMapping("/Animal")
    public String listarAnimales(Model model){
        model.addAttribute("Animales", animalServicesImp.listAnimal());
        return "Animal/index";
    }

//  CREAR (FUNCIONA)

    @GetMapping("/Animal/create")
    public String crearAnimal(Model model){
        model.addAttribute("Animal", new Animal());
        model.addAttribute("Clases", claseServices.listClase());
        return "Animal/create";
    }
    @PostMapping("/Animal/create")
    public String crearAnimal(@ModelAttribute("Animal") Animal animal){
        animalServicesImp.crearAnimal(animal);
        return "redirect:/Animal";
    }

//  UPDATE (FUNCIONA)

    @GetMapping("/Animal/update/{id}")
    public String updateAnimal(@PathVariable int id,Model model){
           model.addAttribute("Animal", animalServicesImp.getAnimal(id).get()); //USAR EL .get si se trata de un OPTION para recibir el objeto
           model.addAttribute("Clases", claseServices.listClase());
           return "Animal/update";
    }
    @PostMapping("/Animal/update/{id}")
    public String updateAnimal(@PathVariable int id, @Valid @ModelAttribute("Animal") Animal animal, BindingResult bindingResult)
    {
        if (bindingResult.hasErrors())
        {
            System.out.println(bindingResult.getAllErrors());
            return "Animal/update";
        }
        else {
            animalServicesImp.updateAnimal(animal);
            return "redirect:/Animal";
        }
    }
//  DELETE (FUNCIONA)
    @PostMapping("/Animal/delete/{id}")
    public String deleteAnimal(@PathVariable int id) {
        animalServicesImp.deleteAnimal(id);
        return "redirect:/Animal";
    }
// DETAILS
    @GetMapping("/Animal/details/{id}")
    public String detailsAnimal(@PathVariable int id,Model model){
        Animal animal = animalServicesImp.getAnimal(id).get();
        model.addAttribute("Animal", animal);
        return "Animal/details";
    }
}
