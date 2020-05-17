using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMissionArea : MonoBehaviour
{

    public GameObject _UISceneManagement;

    // OnTriggerEnter
    // Method : Use for Active Mission Scene
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GlobalPlayerStatement._INSTANCE.playerCtrl.turnSmoothing = 0f;
            GlobalPlayerStatement._INSTANCE.playerCtrl.speed = 0f;
            GlobalPlayerStatement._INSTANCE.playerCtrl.jumpPower = 0f;
            GlobalPlayerStatement._INSTANCE.playerCtrl._anim.SetInteger("Walking",0);
            _UISceneManagement.SetActive(true);
        }
    }
}
