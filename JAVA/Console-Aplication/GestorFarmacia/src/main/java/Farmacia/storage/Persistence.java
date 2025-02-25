package Farmacia.storage;
import java.io.*;
import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.List;

import Farmacia.interfaces.IPersistence;
import Farmacia.models.Farmacia;
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

public class Persistence implements IPersistence {
    private final String FILESTORAGE_PATH = "farmacias.json";
    private List<Farmacia> memStore;
    private Gson gson;

    @Override    public void openJSON(){
        gson =  new Gson();
        try (Reader reader = new FileReader ("src/main/resources/farmacias.json")) {
            Type listita = new TypeToken<ArrayList<Farmacia>>() {}.getType();
            memStore = gson.fromJson(reader, listita);
            if (memStore == null) {memStore = new ArrayList<>();};
        } catch (IOException e) {
            System.out.println("Error al abrir el JSON: " + e.getMessage());
        }
    }
    @Override     public void closeJSON(){
        try (Writer writer = new FileWriter(FILESTORAGE_PATH)) {
            gson.toJson(memStore, writer);

        } catch (IOException e) {
            System.out.println("Error al cerrar el JSON ");
        }
    }
    @Override    public void add(Farmacia farmacia){
        memStore.add(farmacia);
    }
    @Override    public void delete(Farmacia farmacia){
       memStore.remove(farmacia);
    }
    @Override   public List<Farmacia> list(){return memStore;}
}
