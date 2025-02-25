package Farmacia.interfaces;
import Farmacia.models.Farmacia;
import java.util.List;

public interface IPersistence {
    void openJSON();
    void closeJSON();
    void add(Farmacia farmacia);
    void delete(Farmacia farmacia);
    List<Farmacia> list();
}
