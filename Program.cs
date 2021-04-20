﻿using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;

                    case "2":
                        InserirConta();
                        break;

                    case "3":
                        Transferir();
                        break;
                    
                    case "4":
                        Sacar();
                        break;

                    case "5":
                        Depositar();
                        break;

                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();                        
                }
                 
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços!!!");
            Console.ReadLine();
        }

        private static void ListarContas()
		{
			Console.WriteLine("--- Listar Contas ----");

			if (listContas.Count == 0)
			{
				Console.WriteLine("Nenhuma conta cadastrada!");
				return;
			}

			for (int i = 0; i < listContas.Count; i++)
			{
                Conta conta = listContas[i];  
				Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
			}
		}

        private static void Sacar()
		{
			Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
                       
            if (indiceConta < listContas.Count){

                Console.Write("Digite o valor do saque: ");
                double valorSaque = double.Parse(Console.ReadLine());   

                listContas[indiceConta].Sacar(valorSaque);  

            } else{
                Console.WriteLine("Conta inexistente!");
                return;
            }	                    			
		}

        private static void Depositar()
		{
			Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            if (indiceConta < listContas.Count){

                Console.Write("Digite o valor do deposito: ");
                double valorDeposito = double.Parse(Console.ReadLine());

                listContas[indiceConta].Depositar(valorDeposito);

            } else{
                Console.WriteLine("Conta inexistente!");
                return;
            }		
		}

        private static void Transferir()
		{
			Console.Write("Digite o número da conta de ORIGEM: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            if (indiceContaOrigem < listContas.Count)
            {
                Console.Write("Digite o número da conta de DESTINO: ");
                int indiceContaDestino = int.Parse(Console.ReadLine());
                
                if (indiceContaDestino < listContas.Count)
                {

                    Console.Write("Digite o valor da transferência: ");
                    double valorTransferencia = double.Parse(Console.ReadLine());

                    listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);		
                
                } else
                {
                    Console.WriteLine("Conta de DESTINO inexistente!");
                    return;
                  }
            }else
            {
                Console.WriteLine("Conta de ORIGEM inexistente!");
                return;
            }
		}


        private static void InserirConta()
		{
			Console.WriteLine("--- Inserir nova Conta ---");

			foreach (int i in Enum.GetValues(typeof(TipoConta)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(TipoConta), i));
			}

            Console.Write("Digite o tipo de conta: ");
			int entradaTipoConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o nome do cliente: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite o saldo inicial: ");
			double entradaSaldo = double.Parse(Console.ReadLine());

			Console.Write("Digite o crédito: ");
			double entradaCredito = double.Parse(Console.ReadLine());

			Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo, 
										credito: entradaCredito,
										nome: entradaNome);

			listContas.Add(novaConta);
		}

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir Nova Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
