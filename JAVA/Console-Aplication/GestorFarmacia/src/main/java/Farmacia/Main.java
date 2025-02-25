package Farmacia;
import java.util.Scanner;
import Farmacia.controllers.Farmaciacontroller;

public class Main {
    private static Scanner sc;
    private static Farmaciacontroller fc;
    public static void main(String[] args) {
       sc = new Scanner(System.in);
       fc = new Farmaciacontroller();
       printMainMenu();
    }
    private static void printMainMenu(){
        int opcion;
        do{
            System.out.println("----------------");
            System.out.println("|MENU PRINCIPAL|" + '\n' + "----------------");
            System.out.println("Elija una de las siguientes opciones: ");
            System.out.println("1 - Listar Farmacias ");
            System.out.println("2 - Buscar Farmacias ");
            System.out.println("0 - Salir ");
            System.out.println("---------------------");
            System.out.println("9 - Modo Admin");
            System.out.println("Introduzca una opción: ");
            opcion = getOption();
            switch (opcion)
            {
                default:
                         System.out.println("Has indicado una opcion fuera de las validas, te devolvemos al menu principal");
                         printMainMenu();
                         break;
                case 1:
                    fc.listarFarmacias();
                    printMainMenu();
                    break;
                case 2:
                    System.out.println("Indica el nombre de la farmacia que deseas buscar: ");
                    sc.nextLine();
                    String nombre = sc.nextLine();
                    while (nombre.length() < 3)
                    {
                        System.out.println("El nombre debe contener al menos 3 caracteres");
                        System.out.println("Vuelve a añadir un nombre");
                        nombre = sc.nextLine();
                    }
                    fc.buscarFarmacia(nombre);
                    printMainMenu();
                    break;
                case 9:
                    goAdminMenu();
                    break;
                case 0:
                    fc.saveFarmacias();
                    System.exit(0);
                    break;
            }
        }while (opcion != 0);


    }
    private static void printAdminMenu(){
        System.out.println("-------------------------");
        System.out.println("| MENU DE ADMINISTRADOR | " + '\n' + "-------------------------");
        System.out.println("Elija una de las siguientes opciones: ");
        System.out.println("1 - Añadir Farmacia ");
        System.out.println("2 - Borrar Farmacia ");
        System.out.println("0 - Salir del menú de Administrador");
        System.out.println("Introduzca una opción: ");
    }
    private static void goAdminMenu(){
        int opcion;
        do{
            printAdminMenu();
            opcion = getOption();
            switch (opcion)
            {
                case 1: addFarmaciaInput();
                        break;
                case 2: removeFarmacia();
                        break;
                case 0: printMainMenu();
                        break;
            }
        }while(opcion != 0);
    }
    private static void addFarmaciaInput(){
        System.out.println("Indica el nombre de la farmacia: ");
        sc.nextLine();
        String nombre = sc.nextLine();
        System.out.println("Indica el nombre de la web de la farmacia: ");
        String web = sc.nextLine();
        System.out.println("Indica el telefono de la farmacia: ");
        String tel = sc.next();
        fc.insertarFarmacia(nombre,tel,web);

    }
    private static void removeFarmacia(){
        System.out.println("Indica el telefono de la farmacia que deseas eliminar: ");
        String tel= sc.next();
        fc.borrarFarmacia(tel);
    }
    private static int getOption() {
        while(true)
        {
            try{
                int opc = sc.nextInt();
                return opc;
            }
            catch (Exception e) {
                System.out.println("Has introducido un carácter no númerico, vuelva a intentarlo");
                return 0;
            }
        }
    }
}