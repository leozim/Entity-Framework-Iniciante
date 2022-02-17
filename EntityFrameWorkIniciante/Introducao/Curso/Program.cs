using System;
using System.Collections.Generic;
using System.Linq;
using CursoEFCore.Domain;
using CursoEFCore.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new Data.ApplicationContex();

            // db.Database.Migrate(); // Uso recomendado em desenvolvimento

            var existe = db.Database.GetPendingMigrations().Any();

            if (existe)
            {
                // criar condição para parar a aplicação caso exista migrações pendentes
            }

            Console.WriteLine("Hello World!");
        }

        private static void InserirDados()
        {
                var produto = new Produto
                {
                    Descricao = "Produto test",
                    CodigoBarras = "1234567891231",
                    Valor = 10m,
                    Tipo = TipoProduto.MercadoriaParaRevenda,
                    Ativo = true
                };

                using var db = new Data.ApplicationContex();
                db.Produtos.Add(produto);
                // db.Set<Produto>().Add(produto);
                // db.Entry(produto).State = EntityState.Added;
                // db.Add(produto);

                var registros = db.SaveChanges();
        }

        private static void InserirDadosEmMassaPorLista()
        {
            var lista = new[]
            {
                new Produto 
                {
                    Descricao = "Produto test2",
                    CodigoBarras = "1234567891232",
                    Valor = 10m,
                    Tipo = TipoProduto.MercadoriaParaRevenda,
                    Ativo = true
                },
                new Produto 
                {
                    Descricao = "Produto test3",
                    CodigoBarras = "1235567891231",
                    Valor = 10m,
                    Tipo = TipoProduto.MercadoriaParaRevenda,
                    Ativo = true
                },
                new Produto 
                {
                    Descricao = "Produto test4",
                    CodigoBarras = "1234567851231",
                    Valor = 10m,
                    Tipo = TipoProduto.MercadoriaParaRevenda,
                    Ativo = true
                },
            };

            using var db = new Data.ApplicationContex();
            db.Produtos.AddRange(lista);
        }

        private static void InserirDadosEmMassa()
        {
            var produto = new Produto() 
            {
                //
            };

            var cliente = new Cliente() 
            {
                // 
            };

            var pedido = new Pedido()
            {
                //
            };

            using var db = new Data.ApplicationContex();
            db.AddRange(produto, cliente, pedido);
        }

        private static void ConsultarDados()
        {
            using var db = new Data.ApplicationContex();
            // var consultaPorSintaxe = (from c in db.Clientes where c.Id > 0 select c).ToList(); //consulta LINQ por sintaxe
            var consultaPorMetodo = db.Pedidos.Where(p => p.Id > 0).ToList();
            // var consultaAsNoTracking = db.Pedidos.AsNoTracking().Where(p => p.Id > 0).ToList();

            foreach(var pedido in consultaPorMetodo)
            {
                db.Pedidos.Find(pedido.Id); // vai primeiro nos registros Tracked em memória e depois faz a consulta no banco de dados
            }
        }
    }
}
