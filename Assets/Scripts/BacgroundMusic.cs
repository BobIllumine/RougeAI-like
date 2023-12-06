using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacgroundMusic : MonoBehaviour
{
    public static BacgroundMusic instance;
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
