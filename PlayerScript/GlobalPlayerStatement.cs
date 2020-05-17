using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class GlobalPlayerStatement : MonoBehaviour
{
    public static GlobalPlayerStatement _INSTANCE;

 public   MainChracterCtrl playerCtrl;


    public int Life = 30;
    public int CoinCollecter= 0 ;
    public int Power= 2;
    public int Speed ;
    public int Lvl=1 ;
    public int Exp = 0 ;



    //Function : Awake 
    // Method : Use for Destory GameObject Or Not 
    void Awake()
    {
        InstanceisNullOrNot();
        GetComponentFunction();


    }

    // Function : Start
    // Method : Mainly use for do a setting Basic value 
     void Start()
    {
        InstanceisNullOrNot();
        GetComponentFunction();
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

    //Function :GetComponentFunction 
    // Method : Mainly use for GetComponent
    void GetComponentFunction()
    {
        if (playerCtrl == null)
            playerCtrl = GetComponent<MainChracterCtrl>();
    }


}
