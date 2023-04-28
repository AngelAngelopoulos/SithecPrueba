using System;
using Sithec.Models;

namespace Sithec.Data
{
    public class DatosMock
    {
        public static List<Humano> GetHumanos()
        {
            return new List<Humano>
        {
            new Humano
            {
                Id = 1,
                Nombre = "Juan",
                Sexo = "Masculino",
                Edad = 25,
                Altura = 1.80M,
                Peso = 75.5M
            },
            new Humano
            {
                Id = 2,
                Nombre = "Maria",
                Sexo = "Femenino",
                Edad = 30,
                Altura = 1.65M,
                Peso = 60.0M
            },
            new Humano
            {
                Id = 3,
                Nombre = "Pedro",
                Sexo = "Masculino",
                Edad = 20,
                Altura = 1.70M,
                Peso = 65.0M
            }
        };
        }
    }

}

