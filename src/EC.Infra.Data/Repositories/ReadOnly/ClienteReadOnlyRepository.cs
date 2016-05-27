using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using EC.Domain.Entities.Clientes;
using EC.Domain.Entities.Geografia;
using EC.Domain.Interfaces.Repository.ReadOnly;

namespace EC.Infra.Data.Repositories.ReadOnly
{
    public class ClienteReadOnlyRepository : RepositoryBaseReadOnly, IClienteReadOnlyRepository
    {
        public Cliente GetById(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                var sql = @"Select * Cliente c " +
                          "Where c.ClienteId = @sid " +
                          "Select * From Endereco e " +
                          "Inner join Endereco e " +
                          "On c.EnderecoId = e.Endereco.Id " +
                          "Inner join Cidade cd " +
                          "On cd.CidadeId = e.CidadeId " +
                          "Inner join Estado es " +
                          "On es.EstadoId = e.EstadoId" +
                          "Where e.ClienteId = @sid";
                cn.Open();
                var multi = cn.QueryMultiple(sql, new {sid = id});
                var clientes = multi.Read<Cliente>();
                var enderecos = multi.Read<Endereco, Estado, Cidade, Endereco>(
                    (en, es, c) =>
                    {
                        en.EstadoId = es.EstadoId;
                        en.CidadeId = c.CidadeId;
                        en.Estado = es;
                        en.Cidade = c;

                        return en;
                    }, splitOn: "EnderecoId, EstadoId,CidadeId");

                var cliente = clientes.First();

                foreach (var endereco in enderecos)
                {
                    cliente.EnderecoList.Add(endereco);
                }
                 cn.Close();
                return cliente;
            }

        }

        public IEnumerable<Cliente> GetAll()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = "Select * From Cliente Order By Nome asc";

                var clientes = cn.Query<Cliente>(sql);

                cn.Close();

                return clientes;
            };
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"SELECT COUNT(NOME) 'Total' FROM CLIENTE
                          WHERE (@nomePesquisa IS NULL OR Nome Like '%' + @nomePesquisa + '%')";

                var total = (int)cn.ExecuteScalar(sql, new { nomePesquisa = pesquisa });
                 
                cn.Close();

                return total;
            }
        }

        public IEnumerable<Cliente> ObterClientesGrid(int page, string pesquisa)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"SELECT * FROM Cliente
                            WHERE (@nomePesquisa IS NULL OR Nome Like '%' + @nomePesquisa + '%')
                            ORDER BY Nome asc
                            OFFSET @pagina ROWS
                            FETCH NEXT 5 ROWS ONLY";

                var clientes = cn.Query<Cliente>(sql, new { nomePesquisa = pesquisa, pagina = page });

                cn.Close();

                return clientes;
            }
        }
    }
}