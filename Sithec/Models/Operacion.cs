using System;
namespace Sithec.Data
{
	public class Operacion
	{
		private string tipo;
		private double operando1;
		private double operando2;

        public string Tipo { get => tipo; set => tipo = value; }
        public double Operando1 { get => operando1; set => operando1 = value; }
        public double Operando2 { get => operando2; set => operando2 = value; }
    }
}

