using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static event Action<string> OnUpdateCoin = delegate { };
    public static GameData instance;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            UpdateCoin(UnityEngine.Random.Range(0, 100).ToString());
        }
    }

    public void UpdateCoin(string coin)
    {
        OnUpdateCoin(coin);
    }
}
