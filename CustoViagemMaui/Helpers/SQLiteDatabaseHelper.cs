using CustoViagemMaui.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustoViagemMaui.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Pedagio>().Wait();
        }

        public Task<int> Insert(Pedagio p)
        {
            return _conn.InsertAsync(p);
        }

        public Task<List<Pedagio>> Update(Pedagio p)
        {
            string sql = "Update Pedagio SET ValorPedagio=? where NumeroPedagio=?";
            return _conn.QueryAsync<Pedagio>(sql, p.ValorPedagio, p.NumeroPedagio);
        }

        public Task<List<Pedagio>> GetAll()
        {
            return _conn.Table<Pedagio>().ToListAsync();
        }

        public Task<List<Pedagio>> GetValue()
        {
            string sql = "Select ValorPedagio from Pedagio";

            return _conn.QueryAsync<Pedagio>(sql);
        }

        public Task<int> Delete(int id)
        {
            return _conn.Table<Pedagio>().DeleteAsync(i => i.NumeroPedagio == id);
        }

        public Task<List<Pedagio>> Search(string q)
        {
            string sql = "Select * from Pedagio where Local like '%" + q + "%'";

            return _conn.QueryAsync<Pedagio>(sql);
        }
    }
}
