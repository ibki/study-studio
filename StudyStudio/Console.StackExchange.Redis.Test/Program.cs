using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.StackExchange.Redis.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("172.18.85.210");
            IDatabase db = redis.GetDatabase();

            string value = "abcdefg";
            db.StringSet("mykey", value);

            string value2 = db.StringGet("mykey");
            System.Console.WriteLine(value2); // writes: "abcdefg"
        }
    }
}
