using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMagicBallScript : MonoBehaviour
{

    [SerializeField] float forcePower = 5f;
    [SerializeField] float LifeTimeCount = 1.45f;
    public GameObject _PlayerHitArea;
    //Name: Start Function 
    // Method : This Function is special than another 
    // it's main item will be deleted after between five to six second
     void Start()
    {
        if (_PlayerHitArea == null)
            _PlayerHitArea = GameObject.FindGameObjectWithTag("FrontHit");
        else if (_PlayerHitArea == null)
            _PlayerHitArea = GameObject.FindGameObjectWithTag("BackHit");
        //else if (_PlayerHitArea == null)
        //    _PlayerHitArea = GameObject.FindGameObjectWithTag("RightHit");
        //else if(_PlayerHitArea == null)
        //    _PlayerHitArea = GameObject.FindGameObjectWithTag("LeftHit");

        if(_PlayerHitArea != null)
        {
            transform.LookAt(_PlayerHitArea.transform);
        }
        else
        {
            Destroy(this.gameObject);
        }
        

        Destroy(this.gameObject, LifeTimeCount);

    }

    // Function : Update 
    // Method : Basic use for 
    // Update the ball moving function
         void Update()
    {
        if(_PlayerHitArea != null)
        transform.position += transform.forward * forcePower;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FrontHit")
        {
            Destroy(this.gameObject);

          
        }

        else if (other.gameObject.CompareTag("BackHit"))
        {
            Destroy(this.gameObject);

            Debug.Log("Player Lives has been minus one");
        }
    }


}
