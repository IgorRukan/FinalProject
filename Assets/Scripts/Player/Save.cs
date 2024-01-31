using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Save : MonoBehaviour
{
    public static void SavePlayerInfoJSON(string filename, object info)
    {
        var path = Path.Combine(Application.dataPath, filename);
        File.WriteAllText(path,JsonUtility.ToJson(info));
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
}
