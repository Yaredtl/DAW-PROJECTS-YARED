package Farmacia.models;

public class Farmacia {
    private String WEB;
    private String LUNES;
    private String TELEFONO;
    private String NOMBRE;
    private float UTM_X;
    private float UTM_Y;
    public Farmacia (String web, String lunes, String telefono, String nombre, float utm_x, float utm_y)
    {
        this.WEB = web;
        this.LUNES = lunes;
        this.TELEFONO= telefono;
        this.NOMBRE= nombre ;
        this.UTM_X = utm_x;
        this.UTM_Y= utm_y;
    }

    public String getWEB() {
        return WEB;
    }

    public void setWEB(String WEB) {
        this.WEB = WEB;
    }

    public String getLUNES() {
        return LUNES;
    }

    public void setLUNES(String LUNES) {
        this.LUNES = LUNES;
    }

    public String getTELEFONO() {
        return TELEFONO;
    }

    public void setTELEFONO(String TELEFONO) {
        this.TELEFONO = TELEFONO;
    }

    public String getNOMBRE() {
        return NOMBRE;
    }

    public void setNOMBRE(String NOMBRE) {
        this.NOMBRE = NOMBRE;
    }

    public float getUTM_X() {
        return UTM_X;
    }

    public void setUTM_X(float UTM_X) {
        this.UTM_X = UTM_X;
    }

    public float getUTM_Y() {
        return UTM_Y;
    }

    public void setUTM_Y(float UTM_Y) {
        this.UTM_Y = UTM_Y;
    }

    @Override
    public String toString() {
        return "Farmacia: " + '\n' +
                    "WEB=" + WEB + '\n' +
                    "LUNES=" + LUNES + '\n' +
                    "TELEFONO=" + TELEFONO + '\n' +
                    "NOMBRE=" + NOMBRE + '\n' +
                    "UTM_X=" + UTM_X + '\n' +
                    "UTM_Y=" + UTM_Y;
    }
}
