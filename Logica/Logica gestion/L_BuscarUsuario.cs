using System;

public class L_BuscarUsuario
{
    private D_BuscarUsuario dBuscarUsuario = new D_BuscarUsuario();


    public string ObtenerCorreoPorId(int idUsuario)
    {
        if (idUsuario <= 0)
            throw new ArgumentException("IdUsuario debe ser mayor que cero.");

        return dBuscarUsuario.ObtenerCorreoPorUsuario(idUsuario);
    }

    public int? ObtenerIdPorUsuario(string nombreUsuario)
    {
        return dBuscarUsuario.ObtenerIdPorUsuario(nombreUsuario);
    }

}
