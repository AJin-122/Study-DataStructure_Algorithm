using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public class MyHashTables
    {
        List<List<string>>[] keyMap;
        int size;

        public MyHashTables()
        {
            this.size = 53;
            this.keyMap = new List<List<string>>[this.size];
        }

        public MyHashTables(int  size)
        {
            this.size = size;
            this.keyMap = new List<List<string>>[this.size];
        }

        public int hash(string key)
        {
            int total = 0;
            int WEIRD_PRIME = 31;
            for(int i = 0; i < Math.Min(key.Length, 100); i++)
            {
                int value = (int)key[i] - 96;
                total = (total * WEIRD_PRIME + value) % this.keyMap.Length;
            }
            return total;
        }

        public int set(string key, string value)
        {
            int index = this.hash(key);
            if (this.keyMap[index] == null)
            {
                this.keyMap[index] = new List<List<string>>();
            }
            this.keyMap[index].Add(new List<string>() { key, value });
            return index;
        }

        public List<string>? get(string key)
        {
            int index = this.hash(key);
            if (this.keyMap[index] != null)
            {
                for(int i = 0; i < this.keyMap[index].Count; i++)
                {
                    if (this.keyMap[index][i][0] == key)
                        return this.keyMap[index][i];
                }
            }

            return null;
        }
    }
}
