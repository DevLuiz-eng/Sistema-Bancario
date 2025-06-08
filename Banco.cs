using System;
using System.ComponentModel;
using System.Net.Mime;
using System.Runtime.InteropServices;

public class Banco
{

    List<ContaBancaria> Counts = new List<ContaBancaria>();

    public void AdicionarConta(ContaBancaria conta)
    {
        Counts.Add(conta);
    }

    public ContaBancaria BuscarPorChave(int chave)
    {
        return Counts.Find(c => c.TransferNumber == chave);
    }

    public void Transferir(ContaBancaria origem, int chave, double valor)
    {
        ContaBancaria destino = BuscarPorChave(chave);

        if (destino != null && origem.Saldo >= valor && valor > 0)
        {
            origem.Saldo -= valor;
            destino.Saldo += valor;
            Console.WriteLine($"Transferência de R$ {valor} enviada para {destino.Titular} com sucesso!");
        }
        else
        {
            Console.WriteLine("impossível concluir transação!");
        }
    }
}