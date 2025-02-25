package Farmacia.controllers;
import Farmacia.models.Farmacia;
import Farmacia.storage.Persistence;

import java.util.List;

public class Farmaciacontroller {
    private Persistence pst;
    public Farmaciacontroller(){
        pst = new Persistence();
        pst.openJSON();

    }
    public String buscarFarmacia(String name) {
        try{
            List<Farmacia> farmacias = pst.list();
            for (Farmacia farm: farmacias)
            {
                if (farm.getNOMBRE().contains(name.toUpperCase()))
                {
                    System.out.println(farm.toString());
                    return farm.toString();
                }
            }
            System.out.println("Esa farmacia no se encuentra en nuestra base de datos");
        }catch (Exception e){
            System.out.println("Ha habido un error al buscarla" + e.getMessage());
        }
        return  "No se ha encontrado la farmacia indicada";
    }
    public void insertarFarmacia(String name, String phone,String web) {
        Farmacia AddFarmacia = new Farmacia(web,"",phone,name.toUpperCase(),0,0);
        List<Farmacia> lista = pst.list();
        for (Farmacia farm : lista)
        {
            if (farm.getTELEFONO().equals(phone)){
                System.out.println("El telefono que has intentado añadir ya esta asociado a otra farmacia");
                System.out.println("Se te devolverá al menú principal");
                return;
            }
        }
        pst.add(AddFarmacia);
        System.out.print("Farmacia añadida " + AddFarmacia.toString());
    }
    public String borrarFarmacia(String farmPhone)
    {
        try{
            List<Farmacia> lista = pst.list();
            for (Farmacia farm : lista)
            {
                if (farm.getTELEFONO().equals(farmPhone))
                {
                    System.out.println("La " + farm.toString() +  '\n' + " HA SIDO ELIMINADA");
                    pst.delete(farm);
                    return "Se ha borrado con exito";
                }
            };
            System.out.println("No se ha encontrado ese numero telefono");
        }catch(Exception e)
        {
            System.out.println("Ha ocurrido un error al intentar eliminar la farmacia");
        }
       return "No hay una farmacia con ese telefono";
    }
    public String listarFarmacias(){

        List<Farmacia> listaFarmacias = pst.list();
        String concat = "";
        for (Farmacia farm : listaFarmacias)
        {
            System.out.println(farm.toString() + "\n");
        }
         return concat;
    }
    public boolean saveFarmacias(){
         try {
             pst.closeJSON();
             System.out.println("Se ha guardado con exito los datos de los ficheros");
             return true;
         }catch (Exception e)
         {
             System.out.println("Ha ocurrido un problema al intentar guardar los datos" + e.getMessage());
         }
         return false;
    }
}
