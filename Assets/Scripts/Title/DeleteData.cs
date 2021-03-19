using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DeleteData : MonoBehaviour
{
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        DirectoryInfo di = new DirectoryInfo(Application.persistentDataPath + "/");
        foreach (var fi in di.GetFiles())
        {
            if(fi.Name.EndsWith(".json"))
            {
                File.Delete(Application.persistentDataPath + "/" + fi.Name);
            }
        }
    }
}
