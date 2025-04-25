using System;
using System.Collections.Generic;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva()
        {

        }

        public Reserva(int dias)
        {
            DiasReservados = dias;
        }

        public void CadastrarHospedes(List<Pessoa> listaDeHospedes)
        {
            if (Suite != null)
            {
                if (listaDeHospedes.Count <= Suite.Capacidade)
                {
                    Hospedes = listaDeHospedes;
                }
                else
                {
                    throw new Exception("Capacidade da suite não é suficiente para a quantidade de hospedes");
                }
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            if (Hospedes != null)
            {
                return Hospedes.Count;
            }
            else
            {
                return 0;
            }
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = 0;

            valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {
                decimal desconto = valor * 0.10m;
                valor = valor - desconto;
            }

            return valor;
        }
    }
}
