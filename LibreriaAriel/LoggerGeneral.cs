using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaAriel
{
    public interface ILoggerGeneral
    {
        public int PrioridadLogger { get; set; }
        public string TipoLogger { get; set; }
        void Message(string message);
        bool LogDataBase(string message);
        bool LogBalanceDespuesRetiro(int balanceDespuesRetiro);
        string MessageConReturnsStr(string message);
        bool MessageConParametroOutReturnsBoolean(string str, out string outputStr);
        bool MessageConObjetoReferenciaReturnsBoolean(ref Cliente cliente);
    }
    public class LoggerGeneral : ILoggerGeneral
    {
        public int PrioridadLogger { get; set; }
        public string TipoLogger { get; set; }

        public bool LogBalanceDespuesRetiro(int balanceDespuesRetiro)
        {
            if (balanceDespuesRetiro >= 0)
            {
                Console.WriteLine("Exito de la operacion");
                return true;
            }
            Console.WriteLine("Erro");
            return false;
        }

        public bool LogDataBase(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public bool MessageConObjetoReferenciaReturnsBoolean(ref Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public bool MessageConParametroOutReturnsBoolean(string str, out string outputStr)
        {
            outputStr = "Hola" + str;
            return true;
        }

        public string MessageConReturnsStr(string message)
        {
            Console.WriteLine(message);
            return message.ToLower();
        }
    }

    public class LoggerFake : ILoggerGeneral
    {
        public int PrioridadLogger { get; set; }
        public string TipoLogger { get; set; }

        public bool LogBalanceDespuesRetiro(int balanceDespuesRetiro)
        {
            return false;
        }

        public bool LogDataBase(string message)
        {
            return false;
        }

        public void Message(string message)
        {
        }

        public bool MessageConObjetoReferenciaReturnsBoolean(ref Cliente cliente)
        {
            return true;
        }

        public bool MessageConParametroOutReturnsBoolean(string str, out string outputStr)
        {
            outputStr = "";
            return true;
        }

        public string MessageConReturnsStr(string message)
        {
            throw new NotImplementedException();
        }
    }
}
