using System;
using System.Globalization;

namespace Questao1
{
    public class ContaBancaria {
        public int Numero { get; }
        public string Titular { get; }
        public double DepositoInicial { get; }
        public double saldo { get; set; }

        public ContaBancaria(int numero, string titular)
        {
           this.Numero = numero;
           this.Titular = titular;
        }

        public ContaBancaria(int numero, string titular, double depositoInicial)
        {
            this.Numero = numero;
            this.Titular = titular;
            this.DepositoInicial = depositoInicial;
            this.saldo = saldo + depositoInicial;
        }

        public void Deposito(double quantia)
        {
            this.saldo += quantia;
        }

        public void Saque(double quantia)
        {
            this.saldo -= (quantia);
            this.saldo -= 3.5;
        }
    }
}
