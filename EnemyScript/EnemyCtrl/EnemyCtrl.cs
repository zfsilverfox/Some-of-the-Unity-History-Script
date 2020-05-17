using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
public    Animator _anim;
    Rigidbody _rgbd;
    CapsuleCollider _EnemyCapsuleCollider;
   


    // Now the Function Setting is use for Test Version ,
    //  Can delete after Made Real Game
    #region AttackFunctionTest
    float CountToAttack=0.0f;


    #endregion


    // Hurt Animation 
    private static string GettingDamageAnimation = "GettingDamage";


    public bool isEnemyDead= false;
    bool HaventPlayBeforeDead = false;


    // Name :Awake Function 
    // Method : Awake Function mainly is used for Get Component 
    void Awake()
    {
        GetComponentFunction();
    }


    // Name: Start Function
    // Method : Start Function mainly is used for Setting Basic Statement
    void Start()
    {
        GetComponentFunction();
    }



    // Function Name:GetComponentFunction
    // Method : This Function is use For Get Component 
    void GetComponentFunction()
    {
        if(_anim == null)
        _anim = GetComponentInChildren<Animator>();
        if(_rgbd == null)
        _rgbd = GetComponent<Rigidbody>();
        if (_EnemyCapsuleCollider == null)
            _EnemyCapsuleCollider = GetComponent<CapsuleCollider>();

      
    }

    // Function : Enemy Hurt 
    // Method : mainly use for Manage EnemyHurt 
    public   void EnemyHurt()
    {
        if (!isEnemyDead)
        {
            _anim.SetTrigger(GettingDamageAnimation);
        Debug.Log("The function which is Enemy Hurt has been Called");
        }
           
    }
    //Function : Update
    // Method : Now this function is use for test Player Get Hurt System
    // After it will Gonna to do a AI basic Sys
   void Update()
    {
    AttackFunction();
        DeadDetection();
    }

    //Name: Attack Function 
    //Method : This Function is using for text 
    void AttackFunction()
    {

        if (!isEnemyDead)
        {
         CountToAttack += Time.deltaTime;

                if (CountToAttack >= 15f)
                {
                    _anim.SetBool("Attack", true);
                }
                 if (CountToAttack >= 19f )
                {
                    _anim.SetBool("Attack", false);
                    CountToAttack = 0;

                }
        }
       
       
    }

    // Function : Dead Detection
    // Method : is use for Checking Enemy which is Dead Status
    void DeadDetection()
    {

        if (isEnemyDead == true)
        {
            GameObject.FindGameObjectWithTag("EnemyHit").GetComponent<BoxCollider>().enabled = false;

            

            if (!HaventPlayBeforeDead)
            {
                _anim.SetTrigger("Dead");
                HaventPlayBeforeDead = true;
            }


           


        }
    }

}
