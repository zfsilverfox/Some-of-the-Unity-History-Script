using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageOneMainCamera : MonoBehaviour
{
    // this object is used to Follow the Player
    public GameObject _followPlayer;

    public float moveSpeed = 3f;
    public float offset= 5.21f;
    public float offsetVertical = 0.0f;


   MainChracterCtrl playerCtrl;

    private void Awake()
    {
        GetComponentFunction();
    }

    void Start()
    {
        GetComponentFunction();
    }

    //Name : GetComponentFunction 
    // Method : Mainly use for GetComponentFunction
    void GetComponentFunction()
    {
        if(playerCtrl == null)
        playerCtrl = _followPlayer.GetComponent<MainChracterCtrl>();
    }

    //Name: Fixed Update Function 
    // Method : This GameObject is used to follow Player
   void FixedUpdate()
    {
        //  float Xlimit = Mathf.Clamp(transform.position.x,-8.4f,21.2f);
        //float FollowPlayerX = Mathf.Clamp(transform.position.x, -8.4f, 21.2f);
        Vector3 newPosition = new Vector3(_followPlayer.transform.position.x+ offset, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, moveSpeed * Time.deltaTime);
Vector3 newPosVertiOne = new Vector3(transform.position.x , transform.position.y, _followPlayer.transform.position.z+offsetVertical);
            transform.position = Vector3.Lerp(transform.position, newPosVertiOne, moveSpeed * Time.deltaTime);

       

    }
}
