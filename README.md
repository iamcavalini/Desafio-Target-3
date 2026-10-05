Cálculo de Juros por Atraso

Este projeto consiste numa aplicação de consola desenvolvida em C# (.NET 8.0) que solicita ao utilizador o valor original de uma conta e a sua data de vencimento, calculando automaticamente a quantidade de dias em atraso e o valor total a pagar com juros diários.

---

Regras de Negócio e Funcionalidades

- Entrada Interativa: Permite ao utilizador digitar o valor base e a data de vencimento da conta.
- Validação de Dados: Trata erros de digitação para garantir valores numéricos positivos e datas num formato válido (`DD/MM/AAAA`).
- Verificação de Atraso: Identifica se o pagamento está em dia com base na data atual (`DateTime.Today`).
- Taxa de Juros: Aplica uma taxa fixa de 2,5% ao dia sobre o valor original para cada dia decorrido após o vencimento.

---

Tecnologias Utilizadas

- Linguagem: C# (.NET 8.0)
- Ambiente de Desenvolvimento: Visual Studio 2022

---

Como Executar o Projeto

Pré-requisitos
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) instalado na máquina.
- IDE (Visual Studio).

Passos
1. Clonar o repositório
2. Acessar a pasta do projeto
3. Executar a aplicação via terminal
