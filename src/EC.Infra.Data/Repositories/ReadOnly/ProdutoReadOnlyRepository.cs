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
                cn.Open();

                var sql = @"Select * From Produto p " +
                          "WHERE p.ProdutoId = @sid";

                var produto = cn.Query<Produto>(sql, new {sid = id});

                return produto.FirstOrDefault();
            }
        }

        public IEnumerable<Produto> GetAll()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"SELECT * FROM Produto p ";

                var produto = cn.Query<Produto>(sql);

                return produto;
            }
        }
    }
}