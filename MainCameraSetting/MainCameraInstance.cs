using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraInstance : MonoBehaviour
{

    public static MainCameraInstance _INSTANCE;
    void Awake()
    {
        InstanceisNullOrNot();
    }

  

    // Function :InstanceisNullOrNot
    // Method : Mainly use For Defend Duplicate Problem
    void InstanceisNullOrNot()
    {
        if (_INSTANCE == null)
        {
            DontDestroyOnLoad(gameObject);
            _INSTANCE = this;
        }
        else if (_INSTANCE != this)
        {
            Destroy(gameObject);
        }


    }
}
