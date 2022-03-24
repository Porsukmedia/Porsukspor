using System.Collections;
using UnityEngine;


public class SettingsDataModel : DataModel
{
    public static SettingsDataModel Data;
    public bool Vibration;
    public bool Sound;

    public SettingsDataModel Load()
    {
        if (Data == null)
        {
            Data = this;
            object data = LoadData();

            if (data != null)
            {
                Data = (SettingsDataModel)data;
            }
        }

        return Data;
    }

    public void Save()
    {
        Save(Data);
    }
}
