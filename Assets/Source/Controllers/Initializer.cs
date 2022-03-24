using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : ObjectModel
{
    [SerializeField] List<ObjectModel> objects;
    public bool InitializeOnAwake;
    bool isInitialized;

    private void Awake()
    {
        if (InitializeOnAwake)
        {
            Initialize();
        }
    }


    public override void Initialize()
    {
        if (isInitialized == false)
        {
            isInitialized = true;
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].Initialize();
            }

            base.Initialize();
        }
    }

}