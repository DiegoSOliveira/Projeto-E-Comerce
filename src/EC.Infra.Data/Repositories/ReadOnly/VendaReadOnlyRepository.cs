using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using EC.Domain.Entities.Clientes;
using EC.Domain.Entities.Produtos;
using EC.Domain.Entities.Vendas;
using EC.Domain.Interfaces.Repository.ReadOnly;

namespace EC.Infra.Data.Repositories.ReadOnly
{
    public class VendaReadOnlyRepository : RepositoryBaseReadOnly, IVendaReadOnlyRepository
    {
        public Venda GetById(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From Venda v " +
                          "inner join VendaProdutos vp " +
                          "on v.VendaId = vp.VendaId " +
                          "inner join Produto p " +
                          "on vp.ProdutoId = p.ProdutoId " +
                          "inner join Cliente c " +
                          "on v.ClienteId = c.ClienteId " +
                          "Where v.VendaId = @sid";


                var vendas = cn.Query<Venda, Produto, Cliente, Venda>(
                    sql,
                    (v, p, c) =>
                    {
                        v.ProdutosList.Add(p);
                        v.Cliente = c;

                        return v;
                    }, splitOn: "VendaId, ProdutoId, ClienteId").FirstOrDefault();

                return vendas;
            }
        }

        public IEnumerable<Venda> GetAll()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From Venda v Order By DataCadastro asc";

                var venda = cn.Query<Venda>(sql);

                return venda;
            }
        }
    }
}