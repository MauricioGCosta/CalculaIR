using CalculoIR.Entidades;
using System.Globalization;

namespace CalculoIR.Entidades
{
    class PessoaJuridica : Contribuinte
    {
        public int NumFuncionarios { get; set; }

        public PessoaJuridica()
        {

        }

        public PessoaJuridica(string nome, double rendaAnual, int numFuncionarios) : base(nome, rendaAnual)
        {
            NumFuncionarios = numFuncionarios;
        }

        public override double CalculaIR()
        {
            double imposto = 0.0;

            if (NumFuncionarios > 10)
                imposto = RendaAnual * 0.14;
            else
                imposto = RendaAnual * 0.16;

            return imposto;
        }

        public override string ToString()
        {
            return Nome + ": $ " + CalculaIR();
        }
    }
}
