using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicEnemyAttackAnimationEventScript : MonoBehaviour
{
    public GameObject _MagicAttackTurntotrue;



    //Function : AttackOneFunctionOn
    // Method : This Function is Open the GameObjectFunction
    void AttackOneFunctionOn()
    {
      
            _MagicAttackTurntotrue.SetActive(true);
        

    }

    //Function : AttackOneFunctionOff
    // Method : This Function is Closs the GameObjectFunction
    void AttackOneFunctionOff()
    {
        _MagicAttackTurntotrue.SetActive(false);
        
    }
    //Function : AttackTwoFunctionOn
    // Method : This Function is same as AttackOneFunctionOn
    void AttackTwoFunctionOn()
    {
        _MagicAttackTurntotrue.SetActive(true);
    }
    //Function : AttackTwoFunctionOff
    // Method : This Function is Closs the GameObjectFunction
    void AttackTwoFunctionOff()
    {
        _MagicAttackTurntotrue.SetActive(false);
    }
    //Function :AttackThreeFunctionOn
    // Method : This Function is same as AttackOneFunctionOn
    void AttackThreeFunctionOn()
    {
        _MagicAttackTurntotrue.SetActive(true);
    }
    //Function : AttackThreeFunctionOff
    // Method : This Function is Closs the GameObjectFunction
    void AttackThreeFunctionOff()
    {
        _MagicAttackTurntotrue.SetActive(false);
    }
}
