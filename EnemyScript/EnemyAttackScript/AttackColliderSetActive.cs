using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackColliderSetActive : MonoBehaviour
{
    Animator _anim;
    public GameObject _swordActive;


    // Name : Awake
    //Method: Mainly is use to GetComponentFunction
     void Awake()
    {
        GetComponentFunction();
    }
    // Name : Start
    //Method: Mainly is use to GetComponentFunction
    // or use it to do a basic Setting
    private void Start()
    {
        GetComponentFunction();
    }
    // Name :GetComponentFunction
    // Method : This is mainly use for GetComponent which is 
    // null
    void GetComponentFunction()
    {
        if(_anim == null)
        _anim = GetComponent<Animator>();

    }
    //Name :AttackColliderOpen
    // Method : Is used to set the GameObject which 
    // Active is true 
    void AttackColliderOpen()
    {
        _swordActive.SetActive(true);
        Debug.Log("Enemy Attack Collider has been open");
    }
    //Name :AttackColliderClose
    // Method : Is used to set the GameObject which 
    // Active is false
    void AttackColliderClose()
    {
        _swordActive.SetActive(false);
        Debug.Log("Enemy Attack Collider has been close");
    }

}
