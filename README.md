# 🏦 Sistema Bancário em C#

## 📝 Descrição

**O que o projeto faz:**  
Este sistema bancário permite criar contas, realizar depósitos, saques, transferências e exibir o saldo. Foi projetado para simular operações básicas de um banco, com foco em lógica de programação e manipulação de dados.

**Tecnologias utilizadas:**  
- Linguagem: `C#`  
- Plataforma: `.NET`  
- IDE utilizada: `Visual Studio` ou `Visual Studio Code`

**Por que foi construído:**  
Este projeto foi criado para aprofundar meus conhecimentos em C# e boas práticas de programação, como encapsulamento, reutilização de métodos e estruturação de dados com classes e listas.

**Instrução de uso:**  
O usuário pode acessar um menu interativo pelo console para cadastrar contas, movimentar valores e consultar informações bancárias.

---

## ⚙️ Documentação Técnica

**Funcionalidades principais:**
- ✅ Criação de contas com titular e saldo inicial  
- ✅ Depósito e saque em contas existentes  
- ✅ Transferência de valores entre contas  
- ✅ Consulta de saldo e informações da conta  
- ✅ Lista de todas as contas criadas

**Estrutura do código:**
- `Conta.cs`: classe que representa uma conta bancária (atributos, métodos de movimentação)  
- `Banco.cs`: classe que gerencia as contas e operações globais  
- `Program.cs`: exibe o menu, interage com o usuário via terminal

**Padrões e práticas utilizadas:**
- Encapsulamento com `get` e `set`  
- Estrutura `List<Conta>` para armazenar múltiplas contas  
- Métodos bem divididos para cada operação  
- Uso de `Console.ReadLine()` para entrada de dados  
- Validações simples para evitar operações inválidas

---

## ▶️ Como Executar

**Pré-requisitos:**
- .NET SDK instalado ([instalar aqui](https://dotnet.microsoft.com/en-us/download))
- Visual Studio ou Visual Studio Code

**Executar via terminal:**

```bash
# Clone o repositório
git clone https://github.com/DevLuiz-eng/sistema-bancario-csharp.git

# Acesse a pasta do projeto
cd sistema-bancario-csharp

# Compile o projeto
dotnet build

# Execute o projeto
dotnet run
