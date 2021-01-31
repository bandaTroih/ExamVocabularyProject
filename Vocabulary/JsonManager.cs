﻿using System;
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

        private string path = @"..\..\Data\Data.json";
        public void SaveData()
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                js.WriteObject(fs, dictionary);
            }

            //Console.WriteLine("\n> Data saved!");
        }

        public Dictionary LoadData()
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                dictionary = (Dictionary)js.ReadObject(fs);
                return dictionary;
            }
            //Console.WriteLine("\n> Data loaded!");
        }

    }
}