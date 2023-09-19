using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroProduto
{
    public class Produto
    {
        public int Id { get; private set; }

        public string Nome { get; private set; }

        public double Preco { get; private set; }

        public Produto(string nome, double preco) 
        { 
            this.Nome = nome;
            this.Preco = preco;
        }

        public class ProdutoRepository
        {
            private List<Produto> produtos = new();
            private int proxId = 1;

            public void Create(Produto produto)
            {
                produto.Id = proxId;
                proxId++;
                produtos.Add(produto);
            }

            public void Delete(int id)
            {
                Produto produtoDeletar = ReadById(id);
                if (produtoDeletar != null)
                {
                    produtos.Remove(produtoDeletar);
                }
            }

            public List<Produto> ListAll()
            {
                return produtos;
            }

            public Produto ReadById(int id)
            {
                return produtos.Find(produto => produto.Id == id);
            }

            public void Update(int id, string novoNome)
            {
                Produto produto = ReadById(id);
                if (produto != null)
                {
                    produto.Nome = novoNome;
                }
            }
        }
    }
}
