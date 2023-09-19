using CadastroProduto;
using System;

Produto.ProdutoRepository produtoRepository = new();

bool sair = false;

while (!sair)
{
    Console.Clear();
    Console.WriteLine("Menu Principal:");
    Console.WriteLine("1. Adicionar um novo item");
    Console.WriteLine("2. Remover item pelo ID");
    Console.WriteLine("3. Editar um item pelo ID ");
    Console.WriteLine("4. Ver todos os itens cadastrados");
    Console.WriteLine("5. Sair");
    Console.Write("Escolha uma opção: ");

    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            AdicionarNovoProduto();
            break;
        case "2":
            RemoverProduto();
            break;
        case "3":
            EditarProduto();
            break;
        case "4":
            ListarProdutos();
            break;
        case "5":
            sair = true;
            break;
        default:
            Console.WriteLine("Opção inválida. Pressione Enter para continuar.");
            Console.ReadLine();
            break;
    }
}

void AdicionarNovoProduto()
{
    Console.Clear();
    Console.WriteLine("Adicionar um novo produto:");

    Console.Write("Nome do produto: ");
    string nome = Console.ReadLine();

    Console.Write("Preço do produto: ");
    double preco;
    if (double.TryParse(Console.ReadLine(), out preco))
    {
        Produto produto = new(nome, preco);
        produtoRepository.Create(produto);
        Console.WriteLine("Produto adicionado com sucesso!");
    }
    else
    {
        Console.WriteLine("Preço inválido. O produto não foi adicionado.");
    }

    Console.WriteLine("Pressione Enter para continuar.");
    Console.ReadLine();
}

void RemoverProduto()
{
    Console.Clear();
    Console.WriteLine("Remover produto:");
    Console.Write("Digite o ID do produto que deseja remover: ");

    if (int.TryParse(Console.ReadLine(), out int id))
    {
        Produto produto = produtoRepository.ReadById(id);
        if (produto != null)
        {
            produtoRepository.Delete(id);
            Console.WriteLine("Produto removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }
    }
    else
    {
        Console.WriteLine("ID inválido.");
    }

    Console.WriteLine("Pressione Enter para continuar.");
    Console.ReadLine();
}

void EditarProduto()
{
    Console.Clear();
    Console.WriteLine("Editar um produto:");
    Console.Write("Digite o ID do produto que deseja editar: ");

    if (int.TryParse(Console.ReadLine(), out int id))
    {
        Produto produto = produtoRepository.ReadById(id);
        if (produto != null)
        {
            Console.Write("Novo nome do produto: ");
            string novoNome = Console.ReadLine();

            produtoRepository.Update(id, novoNome);
            Console.WriteLine("Produto atualizado com sucesso!");
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }
    }
    else
    {
        Console.WriteLine("ID inválido.");
    }

    Console.WriteLine("Pressione Enter para continuar.");
    Console.ReadLine();
}

void ListarProdutos()
{
    Console.Clear();
    Console.WriteLine("Todos os produtos:");
    List<Produto> produtos = produtoRepository.ListAll();

    foreach (var produto in produtos)
    {
        Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}, Preço: {produto.Preco}");
    }

    Console.WriteLine("Pressione Enter para continuar.");
    Console.ReadLine();
}
