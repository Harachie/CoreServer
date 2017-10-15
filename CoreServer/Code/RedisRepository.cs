
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace CoreServer.Code
{
    public class RedisRepository
    {
        public ConnectionMultiplexer Redis;

        public RedisRepository()
        {
            this.Redis = ConnectionMultiplexer.Connect("redis-server");
        }
    }
}
