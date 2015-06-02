using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulationV2
{
    class Tile
    {
        int[] vector = new int[2];
        int speed = 0;
        string icon = ".";
        string name = "name";
        bool hasNotMoved = true;
        public Tile()
        {

        }
        public Tile(string tileIcon)
        {
            icon = tileIcon;
        }
        public Tile(string tileIcon,int[] tileVector)
            :this(tileIcon)
        {
            vector = tileVector;
        }
        public Tile(string tileIcon, int[] tileVector,int tileSpeed)
            : this(tileIcon,tileVector)
        {
            speed = tileSpeed;
        }
        public Tile(string tileIcon, int[] tileVector, int tileSpeed,string tileName)
            : this(tileIcon, tileVector,tileSpeed)
        {
            name = tileName;
        }
        public string GetIcon()
        {
            return icon;
        }
        public void SetIcon(string newIcon)
        {
            icon = newIcon;
        }
        public int[] GetVector()
        {
            return vector;
        }
        public void SetVector(int[] newVector)
        {
            vector = newVector;
        }
        public int GetSpeed()
        {
            return speed;
        }
        public void SetSpeed(int newSpeed)
        {
            speed = newSpeed;
        }
        public string GetName()
        {
            return name;
        }
        public void SetName(string newName)
        {
            name = newName;
        }
        public bool GetHasNotMoved()
        {
            return hasNotMoved;
        }
        public void SetHasNotMoved(bool HasNotMoved)
        {
            hasNotMoved = HasNotMoved;
        }
    }
}
