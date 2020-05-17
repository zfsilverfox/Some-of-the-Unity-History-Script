using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitArea : MonoBehaviour
{
    private const string FrontHitString = "FrontHit";
    private const string BackHitString = "BackHit";
    private const string LeftHitString = "LeftHit";
    private const string RightHitString = "RightHit";

    // The Script which is going to use with Get Hurt Animation ;
    MainChracterCtrl _PlayerCtrl;
    EnemyCtrl _EnemyCtrl;



    // Animate Place which is Animation Hit Get
    private const string hitFrontAnim = "HitFront";
    private const string backFrontAnim = "HitBack";
    private const string HitLeftAnim = "HitLeft";
    private const string HitRightAnim = "HitRight";

    bool isGetHurtPlayer = false;



    private static HitArea _instance;
    public static HitArea _INSTANCE
    {
        get
        {
            return _instance;
        }
    }

    public bool isGetHurtEnemy = false;

    public GameObject FrontHitAttention;
    public GameObject BackHitAttention;
    public GameObject LeftHitAttention;
    public GameObject RightHitAttention;

    void Awake()
    {
        GetComponentFunction();
    }

    void Start()
    {
        GetComponentFunction();
        isGetHurtPlayer = false;
        isGetHurtEnemy = false;
    }
    //Function : GetComponent Function
    // Method : mainly use for GetComponentFunction;
    void GetComponentFunction()
    {
        if (_PlayerCtrl == null)
            _PlayerCtrl = GetComponentInParent<MainChracterCtrl>();
        if (_EnemyCtrl == null)
            _EnemyCtrl = GetComponentInParent<EnemyCtrl>();

        if (_instance == null) _instance = this;
    }
    // Function OnTriggerEnter : Now Is Use for get Hurt Animation
    //Method: This is use for getting the Animation of Get Hurt Animation;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyWeapon"))

        {
            if (this.gameObject.tag == FrontHitString && other.gameObject)
            {
               
                BackHitAttention.SetActive(false);
                LeftHitAttention.SetActive(false);
                RightHitAttention.SetActive(false);
                _PlayerCtrl.BtnHitCount = 0;
                StartCoroutine("FrontSetActiveturnBackTotrue");
                if (!isGetHurtPlayer)
                {
                    GlobalPlayerStatement._INSTANCE.Life--;
                    Debug.Log("Player's Life" + GlobalPlayerStatement._INSTANCE.Life);

                    _PlayerCtrl._anim.SetTrigger(hitFrontAnim);
                    _PlayerCtrl.HitDetection();
                    isGetHurtPlayer = true;
                    StartCoroutine("TurnBackToFalse");
                    _PlayerCtrl.playerstates = MainChracterCtrl.PLAYERSTATE.PlayerState_GetHit;
                }
            }
            else if (this.gameObject.tag == BackHitString && other.gameObject)
            {
                _PlayerCtrl.BtnHitCount = 0;
              
                FrontHitAttention.SetActive(false);
                LeftHitAttention.SetActive(false);
                RightHitAttention.SetActive(false);
                StartCoroutine("BackSetActiveturnBackTotrue");
                if (!isGetHurtPlayer)
                {
                    GlobalPlayerStatement._INSTANCE.Life--;
                    Debug.Log("Player's Life"+ GlobalPlayerStatement._INSTANCE.Life);
                    _PlayerCtrl._anim.SetTrigger(backFrontAnim);
                    isGetHurtPlayer = true;
                    _PlayerCtrl.HitDetection();
                    StartCoroutine("TurnBackToFalse");
                    _PlayerCtrl.playerstates = MainChracterCtrl.PLAYERSTATE.PlayerState_GetHit;
                }

            }
            else if (this.gameObject.tag == LeftHitString && other.gameObject)
            {

                _PlayerCtrl.BtnHitCount = 0;
               
                FrontHitAttention.SetActive(false);
                BackHitAttention.SetActive(false);
                RightHitAttention.SetActive(false);
                StartCoroutine("LeftSetActiveturnBackTotrue");
                //    _PlayerCtrl.HitDetection();
                if (!isGetHurtPlayer)
                {
                    GlobalPlayerStatement._INSTANCE.Life--;
                    Debug.Log("Player's Life" + GlobalPlayerStatement._INSTANCE.Life);
                    _PlayerCtrl._anim.SetTrigger(HitLeftAnim);
                    isGetHurtPlayer = true;
                    _PlayerCtrl.HitDetection();
                    StartCoroutine("TurnBackToFalse");
                    _PlayerCtrl.playerstates = MainChracterCtrl.PLAYERSTATE.PlayerState_GetHit;
                }


            }
            else if (this.gameObject.tag == RightHitString && other.gameObject)
            {
                _PlayerCtrl.BtnHitCount = 0;
                
                FrontHitAttention.SetActive(false);
                BackHitAttention.SetActive(false);
                LeftHitAttention.SetActive(false);
                StartCoroutine("RightSetActiveturnBackTotrue");

                if (!isGetHurtPlayer)
                {
                    GlobalPlayerStatement._INSTANCE.Life--;
                    Debug.Log("Player's Life" + GlobalPlayerStatement._INSTANCE.Life);
                    _PlayerCtrl._anim.SetTrigger(HitRightAnim);
                    isGetHurtPlayer = true;
                    _PlayerCtrl.HitDetection();
                    StartCoroutine("TurnBackToFalse");
                    _PlayerCtrl.playerstates = MainChracterCtrl.PLAYERSTATE.PlayerState_GetHit;
                }
            }
        }


        if (other.gameObject.CompareTag("PlayerWeapon"))
        {
            if (this.gameObject.CompareTag("EnemyHit") && other.gameObject)
            {




                Debug.Log("Enemy Get Hit");

                _EnemyCtrl.EnemyHurt();





            }
        }


    }

    //Function: Ienumerator Function 
    //Get Hit Status Turn Back To False
    IEnumerator TurnBackToFalse()
    {
        yield return new WaitForSeconds(0.5f);
        isGetHurtPlayer = false;

    }

    IEnumerator FrontSetActiveturnBackTotrue()
    {
        yield return new WaitForSeconds(0.5f);
        BackHitAttention.SetActive(true);
        LeftHitAttention.SetActive(true);
        RightHitAttention.SetActive(true);
    }


    IEnumerator BackSetActiveturnBackTotrue()
    {
        yield return new WaitForSeconds(0.5f);
        FrontHitAttention.SetActive(true);
        LeftHitAttention.SetActive(true);
        RightHitAttention.SetActive(true);
    }

    IEnumerator LeftSetActiveturnBackTotrue()
    {
        yield return new WaitForSeconds(0.5f);
        FrontHitAttention.SetActive(true);
        BackHitAttention.SetActive(true);
        RightHitAttention.SetActive(true);
    }


    IEnumerator RightSetActiveturnBackTotrue()
    {
        yield return new WaitForSeconds(0.6f);
        FrontHitAttention.SetActive(true);
        BackHitAttention.SetActive(true);
        LeftHitAttention.SetActive(true);
    }
}
