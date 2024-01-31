using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Save : MonoBehaviour
{
    public static void SavePlayerInfoJSON(string filename, object info)
    {
        var path = Path.Combine(Application.dataPath, filename);
        File.WriteAllText(path, JsonUtility.ToJson(info));
    }

    public static void SavePlayerInfoJSONlist(string filename, List<ItemsSave> info)
    {
        var path = Path.Combine(Application.dataPath, filename);
        string json = JsonUtility.ToJson(info);
        File.WriteAllText(path, json);
    }

    public static T LoadPlayerInfoJSON<T>(string filename)
    {
        var path = Path.Combine(Application.dataPath, filename);
        if (File.Exists(path))
        {
            return JsonUtility.FromJson<T>(File.ReadAllText(path));
        }

        return default(T);
    }

    public static List<T> LoadPlayerInfoJSONList<T>(string filename)
    {
        var path = Path.Combine(Application.dataPath, filename);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(filename);

            List<T> myList = JsonUtility.FromJson<List<T>>(json);

            return myList;
        }

        return default;
    }
}