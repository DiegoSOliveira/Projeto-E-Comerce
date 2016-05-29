using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using EC.Domain.Entities.Geografia;
using EC.Domain.Interfaces.Repository.ReadOnly;

namespace EC.Infra.Data.Repositories.ReadOnly
{
    public class EnderecoReadOnlyRepository : RepositoryBaseReadOnly, IEnderecoReadOnlyRepository
    {
        public IEnumerable<Endereco>GetByCliente(Guid clienteId)
        {
            using (IDbConnection cn = Connection)
            {
                var query = @"Select * From Endereco e " +
                             "Inner Join Cliente c On c.ClienteId = e.ClienteId" +
                              "Where e.ClienteId = @sid";

                cn.Open();

                var endereco = cn.Query<Endereco>(query, new { sid = clienteId });

                cn.Close();

                return endereco;
            }
        }

        public Endereco GetById(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                var query = @"Select * From Endereco e " +
                             "Where e.EnderecoId = @sid";

                cn.Open();

                var endereco = cn.Query<Endereco>(query, new { sid = id});

                cn.Close();

                return endereco.First();
            }
        }

        public IEnumerable<Endereco> GetAll()
        {
            using (IDbConnection cn = Connection)
            {
                var query = @"Select * From Endereco";

                cn.Open();

                var endereco = cn.Query<Endereco>(query);

                cn.Close();

                return endereco;
            }
        }
    }
}