
using CalculoIR.Entidades;

namespace CalculoIR.Entidades
{
    class PessoaFisica : Contribuinte
    {
        public double GastosSaude { get; set; }

        public PessoaFisica()
        {

        }

        public PessoaFisica(string nome, double rendaAnual, double gastosSaude) : base(nome, rendaAnual)
        {
            GastosSaude = gastosSaude;
        }

        public override double CalculaIR()
        {
            double imposto = 0.0;

            if (RendaAnual < 20000)
            {
                imposto = RendaAnual * 0.15;
            }
            else
            {
                imposto = RendaAnual * 0.25;
            }

            if (GastosSaude > 0)
            {
                imposto -= GastosSaude * 0.50;
            }

            return imposto;
        }

        public override string ToString()
        {
            return Nome + ": $ " + CalculaIR();
        }
    }
}
