using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulationV2
{
    class World
    {
        private static int height = 25;
        private static int width = 25;
        private static Tile[,] map;
        private static Tile[] templates = new Tile[50];
        private static Tile defaultTemplate = new Tile();
        public World()
        {
            map = new Tile[height, width];
        }
        public World(int worldHeight,int worldWidth)
        {
            height = worldHeight;
            width = worldWidth;
            map = new Tile[height, width];
        }
        public static void AddTemplate(int id,string icon)
        {
            templates[id].SetIcon(icon);
        }
        public static void AddTemplate(int id, string icon,int speed)
        {
            templates[id].SetIcon(icon);
            templates[id].SetSpeed(speed);
        }
        public static void AddTemplate(int id, string icon, int speed,string name)
        {
            templates[id].SetName(name);
            templates[id].SetSpeed(speed);
            templates[id].SetIcon(icon);
        }
        public static void AddTemplate(int id, string icon, int speed,string name,int[] vector)
        {
            templates[id].SetName(name);
            templates[id].SetVector(vector);
            templates[id].SetSpeed(speed);
            templates[id].SetIcon(icon);
        }
        public void SetMapToDefault()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    map[i, j] = new Tile() ;
                }
            }
        }
        public  void SetTemplatesToDefault()
        {
            for (int i = 0; i < 50; i++)
            {
                templates[i] = new Tile();
            }
        }
        public void SetTile(int[] coords,int id)
        {
            map[coords[0], coords[1]] = templates[ id];
        }
        public void MoveTile(int[] coords,int[] vector)
        {
            if (map[coords[0] + vector[0], coords[1] + vector[1]].GetName() == defaultTemplate.GetName())
            {
                map[coords[0] + vector[0], coords[1] + vector[1]] = map[coords[0], coords[1]];
                ResetTile(coords);
            }
        }
        public void ResetTile(int[] coords)
        {
            map[coords[0], coords[1]] = defaultTemplate;
        }
        public static int[] ConvertWasdToVector8(string input)
        {   
            int[] vector = new int[2];
            if (input == "as" || input == "sa") { vector[0] = 1; vector[1] = -1; }
            else if (input == "s") { vector[0] = 1; vector[1] = 0; }
            else if (input == "sd" || input == "ds") { vector[0] = 1; vector[1] = 1; }

            else if (input == "a") { vector[0] = 0; vector[1] = -1; }
            else if (input == "") { vector[0] = 0; vector[1] = 0; }
            else if (input == "d") { vector[0] = 0; vector[1] = 1; }

            else if (input == "aw" || input == "wa") { vector[0] = -1; vector[1] = -1; }
            else if (input == "w") { vector[0] = -1; vector[1] = 0; }
            else if (input == "wd" || input == "dw") { vector[0] = -1; vector[1] = 1; }
            return vector;
        }
        public static void BuildBox(int[] coords1, int[] coords2,int id)
        {
            for(int i = coords1[0];i <= coords2[0];i++)
            {
                map[i, coords2[1]] = templates[id];
                map[i, coords1[1]] = templates[id];
            }
            for (int i = coords1[1]; i <= coords2[1]; i++)
            {
                map[coords1[0], i] = templates[id];
                map[coords2[0], i] = templates[id];
            }
        }
        public static void PlaceTile(int templateId, int[] coords)
        {
            map[coords[0], coords[1]].SetHasNotMoved(templates[templateId].GetHasNotMoved());
            map[coords[0], coords[1]].SetIcon(templates[templateId].GetIcon());
            map[coords[0], coords[1]].SetName(templates[templateId].GetName());
            map[coords[0], coords[1]].SetSpeed(templates[templateId].GetSpeed());
        }
        public static void PlaceTile(int templateId, int[] coords, int[] vector)
        {
            map[coords[0], coords[1]].SetHasNotMoved(templates[templateId].GetHasNotMoved());
            map[coords[0], coords[1]].SetIcon(templates[templateId].GetIcon());
            map[coords[0], coords[1]].SetName(templates[templateId].GetName());
            map[coords[0], coords[1]].SetSpeed(templates[templateId].GetSpeed());
            map[coords[0], coords[1]].SetVector(vector);
        }
        public int[] FindTile(int templateId)
        {
            int[] returnCoords = new int[2];
            for(int i = 0;i < height;i++)
            {
                for(int j = 0;j < width;j++)
                {
                    if(map[i,j].GetName() == templates[templateId].GetName()) 
                    {
                        returnCoords = new int[2] { i, j };
                    }
                }
            }
            return returnCoords;
        }
        public void ChangeTileVector(int[] vector,int[] tileCoords)
        {
            map[tileCoords[0], tileCoords[1]].SetVector(vector);
        }
        public void PrintMap()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(map[i, j].GetIcon());
                }
                Console.WriteLine();
            }
        }
        public void UpdateMap()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (map[i, j].GetHasNotMoved())
                    {
                        int tileSpeed = map[i, j].GetSpeed();
                        int[] vector = map[i, j].GetVector();
                        int[] coords = new int[2] { i, j };
                        int h = 0;
                        while (tileSpeed > h)
                        {
                            MoveTile(coords, vector);
                            coords[0] += vector[0];
                            coords[1] += vector[1];
                            h++;
                        }
                        map[coords[0], coords[1]].SetHasNotMoved(false);
                    }
                }
            }
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    map[i, j].SetHasNotMoved(true);
                }
            }
        }
    }
}
