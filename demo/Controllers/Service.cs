using Microsoft.Data.Sqlite;
using System.Threading.Tasks;

namespace demo.Controllers
{
    public class Service
    {
        public bool isPrime(ModelCls model)
        {
            int n, i, m = 0, flag = 0;
            n = model.Number;
            m = n / 2;
            for (i = 2; i <= m; i++)
            {
                if (n % i == 0)
                {
                    return false;
                    break;
                }
            }
            if (flag == 0)
                return true;

            return false;
        }


        public async Task<ModelCls> GetCartItemsAsync()
        {
            ModelCls modelCls = new ModelCls();
                using (var firstConnection = new SqliteConnection(DbConnection.connectionString))
                {
                    firstConnection.Open();
                    var updateCommand = firstConnection.CreateCommand();
                    updateCommand.CommandText =
                   @"
                        SELECT *
                        FROM NUMBER
                    ";
                    SqliteDataReader adr = updateCommand.ExecuteReader();

                    while (adr.Read())
                {
                    modelCls.Number = adr.GetInt32(1);
                }
                }
            return await Task.FromResult(modelCls);
        }

        public async Task<bool> CreateDbAsync()
    {
        DbConnection.CreateTables();
        return await Task.FromResult(true);
    }
    }
}