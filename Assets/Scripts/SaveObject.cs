using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObject : MonoBehaviour
{
    public static SaveObject instance;
    public static GameObject savedObjs;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        savedObjs = this.gameObject;
        DontDestroyOnLoad(this.gameObject);
        coins = 100;
    }

    public int coins { get; set; }
}
