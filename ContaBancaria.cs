using System;
using System.Runtime.InteropServices.Marshalling;
using System.Collections.Generic;

public class ContaBancaria
{

    public List<string> Historico { get; private set; } = new List<string>();
    public List<int> transfer = new List<int>();
    public int NumeroConta { get; set; }
    public int TransferNumber { get; set; }
    public string Titular { get; private set; }
    public double Saldo { get; set; }
    public int Senha { get; private set; }


    public ContaBancaria(string Titular, int Senha, int transNumber)
    {
        Random random = new Random();
        NumeroConta = random.Next(1000, 10000);
        this.TransferNumber = transNumber;
        this.Senha = Senha;
        this.Titular = Titular;
        this.Saldo = 0;
        transfer.Add(transNumber);

    }

    public void Depositar()
    {
        int valor;
        Console.WriteLine("Digite o valor: ");
        valor = int.Parse(Console.ReadLine());

        if (valor < 0)
        {
            Console.WriteLine("Valor inválido! ");
        }
        else
        {
            Saldo += valor;
            Console.WriteLine($"R${valor} depositado com sucesso!");
        }
    }

    public void Sacar()
    {

        Console.Write("Digite o valor que voce quer sacar: ");
        double valor = double.Parse(Console.ReadLine());
        if (valor > 0 && valor <= Saldo)
        {
            Saldo -= valor;
            Console.WriteLine($"Saque de {valor} realizado com sucesso!");
        }
        else
        {
            Console.WriteLine("impossível realizar transição.");
        }
    }

    public void MostrarInformacoes()
    {
        Console.WriteLine("--------- DADOS ---------");

        Console.WriteLine($"Conta Nº: {NumeroConta}");
        Console.WriteLine($"Titular: {Titular}");
        Console.WriteLine($"Saldo: R${Saldo:F2}");
        Console.WriteLine($"Chave de transferência: {TransferNumber}");
    }

    public bool VerificarSenha(int tentativa)
    {
        return tentativa == Senha;
    }
    public void RegistrarHistorico(string descricao)
    {
        Historico.Add($"{DateTime.Now}: {descricao}");
    }
}