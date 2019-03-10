using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Figure;

namespace Game
{
    public static class XmlSerz
    {
        private static readonly XmlSerializer Xs = new XmlSerializer(typeof(List<Cube>));

        public static void WriteToFile(string fileName, List<Cube> dataCube)
        {
            using (var fileStream = File.Create(fileName))
            {
                Xs.Serialize(fileStream, dataCube);
            }
        }

        public static List<Cube> LoadFromFileCube(string fileName)
        {
            using (var fileStream = File.OpenRead(fileName))
            {
                return (List<Cube>) Xs.Deserialize(fileStream);
            }
        }

        public static List<Cube> LoadFromStreamCube(Stream file)
        {
            return (List<Cube>) Xs.Deserialize(file);
        }
    }
}
