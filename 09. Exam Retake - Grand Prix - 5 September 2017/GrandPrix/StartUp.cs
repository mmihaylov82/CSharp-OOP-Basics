using System;
using System.Collections.Generic;

namespace StartUp
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var raceTower = new RaceTower();
            var engine = new Engine(raceTower);
            engine.Start();
        }
    }
}
