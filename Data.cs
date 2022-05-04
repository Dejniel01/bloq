using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WinFormsZal
{
    [Serializable]
    public class Data
    {
        public int Width { get; }
        public int Height { get;}
        public List<Block> Elements { get; }

        public Data()
        {
            Width = 500;
            Height = 500;
            Elements = null;
        }
        public Data(int width, int height, List<Block> elements)
        {
            Width = width;
            Height = height;
            Elements = elements;
        }
    }
    public static class FileOperator
    {
        public static void Save(FileStream fs, Data data)
        {
            var binser = new BinaryFormatter();
            binser.Serialize(fs, data);
        }
        public static Data Load(FileStream fs)
        {
            var binser = new BinaryFormatter();
            try
            {
                return (Data)binser.Deserialize(fs);
            }
            catch
            {
                return null;
            }
        }
    }
}
