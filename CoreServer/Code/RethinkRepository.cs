using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RethinkDb.Driver;
using RethinkDb.Driver.Net;
using Newtonsoft.Json.Linq;

namespace CoreServer.Code
{
    public class RethinkRepository
    {

        private RethinkDb.Driver.Net.Connection Connection { get; set; }


        public RethinkRepository()
        {
            this.Connection = RethinkDB.R.Connection().Hostname("rethinkdb-server").Port(28015).Timeout(5).Connect();
        }

        public Task InitializeAsync()
        {
            return CreateDatabaseAsync("Maps");
        }

        public async Task CreateConnectionAsync()
        {

            this.Connection = await RethinkDB.R.Connection().Hostname("rethinkdb-server").Port(28015).Timeout(5).ConnectAsync();
        }

        public async Task CreateDatabaseAsync(string name)
        {
            var exists = await RethinkDB.R.DbList().RunResultAsync<HashSet<string>>(this.Connection, null);

            if (!exists.Contains("Maps"))
            {
                await RethinkDB.R.DbCreate(name).RunAsync(this.Connection, null);
            }
        }

        public async Task<JObject> CreateTableAsync(string name)
        {
            var exists = await RethinkDB.R.TableList().RunResultAsync<HashSet<string>>(this.Connection, null);
            JObject r = null;

            if (!exists.Contains(name))
            {
                r = await RethinkDB.R.TableCreate(name).RunAsync<JObject>(this.Connection, null);
            }

            return r;
        }

    }
}
