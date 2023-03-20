using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deneme : MonoBehaviour
{
    public static event Action<string> OnCoinUpdate = delegate { };

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

        }
    }

    public static void UpdateCoin(string coin)
    {
        OnCoinUpdate(coin);
    }
}
