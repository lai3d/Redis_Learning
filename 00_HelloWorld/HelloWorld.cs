using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StackExchange.Redis;

namespace _00_HelloWorld
{
    class HelloWorld
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:32768");

            Console.WriteLine("Redis ClientName: {0}", redis.ClientName);

            IDatabase db = redis.GetDatabase();

            string value = "abcdefg";
            db.StringSet("mykey", value);

            string valueString = db.StringGet("mykey");
            Console.WriteLine(valueString); // writes: "abcdefg"

            ISubscriber sub = redis.GetSubscriber();

            sub.Subscribe("messages", (channel, message) => {
                Console.WriteLine((string)message);
            });

            Console.WriteLine();
            Console.WriteLine("Press Enter to exit.");
            Console.Read();
        }
    }
}
