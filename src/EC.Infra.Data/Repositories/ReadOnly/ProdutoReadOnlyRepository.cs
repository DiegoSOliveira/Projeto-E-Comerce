using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using EC.Domain.Entities.Produtos;
using EC.Domain.Interfaces.Repository.ReadOnly;

namespace EC.Infra.Data.Repositories.ReadOnly
{
    public class ProdutoReadOnlyRepository : RepositoryBaseReadOnly, IProdutoReadOnlyRepository
    {
        public Produto GetById(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                var sql = @"Select * From Produto p " +
                          "WHERE p.ProdutoId = @sid";

                cn.Open();

                var produto = cn.Query<Produto>(sql, new { sid = id });

                return produto.FirstOrDefault();
            }
        }

        public IEnumerable<Produto> GetAll()
        {
            using (IDbConnection cn = Connection)
            {
                
                var sql = @"SELECT * FROM Produto p ORDER BY p.Nome asc";

                cn.Open();

                var produto = cn.Query<Produto>(sql);

                return produto;
            }
        }

        public IEnumerable<Produto> GetByName(string nome)
        {
            using (IDbConnection cn = Connection)
            {
                
                var sql = @"SELECT * FROM Produto p " +
                          "Where Contains(Nome,'@nome') " +
                          "ORDER BY p.Nome asc";

                cn.Open();

                var produto = cn.Query<Produto>(sql, new { @nome = nome });

                return produto;
            }
        }

        public IEnumerable<Produto> BuscarPorCategoria(string categoria)
        {
            using (IDbConnection cn = Connection)
            {
                var sql = @"SELECT * FROM Produto p " +
                          "Inner Join ProdutoCategoria pc On p.ProdutoId = pc.ProdutoId" +
                          "Inner Join Categoria c On c.CategoriaId = pc.CategoriaId" +
                          "Where c.Nome = @categoria " +
                          "ORDER BY p.Nome asc";

                cn.Open();

                var produto = cn.Query<Produto>(sql,new {categoria = categoria});

                return produto;
            }
        }
    }
}