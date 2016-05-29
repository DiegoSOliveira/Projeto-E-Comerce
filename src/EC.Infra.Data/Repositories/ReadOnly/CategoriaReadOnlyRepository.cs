using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using EC.Domain.Entities.Clientes;
using EC.Domain.Entities.Produtos;
using EC.Domain.Interfaces.Repository.ReadOnly;

namespace EC.Infra.Data.Repositories.ReadOnly
{
    public class CategoriaReadOnlyRepository : RepositoryBaseReadOnly, ICategoriaReadOnlyRepository
    {
        public Categoria GetByName(string nome)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From Categoria c " +
                          "WWhere Contains(Nome,'@nome') " +
                          "ORDER BY Nome asc";


                var categoria = cn.Query<Categoria>(sql, new { nome = nome });

                return categoria.FirstOrDefault();
            }
        }

        public IEnumerable<Categoria> GetAll()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = "Select * From Categoria Order By Nome asc";

                var categorias = cn.Query<Categoria>(sql);

                cn.Close();

                return categorias;
            };
        }
    }
}