using System;
namespace Sithec.Models
{
    public class Humano
    {
        private int id;
        private string nombre;
        private string sexo;
        private int edad;
        private decimal altura;
        private decimal peso;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public int Edad { get => edad; set => edad = value; }
        public decimal Altura { get => altura; set => altura = value; }
        public decimal Peso { get => peso; set => peso = value; }
    }
}

