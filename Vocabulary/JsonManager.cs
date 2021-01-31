using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Json;
namespace Vocabulary
{
    /// <summary>
    /// Json Serializer for Vocabulary.Dictionary
    /// </summary>
    public class JsonManager
    {
        DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Dictionary));
        private Dictionary dictionary = new Dictionary();

        public JsonManager(Dictionary dic)
        {
            dictionary = dic;
        }

        public void SaveData(string path = @"..\..\Data\Data.json")
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                js.WriteObject(fs, dictionary);
            }
        }

        public Dictionary LoadData(string path = @"..\..\Data\Data.json")
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                dictionary = (Dictionary)js.ReadObject(fs);
                return dictionary;
            }
        }

    }
}
