using Android.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PlagueAdventure.Source.Engine
{
    public class SaveManager
    {
        public int Vol;
  
        private static string _filename = Environment.GetFolderPath(Environment.SpecialFolder.Personal)+"/audio.txt";
        public SaveManager() 
            
        {
            Globals.vol = 20;
            Vol = Globals.vol;
        }
    public SaveManager(int vol) 
        {
            Globals.vol = vol;
            Vol = vol;
        }
    public static SaveManager load()
        {
            if (!File.Exists(_filename)){
                Debug.WriteLine("killmne");
                return new SaveManager();
            }
            using (var reader = new StreamReader(new FileStream(_filename, FileMode.Open)))
            {
                var serializer = new XmlSerializer(typeof (int));
                var vol = (int)serializer.Deserialize(reader);
                Debug.WriteLine(_filename+"  "+vol);
                return new SaveManager(vol);
            }
        }
        public static void Save(SaveManager saveManager)
        {
            using (var writer = new StreamWriter(new FileStream(_filename, FileMode.Create)))
            {
                var serializer = new XmlSerializer(typeof (int));
                serializer.Serialize(writer, Globals.vol);
                Debug.WriteLine(_filename + "  " + Globals.vol);
            }
        }
    }
    

}
