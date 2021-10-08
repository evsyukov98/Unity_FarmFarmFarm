using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace SaveServices
{
    public static class LocalSaveProvider
    {
        private static readonly string _pathJson = Application.streamingAssetsPath + "/SavesJson.json";

        public static SaveData LoadSave()
        {
            SaveData saveData = JsonConvert.DeserializeObject<SaveData>(
                File.ReadAllText(_pathJson), 
                new JsonSerializerSettings 
            { 
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore,
            });

            return saveData;
        }

        public static void SaveObjectToJson(SaveData saveData)
        {
            JsonSerializer serializer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.Auto, 
                Formatting = Formatting.Indented
            };

            using (StreamWriter sw = new StreamWriter(_pathJson))
            {
                using (JsonWriter writer = new JsonTextWriter(sw)) 
                { 
                    serializer.Serialize(writer, saveData, typeof(SaveData)); 
                }
            }
        }
        
        public static void RemoveSaves()
        {
            File.Delete(_pathJson);
        }
    }
}
