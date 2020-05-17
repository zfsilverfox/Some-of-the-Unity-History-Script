using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBallInstantiateArea : MonoBehaviour
{
    public static MagicBallInstantiateArea _INSTANCE;




    public GameObject _InstanceMagicBall;
    public bool isAttack = false;


    public float timeDefault = 0.0f;
    [SerializeField]  float timrTotrue=0.25f;
    // Name : Awake 
    // Method : This function is mainly
    // use for defend null Problem
    void Awake()
    {
        AvoidNullFunction();
        isAttack = false;
    }

  void Start()
    {
        AvoidNullFunction();
    }

    // name :Avoid Null FUnction
    // Method : This function is use for avoid
    // the function which is avoid the null problem
    void AvoidNullFunction()
    {
        if (_INSTANCE == null) _INSTANCE = this;

    }

    // Name :Update
    // Method : this function is going to update 
    // 
     void Update()
    {
        if (!isAttack)
        {
            LetsBallApeared();
            isAttack = true;
        }
        if (isAttack)
        {
            timeDefault += Time.deltaTime;
            if(timeDefault >= timrTotrue)
            {
                isAttack = false;
                timeDefault = 0.0f;
            }
        }
    }



    //name :LetsBallApeared
    // Method : This Function mainly is used to 
    // make Ball Appeared 
    void LetsBallApeared()
    {
            Instantiate(_InstanceMagicBall, transform.position, transform.rotation);
    }


   

}
