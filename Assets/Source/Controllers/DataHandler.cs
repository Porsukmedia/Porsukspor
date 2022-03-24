using System.Collections;
using UnityEngine;


public class DataHandler : ControllerBase
{
    public PlayerDataModel Player;
    public SettingsDataModel Setting;

    public override void Initialize()
    {
        base.Initialize();
        Player = new PlayerDataModel().Load();
        Setting = new SettingsDataModel().Load();
    }

    public static void ClearAllData()
    {
        string[] files = System.IO.Directory.GetFiles(Application.persistentDataPath, "*.dat");
        for (int i = 0; i < files.Length; i++)
        {
            System.IO.File.Delete(files[i]);
        }
        PlayerPrefs.DeleteAll();
    }
}
