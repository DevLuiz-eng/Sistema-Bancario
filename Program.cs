using System;
using System.ComponentModel;
using System.Threading;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Net;

class Program
{

    static void Main()
    {


        int menu, numeroConta, numeroAleatorio, num, back = 0;
        string titular, senha;
        double saldo, deposito;
        Banco banco = new Banco();
        List<string> historico = new List<string>();


        Console.Clear();
        Console.WriteLine("----------BANCO DO MUNDO----------\n");

        ContaBancaria pedro = new ContaBancaria("Pedro", 1234, 23);
        ContaBancaria luan = new ContaBancaria("Luan", 2222, 44);
        ContaBancaria belly = new ContaBancaria("Isabhelly Rocha", 22, 12);

        banco.AdicionarConta(pedro);
        banco.AdicionarConta(luan);
        banco.AdicionarConta(belly);

        //Login

        Console.WriteLine("Press ENTER para criar sua conta");
        Console.ReadLine();

        Console.Clear();
        Console.WriteLine("----------BANCO DO MUNDO----------\n");
        do
        {

            Console.Write("Olá, antes de tudo, digite seu nome: ");
            titular = Console.ReadLine();

            if (titular.Any(char.IsDigit))
            {
                Console.WriteLine("Seu nome deve conter apenas letras.");
            }
        } while (titular.Any(char.IsDigit));

        Console.WriteLine("salvando...");
        Thread.Sleep(1000);

        do
        {

            Console.Write($"Olá, {titular}, seja bem-vindo. Agora você precisa criar sua senha de 4 digitos: ");
            senha = Console.ReadLine();

            if (!senha.All(char.IsDigit) || senha.Length != 4)
            {
                Console.WriteLine("Deve ser apenas números e com apenas 4 dígitos.");
            }
        } while (!senha.All(char.IsDigit) || senha.Length != 4);

        Console.WriteLine("salvando...");
        Thread.Sleep(1000);

        Console.Write("Agora, crie uma chave de transação: ");
        numeroAleatorio = int.Parse(Console.ReadLine());


        Console.WriteLine("Salvando...");
        Thread.Sleep(2000);

        Console.Clear();
        ContaBancaria conta = new ContaBancaria(titular, int.Parse(senha), numeroAleatorio);
        banco.AdicionarConta(conta);
        conta.MostrarInformacoes();

        Console.WriteLine("Press ENTER para acessar o banco.");
        Console.ReadLine();

        // Menu
        do
        {
            Console.Clear();
            Console.WriteLine("----------BANCO DO MUNDO----------\n");
            Console.WriteLine("1 - Depositar\n2 - Transferir\n3 - Sacar\n4 - Lista de transferências\n5 - Ver informações\n6 - Sair\n");
            Console.Write("Selecione: ");
            menu = int.Parse(Console.ReadLine());

            switch (menu)
            {
                case 1:
                    Console.WriteLine("----------BANCO DO MUNDO----------\n");
                    Console.Clear();
                    conta.Depositar();
                    Console.WriteLine("-------------\nPress ENTER para voltar ao menu inicial");
                    Console.ReadLine();

                    back = 1;
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("----------BANCO DO MUNDO----------\n");
                    Console.WriteLine($"Saldo: {conta.Saldo:F2}\n");
                    Console.Write("Digite a chave de transferência do destinatário: ");
                    int chaveDestino = int.Parse(Console.ReadLine());

                    Console.Write("Digite o valor a transferir: ");
                    double valorTransferencia = double.Parse(Console.ReadLine());
                    do
                    {

                        Console.Write("Digite sua senha para concluir a operação: ");
                        num = int.Parse(Console.ReadLine());

                        if (conta.VerificarSenha(num))
                        {
                            continue;

                        }
                        else
                        {
                            Console.WriteLine("Senha errada.");
                        }
                    } while (conta.VerificarSenha(num) == false);

                    banco.Transferir(conta, chaveDestino, valorTransferencia);
                    conta.RegistrarHistorico($"Enviado R${valorTransferencia} para conta da chave {chaveDestino}\n----------- ");

                    Console.WriteLine("Press ENTER para retornar ao menu inicial...");
                    Console.ReadLine();
                    back = 1;
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("----------BANCO DO MUNDO----------\n");
                    Console.WriteLine($"Saldo: {conta.Saldo:F2}\n");
                    do
                    {

                        Console.Write("Digite sua senha para concluir a operação: ");
                        num = int.Parse(Console.ReadLine());

                        if (conta.VerificarSenha(num))
                        {
                            continue;

                        }
                        else
                        {
                            Console.WriteLine("Senha errada.");
                        }
                    } while (conta.VerificarSenha(num) == false);
                    conta.Sacar();
                    Console.WriteLine("Press ENTER para retornar ao menu inical...");
                    Console.ReadLine();
                    back = 1;

                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("----------BANCO DO MUNDO----------\n");

                    if (conta.Historico.Count == 0)
                    {
                        Console.WriteLine("ainda não foi realizado nenhuma transferência.");
                        Console.WriteLine("Press ENTER para retornar ao menu inical...");
                        Console.ReadLine();
                        back = 1;
                        break;
                    }
                    else
                    {
                        foreach (string item in conta.Historico)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("Press ENTER para retornar ao menu incial...");
                        Console.ReadLine();
                        back = 1;
                        break;
                    }


                    break;

                case 5:
                    Console.WriteLine("----------BANCO DO MUNDO----------\n");
                    Console.Clear();
                    conta.MostrarInformacoes();
                    Console.WriteLine("Press ENTER para retornare ao menu inicial.");
                    Console.ReadLine();

                    back = 1;
                    break;

                case 6:
                    back = 0;
                    break;
            }

        } while (back == 1);
    }
}