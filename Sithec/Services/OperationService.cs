using System;
using Sithec.Data;

namespace Sithec.Services
{
	public class OperationService
	{
		public OperationService()
		{
		}

		public double SolveOperation(Operacion operacion)
		{
            double resultado = 0;

            switch (operacion.Tipo)
            {
                case "suma":
                    resultado = operacion.Operando1 + operacion.Operando2;
                    break;
                case "resta":
                    resultado = operacion.Operando1 - operacion.Operando2;
                    break;
                case "multiplicacion":
                    resultado = operacion.Operando1 * operacion.Operando2;
                    break;
                case "division":
                    if (operacion.Operando2 == 0) throw new Exception("No se puede dividir entre Cero");
                    resultado = operacion.Operando1 / operacion.Operando2;
                    break;
                default:
                    throw new Exception("No hay Tipo de operacion");
            }
            return resultado;
        }
	}
}

