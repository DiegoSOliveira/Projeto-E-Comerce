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
        public Cliente ObterPorCpf(string cpf)
        {
            using (IDbConnection cn = Connection)
            {
                var query = @"Select * From Cliente c " +
                              "Where c.CPF = @cpf";

                cn.Open();

                var cliente = cn.Query(query, new {cpf = cpf});

                cn.Close();

                return cliente.FirstOrDefault();
            }
        }

        public Cliente ObterPorEmail(string email)
        {
            using (IDbConnection cn = Connection)
            {
                var query = @"Select * From Cliente c " +
                              "Where c.Email = @email";

                cn.Open();

                var cliente = cn.Query(query, new { email = email });

                cn.Close();

                return cliente.FirstOrDefault();
            }
        }

        public Cliente GetById(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                var clienteQuery = @"Select * From Cliente c " +
                              "Where c.ClienteId = @sid ";

                var enderecoQuery = "Select * From Endereco e " +
                          "Where e.ClienteId = @sid";

                cn.Open();

                var clientes = cn.Query<Cliente>(clienteQuery, new {sid = id});
                var enderecos = cn.Query<Endereco>(enderecoQuery, new {sid = id});

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