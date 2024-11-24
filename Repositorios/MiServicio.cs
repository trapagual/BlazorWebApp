using System;
using BlazorWebApp.Repositorios.Interfaces;

namespace BlazorWebApp.Repositorios;

public class MiServicio : IMiServicio
{
    public string GetMensaje()
    {
        return "Hola desde Mi Servicio";
    }
}
