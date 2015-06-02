using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulationV2
{
    class Program
    {
        static void Main(string[] args)
        {
            World home = new World(15, 25);
            home.SetTemplatesToDefault();
            home.SetMapToDefault();
            int playerId = 1;
            World.AddTemplate(playerId, "X", 1,"player");
            World.AddTemplate(2, "#", 0,"wall");
            int[] coords1 = new int[2];
            int[] coords2 = new int[2] { 14, 24 };
            int[] defaultPlayerCoords = new int[2] { 4, 4 };
            World.BuildBox(coords1, coords2,2);
            World.PlaceTile(playerId, defaultPlayerCoords);
            bool running = true;
            while (running)
            {
                home.PrintMap();
                string userinput = Convert.ToString(Console.ReadLine());
                if(userinput == "q") { running = false; }
                else
                {
                    int[] playerCoords = home.FindTile(playerId);
                    int[] playerVector = World.ConvertWasdToVector8(userinput);
                    home.ChangeTileVector(playerVector,playerCoords);
                }
                home.UpdateMap();
                Console.Clear();
            }
        }
    }
}
