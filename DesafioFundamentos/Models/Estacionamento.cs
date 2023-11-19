using System;
using System.Collections.Generic;

namespace SistemaParaUmEstacionamento
{
    class Estacionamento
    {
        private List<string> veiculos = new List<string>(); 
        private Dictionary<string, DateTime> horaEntradaVeiculos = new Dictionary<string, DateTime>(); 
        private Dictionary<string, DateTime> horaSaidaVeiculos = new Dictionary<string, DateTime>(); 
        private Dictionary<string, decimal> valorAPagarVeiculos = new Dictionary<string, decimal>(); 

        public void AdicionarVeiculo(string placa)
        {
            veiculos.Add(placa);
            horaEntradaVeiculos[placa] = DateTime.Now; 
        }

        public void RemoverVeiculo(string placa)
        {
            if (veiculos.Contains(placa))
            {
                veiculos.Remove(placa);
                horaEntradaVeiculos.Remove(placa);
                horaSaidaVeiculos.Remove(placa);
                valorAPagarVeiculos.Remove(placa);
            }
        }

        public void ListarVeiculos()
        {
            Console.WriteLine("Veículos no estacionamento:");
            foreach (var placa in veiculos)
            {
                Console.WriteLine($"Placa: {placa}");
            }
        }

        public void RegistrarHoraEntrada(string placa, DateTime horaEntrada)
        {
            horaEntradaVeiculos[placa] = horaEntrada;
        }

        public void RegistrarHoraSaida(string placa, DateTime horaSaida)
        {
            horaSaidaVeiculos[placa] = horaSaida;
        }

        public void DefinirValorAPagar(string placa, decimal valorAPagar)
        {
            valorAPagarVeiculos[placa] = valorAPagar;
        }

        public decimal FinalizarVeiculo(string placa)
        {
            decimal precoTotal = 0;
            if (veiculos.Contains(placa) && horaSaidaVeiculos.ContainsKey(placa))
            {
                DateTime horaEntrada = horaEntradaVeiculos[placa];
                DateTime horaSaida = horaSaidaVeiculos[placa];
                TimeSpan permanencia = horaSaida - horaEntrada;
                decimal precoPorHora = valorAPagarVeiculos[placa];
                precoTotal = precoPorHora * (decimal)permanencia.TotalHours;
                RemoverVeiculo(placa); 
            }
            return precoTotal;
        }
    }
}
