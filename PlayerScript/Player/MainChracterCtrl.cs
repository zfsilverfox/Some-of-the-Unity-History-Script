using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainChracterCtrl : MonoBehaviour
{
    //Basic Component For Player
    Rigidbody _rgbd;
public    Animator _anim;
    AnimatorStateInfo _animStateInfo;
    GlobalPlayerStatement _globalPlayerStatement;


    // String For the Player,Movment State
    private const string IldeAnimString = "WeaponEquipMode Ilde";
    private const string Attack1Anim = "Attack1";
    private const string Attack2Anim = "Attack2";
    private const string Attack3Anim = "Attack3";
    private const string Attack4Anim = "Attack4";
    private const string Attack5Anim = "Attack5";
    private const string Attack6Anim = "Attack6";
    private const string DefendAnim = "DefendMode";
    private const string VerticalMoving = "Vertical";
    private const string HorizontalMoving = "Horizontal";
    private const string tauntAnim = "TauntMode";
    private const string deadAnim = "DeadMode";
    private const string villagetwoAreaString = "VillageTwoArea";


   


    Vector3 movDir;

    // Jumping，Movment, Turning Spd, Use for Player Moving
  public  float horizontal;
    public float vertical;
 public   float turnSmoothing = 3f;
 public   float speed = 3f;
    
  public  float jumpPower = 7f;
    bool Jumping = false;
    bool defendmode = false;
    bool isTauntMode = false;
    [SerializeField]bool isPlayerDead = false;
    bool HaventPlayBeforeDead = false;
public    bool getHit = false;
    bool isAttack = false;
    float hitTimeCounting;
    float haveAtimeNotMovYet = 0.0f;
    public bool isTalkingArea = false;
 public    bool CanAttackArea = true;
    public bool TalkingWithNPC = false;

    public LayerMask GroundMask;
    public float ToGround = 0.5f;


  


    // Enum Function : PlayerState Function
    // Method : Mainly Use For  Player statement 
public    enum PLAYERSTATE
    {
        PlasyerState_Ilde,
        PlayerState_Moving,
        PlayerState_Attack1,
        PlayerState_Attack2,
        PlayerState_Attack3,
        PlayerState_Attack4,
        PlayerState_Attack5,
        PlayerState_Attack6,
        PlayerState_Defend,
        PlayerState_Jumping,
        PlayerState_Taunt,
        PlayerState_Dead,
        PlayerState_GetHit,
    }
public PLAYERSTATE playerstates = PLAYERSTATE.PlasyerState_Ilde;

    // Btn Hit Count ,is Use For Counting The Btn which is Attack Btn How much time Player is pressed
 public   int BtnHitCount;

   
    // Function Awake 
    // Method : is use for Get Component Or maybe After use for static
    private void Awake()
    {
        GetComponentFunction();
        
    }
    // Function : GetComponent Function
    // Method : mainly Use For GetComponentFunction
    void GetComponentFunction()
    {
        if(_rgbd == null)
        _rgbd = GetComponent<Rigidbody>();
        if(_anim == null)
        _anim = GetComponentInChildren<Animator>();

        if (_globalPlayerStatement == null)
            _globalPlayerStatement = GetComponent<GlobalPlayerStatement>();




    }
    //Function : Start Function 
    // Method : Mainly use For Setting Crt State
    void Start()
    {
        GetComponentFunction();
        BtnHitCount = 0;
        Jumping = false;
        playerstates = PLAYERSTATE.PlasyerState_Ilde;
        defendmode = false;
        isTauntMode = false;
        isPlayerDead = false;
        getHit = false;
    }
    //Function : Fixed Update Function
    // Method : Use For Fixed Update,
    // Mainly use for Movment,TauntMode,Dead Mode 
void FixedUpdate()
    {
         horizontal = Input.GetAxisRaw(HorizontalMoving);
         vertical = Input.GetAxisRaw(VerticalMoving);
        if (!isAttack)
        {
            Movement(horizontal, vertical);
        }
        IldeTauntMode(horizontal, vertical);
        DeadDetection();
    }

    //Function : Update 
    // Method : Use for Update The Player Jump,Atk,Defend
    void Update()
    {
        Jump();
        DefendMode();
        _animStateInfo = _anim.GetCurrentAnimatorStateInfo(0);
        if (Input.GetKeyDown(KeyCode.Space) && CanAttackArea)
        {
            Attack();
            //Debug.Log(BtnHitCount);
            Jumping = false;
            //Debug.Log("AnimStateInfo NormalizeTime" + _animStateInfo.normalizedTime);
        }
        else if 
            (Input.GetKeyDown(KeyCode.Space) && isTalkingArea)
        {
            TalkingWithNPC = !TalkingWithNPC;
        }
        if (!_animStateInfo.IsName(IldeAnimString) && _animStateInfo.normalizedTime >= 1.1f)
        {
            _anim.SetInteger("Attack", 0);
            BtnHitCount = 0;
            Jumping = false;
            isAttack = false;
            playerstates = PLAYERSTATE.PlasyerState_Ilde;
        }
    }

    // Function : Movment 
    // Method : This Fuction is use for The Object who named is Player Or Tag is Player which uses for Transform position
    void Movement(float h, float v)
    {
        if (!TalkingWithNPC)
        {
            if (!isPlayerDead|| !getHit || !isAttack)
        {
          if ((h != 0 || v != 0) && !isTauntMode && !defendmode)
                {
                    movDir = new Vector3(h, 0, v);
                    playerstates = PLAYERSTATE.PlayerState_Moving;
                    Rotating(h, v);
                    _rgbd.MovePosition(_rgbd.position + speed * movDir * Time.deltaTime);
                    _anim.SetInteger("Walking", 1);
                    Jumping = false;

                }
                        else if (h == 0 || v == 0)
                {
                    _anim.SetInteger("Walking", 0);
                    Jumping = false;
                    playerstates = PLAYERSTATE.PlasyerState_Ilde;
                }
        }
        }


        if (TalkingWithNPC)
        {
            vertical = 0f;
            horizontal = 0f;
            _anim.SetInteger("Walking", 0);
        }
        
      
    }

    //Function : Rotating 
    // Method : is Use For when Player Moving , The Object which is Player's Object will change Their Rotation
    void Rotating(float horizontal, float vertival)
    {
        Vector3 targetDirection = new Vector3(horizontal, 0f, vertival);
        // Create a rotation based on this new vector assuming that up is the global y axis.
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

        // Create a rotation that is an increment closer to the target rotation from the player's rotation.
        Quaternion newRotation = Quaternion.Lerp(_rgbd.rotation, targetRotation, turnSmoothing * Time.deltaTime);

        // Change the players rotation to this new rotation.
        _rgbd.MoveRotation(newRotation);
    }

    //Function : Attack
    // Method : Using for the Attack Combat Method
    void Attack()
    {
      
            if (!isPlayerDead|| !getHit)
        {
   if (_animStateInfo.IsName(IldeAnimString) && (_animStateInfo.normalizedTime >= 0.4f) && BtnHitCount == 0)
        {
            _anim.SetInteger("Attack",1);
            BtnHitCount = 1;
            playerstates = PLAYERSTATE.PlayerState_Attack1;
                isAttack = true;
            // Debug.Break();
        }
        else if (_animStateInfo.IsName(Attack1Anim) && (_animStateInfo.normalizedTime >= 0.8f) && BtnHitCount == 1)
        {
            _anim.SetInteger("Attack",2);
            BtnHitCount = 2;
            playerstates = PLAYERSTATE.PlayerState_Attack2;
                isAttack = true;
            }
            else if (_animStateInfo.IsName(Attack2Anim) && (_animStateInfo.normalizedTime >= 0.8f) && BtnHitCount == 2)
        {
            _anim.SetInteger("Attack", 3);
            BtnHitCount = 3;
            playerstates = PLAYERSTATE.PlayerState_Attack3;
                isAttack = true;
            }
            else if (_animStateInfo.IsName(Attack3Anim) && (_animStateInfo.normalizedTime >= 0.8f) && BtnHitCount == 3)
        {
            _anim.SetInteger("Attack", 4);
            BtnHitCount = 4;
            playerstates = PLAYERSTATE.PlayerState_Attack4;
                isAttack = true;
            }
            else if (_animStateInfo.IsName(Attack4Anim) && (_animStateInfo.normalizedTime >= 0.8f) && BtnHitCount == 4)
        {
            _anim.SetInteger("Attack", 5);
            BtnHitCount = 5;
            playerstates = PLAYERSTATE.PlayerState_Attack5;
                isAttack = true;
            }
            else if (_animStateInfo.IsName(Attack5Anim) && (_animStateInfo.normalizedTime >= 0.8f) && BtnHitCount == 5)
        {
            _anim.SetInteger("Attack", 6);
            BtnHitCount = 6;
            playerstates = PLAYERSTATE.PlayerState_Attack6;
                isAttack = true;
            }

        }
       

      

     

    }
    // Function :Jumping 
    // Method : Using For Player Jump 
    void Jump()
    {
        if (!isPlayerDead|| !getHit)
        {
          if (Input.GetKeyDown(KeyCode.J) && isGrounded() && _animStateInfo.IsName(IldeAnimString))
                {
                    _rgbd.velocity = new Vector3(0, jumpPower * Time.deltaTime, 0f);
                    Jumping = true;
                    playerstates = PLAYERSTATE.PlayerState_Jumping;
                    _anim.SetTrigger("Jump");

                }
        }
    }
    // Bool isGroundedFunction
    // Method : Is use For Checked Ground Function
    bool isGrounded()
    {
        bool s = false;

        Vector3 origin = transform.position + (Vector3.up * ToGround);
        Vector3 downPos = -Vector3.up;

        float dis = ToGround + 0.3f;

        RaycastHit hit;

        Debug.DrawRay(origin, downPos, Color.white);
        if (Physics.Raycast(origin, downPos, out hit, dis, GroundMask))
        {



            s = true;
        }


        return s;

    }
    // Defend Mode Function : In Defend Mode 
    //Method :  This Method is Use For Defend Mode 
    void DefendMode()
    {
        if (!isPlayerDead)
        {
if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            defendmode = true;


        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            defendmode = false;

        }

        _anim.SetBool(DefendAnim, defendmode);






        }


        
    }
    // Ilde Taunt Mode 
    // if Player isn't move in Limit Area 
    // He will do some Animation
    void IldeTauntMode(float h, float v)
    {
        if (!isPlayerDead|| !getHit)
        {
                if ((h == 0 && v == 0)&& _animStateInfo.IsName(IldeAnimString))
            {
                haveAtimeNotMovYet += Time.deltaTime;

                if (haveAtimeNotMovYet >= 50.0f)
                {
                  
                    _anim.SetTrigger(tauntAnim);
                    isTauntMode = true;
                    haveAtimeNotMovYet = 0.0f;
                }
               if (haveAtimeNotMovYet < 50.0f)
                {
                    isTauntMode = false;
                }




            }




        }


       
    }
  //Function : Hit Detection
  // Method : Mainly Use For HitDetection 
 public   void HitDetection()
    {
        float timeToCount = 0.0f;

        getHit = true;
        timeToCount += Time.deltaTime;
        if(timeToCount >=2)
        {
            getHit = false;

        }


    }
    // Function : Dead Detection
    // Method : is use for Checking Player Status which is Dead Status
    void DeadDetection()
    {

        if (isPlayerDead == true)
        {
           

            //Meaning Going to Game Over Mode 
            if (!HaventPlayBeforeDead)
            {
                _anim.SetTrigger(deadAnim);
                HaventPlayBeforeDead = true;
            }

          
            playerstates = PLAYERSTATE.PlayerState_Dead;
            

        }
    }
    // Function : OnTriggerEnter
    // Method : Present is now use for Enter Second Area Scan 
    // Added the area which is talkingArea And 
   void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("VillageTwoArea"))
        {
            
         
            SceneManager.LoadScene("Village2");
            SceneManager.sceneLoaded += OnSceneLoad;
            //Camera.main.GetComponent<Transform>().position = new Vector3(-3.288992f, -16.3f, -18.13354f);
            //this.gameObject.transform.position = new Vector3(1.710069f, -25.12987f, -7.970422f);
        }

        if (other.gameObject.CompareTag("VillageFirstArea"))
        {
            
            SceneManager.LoadScene("Village1");
            SceneManager.sceneLoaded += OnSceneLoad;
            //Camera.main.GetComponent<Transform>().position = new Vector3(24.85835f, -16.3f, -16.3f);
            //this.gameObject.transform.position = new Vector3(32.87993f, -25.12987f, -1.44f);
        }


        if (other.gameObject.CompareTag("NPCShopKeeper"))
        {
            isTalkingArea = true;
            CanAttackArea = false;
        }
    }


    // Function : OnTriggerExit
    // Method : Present now is use for UnCheck Talking Area
     void OnTriggerExit(Collider other)
    {
      

        if (other.gameObject.CompareTag("NPCShopKeeper"))
        {
            isTalkingArea = false;
            CanAttackArea = true;
        }


    }


    // Function : IsDeadOrNot
    // Method : This Function mainly is use for 
    // Check the Global PlayerStatement which is 
    // it's Life are zero or not 
    // if it's zero 
    // MainChracterCtrl which is this script 
    // can't mov anymore 
    void IsDeadOrNot()
    {
        
    }


    // OnSceneLoad
    // Method : This Function Mainly is used for 
    // avoid When Loading Scene 
    // Player position was been checked up to 
    // been changed 
    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Village1")
        {
            Camera.main.GetComponent<Transform>().position = new Vector3(24.85835f, -16.3f, -16.3f);
            this.gameObject.transform.position = new Vector3(32.87993f, -25.12987f, -1.44f);
        }
        else if (scene.name == "Village2")
        {
            Camera.main.GetComponent<Transform>().position = new Vector3(-3.288992f, -16.3f, -18.13354f);
            this.gameObject.transform.position = new Vector3(1.710069f, -25.12987f, -7.970422f);
        }
    }

 
}


