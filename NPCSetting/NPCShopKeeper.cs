using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCShopKeeper : MonoBehaviour
{
    public GameObject _ShopKeepPanel;
    public bool isShopKeeper = false;

    private void Start()
    {
        
    }



    private void Update()
    {
        OpenShopPanelKeeper();
    }

   void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")&&this.gameObject.tag == "NPCShopKeeper")
        {

            isShopKeeper = true;

        }
    }


  void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && this.gameObject.tag == "NPCShopKeeper")
        {
            isShopKeeper = false;
        }
    }


    // Name : OpenShopPanelKeeper
    // Method : This Game Object  mainly is use for 
    //SetGameObject which panel is active 
    void OpenShopPanelKeeper()
    {
        if (GlobalPlayerStatement._INSTANCE.playerCtrl.TalkingWithNPC&& isShopKeeper)
        {
            _ShopKeepPanel.SetActive(true);
            GlobalPlayerStatement._INSTANCE.playerCtrl.turnSmoothing = 0f;
            GlobalPlayerStatement._INSTANCE.playerCtrl.speed = 0f;

            GlobalPlayerStatement._INSTANCE.playerCtrl.jumpPower = 0f;
        }
        else if (!GlobalPlayerStatement._INSTANCE.playerCtrl.TalkingWithNPC && isShopKeeper)
        {
            _ShopKeepPanel.SetActive(false);
            GlobalPlayerStatement._INSTANCE.playerCtrl.turnSmoothing = 3f;
            GlobalPlayerStatement._INSTANCE.playerCtrl.speed = 3f;
            GlobalPlayerStatement._INSTANCE.playerCtrl.jumpPower = 7f;
        }

    }

}
