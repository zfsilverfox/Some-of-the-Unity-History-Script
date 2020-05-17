using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordColliderOn : MonoBehaviour
{
    Animator _anim;




    public GameObject _swordColliderOn;

    //Name : Awake Function
    // Method : Awake Function which is  mainly is used to Get Component
    private void Awake()
    {
        GetComponetFunction();
    }
    //Name : Start Function
    // Method : Start Function which is  same as the Awake Function 
    // but it will also use to Setting Basic Statement
    private void Start()
    {
        GetComponetFunction();
    }

    //GetComponentFuction
    //which is used to Get All of the Component which 
    // is used to Get the Component which is null
    void GetComponetFunction()
    {
        if (_anim == null)
            _anim = GetComponent<Animator>();
    }

    //Name : AttackOneColliderOn
    // Method : Is used to set the GameObject which 
    // Active is true 
    void AttackOneColliderOn()
    {
        _swordColliderOn.SetActive(true);
        
  
    }

    //Name : AttackOneColliderOff
    // Method : Is used to set the GameObject which 
    // Active is false
    void AttackOneColliderOff()
    {
        _swordColliderOn.SetActive(false);
        
    }

    //Name : AttackTwoFirstColliderOn
    // Method :which is same with AttackOneColliderOn Function
    void AttackTwoFirstColliderOn()
    {
        _swordColliderOn.SetActive(true);
      
    }

    //Name : AttackTwoFirstColliderOff
    // Method : which is same with AttackOneColliderOff function

    void AttackTwoFirstColliderOff()
    {
        _swordColliderOn.SetActive(false);
      
    }

    //Name : AttackTwoSecondColliderOn
    // Method :which is same with AttackOneColliderOn Function
    void AttackTwoSecondColliderOn()
    {
        _swordColliderOn.SetActive(true);
    
    }
    //Name : AttackTwoSecondColliderOff
    // Method : which is same with AttackOneColliderOff function
    void AttackTwoSecondColliderOff()
    {
        _swordColliderOn.SetActive(false);
    
    }

    //Name : AttackThreeColliderOn
    // Method :which is same with AttackOneColliderOn Function
    void AttackThreeColliderOn()
    {
        _swordColliderOn.SetActive(true);
       
    }
    //Name : AttackThreeColliderOff
    // Method : which is same with AttackOneColliderOff function
    void AttackThreeColliderOff()
    {
        _swordColliderOn.SetActive(false);
   
    }
    //Name : AttackFourFirstColliderOn
    // Method :which is same with AttackOneColliderOn Function
    void AttackFourFirstColliderOn()
    {
        _swordColliderOn.SetActive(true);
      
    }
    //Name : AttackFourFirstColliderOff
    // Method : which is same with AttackOneColliderOff function
    void AttackFourFirstColliderOff()
    {
        _swordColliderOn.SetActive(false);
    
    }
    //Name :AttackFourSecondColliderOn
    // Method :which is same with AttackOneColliderOn Function
    void AttackFourSecondColliderOn()
    {
        _swordColliderOn.SetActive(true);
     
    }

    //Name : AttackFourSecondColliderOff
    // Method : which is same with AttackOneColliderOff function
    void AttackFourSecondColliderOff()
    {
        _swordColliderOn.SetActive(false);
       
    }

    //Name :AttackFiveColliderOn
    // Method :which is same with AttackOneColliderOn Function
    void AttackFiveColliderOn()
    {
        _swordColliderOn.SetActive(true);
       
    }
    //Name :AttackFiveColliderOff
    // Method : which is same with AttackOneColliderOff function
    void AttackFiveColliderOff()
    {
        _swordColliderOn.SetActive(false);

    }

    //Name :AttackSixColliderOn
    // Method :which is same with AttackOneColliderOn Function
    void AttackSixColliderOn()
    {
        _swordColliderOn.SetActive(true);
      
    }
    //Name :AttackSixColliderOff
    // Method : which is same with AttackOneColliderOff function
    void AttackSixColliderOff()
    {
        _swordColliderOn.SetActive(false);
  
    }

}
