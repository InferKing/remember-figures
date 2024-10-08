using UnityEngine;
using Newtonsoft.Json;
using System.IO;

namespace Model
{
    public class FileManager
    {
        private static readonly string _path = Path.Combine(Application.dataPath, "SessionData");
        
        public Session GetSession()
        {
            using StreamReader streamReader = new(_path);
            return JsonConvert.DeserializeObject<Session>(streamReader.ReadToEnd());
        }

        public void SaveSession(Session session) 
        {
            using StreamWriter streamWriter = new(_path);
            streamWriter.Write(JsonConvert.SerializeObject(session));
        }
    } 
}
