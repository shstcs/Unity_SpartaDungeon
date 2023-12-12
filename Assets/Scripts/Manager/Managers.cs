using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers instance;
    private static bool initialized;
    public static Managers Instance
    {
        get
        {
            if (!initialized)
            {
                initialized = true;
                GameObject go = GameObject.Find("@Managers");
                if (go == null)
                {
                    go = new() { name = @"Managers" };
                    go.AddComponent<Managers>();
                    DontDestroyOnLoad(go);
                    instance = go.GetComponent<Managers>();
                }

            }
            return instance;
        }
    }

    private readonly UIManager _ui = new();
    private readonly ResourceManager _resource = new();
    private readonly ItemManager _itemManager = new();

    public static UIManager UI => Instance._ui;
    public static ResourceManager Resource => Instance._resource;
    public static ItemManager ItemManager => Instance._itemManager;
}
