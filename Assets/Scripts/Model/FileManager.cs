using UnityEngine;
using Newtonsoft.Json;
using System.IO;

namespace Model
{
    public class FileManager
    {
        private static readonly string path = Path.Combine(Application.dataPath, "SessionData");
        
        public Session GetSession()
        {
            using StreamReader sr = new(path);
            return JsonConvert.DeserializeObject<Session>(sr.ReadToEnd());
        }

        public void SaveSession(Session session) 
        {
            using StreamWriter sw = new(path);
            sw.Write(JsonConvert.SerializeObject(session));
        }
    } 
}
