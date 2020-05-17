using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCBasicAIInfo : MonoBehaviour
{
    // NPC Basic Info
    NavMeshAgent _navMeshAgent;
    bool isMoving = false;
    public List<Transform> wayPoint;
   public Transform CrtPos  ;
 public   bool Reverse = true;
    public bool ReachDistance = false;


    public GameObject _Player;
    MainChracterCtrl _mainCharacter;
   [SerializeField] int DesirePos=1;

    public bool TalkingArea = false;
    public   bool isTalking = false;
    public bool MovingMode = false;
    public bool IldeMov =false ; 

    //Name: Awake 
    // This Function mainly is used to GetComponent
   void Awake()
    {
        GetComponentFunction();
    }
    // Name : Start 
    // Method : This Function Mainly is used to Setting Basic Num
    void Start()
    {
        GetComponentFunction();
        DesirePos = Random.Range(0, wayPoint.Count - 1);
        CrtPos.position = wayPoint[DesirePos].position;
        _mainCharacter = _Player.GetComponent<MainChracterCtrl>();
    }

    //Name : GetComponentFunction
    //Method : This function mainly is used to GetComponent Function
    void GetComponentFunction()
    {
        if (_navMeshAgent == null)
            _navMeshAgent = GetComponent<NavMeshAgent>();

     
    }

    //Name :Update Function
    // Method : This Function mainly uses for Checking
    // Moving,Talking and another Function 
     void Update()
    {
        MovingFunction();
        TalkingFunction();
    }

  

    //Name : MovingFunction
    //Method : This Function is using for Moving Function
    void MovingFunction()
    {
        if (!isTalking)
        {
                if (wayPoint.Count > 0 && wayPoint[DesirePos] != null)
                    {
            
                    _navMeshAgent.SetDestination(wayPoint[DesirePos].position);
                    float distance = Vector3.Distance(transform.position, wayPoint[DesirePos].position);
          
                    ReachDistance = false;

                            if (distance < 1.0 && Reverse)
                            {
                            DesirePos++;
                            ReachDistance = true;
               
                             //   _anim.SetBool("Walk", false);
                                if (DesirePos >= wayPoint.Count)
                                {
                                ReachDistance = true;
                                Reverse = false;
                                    //    _anim.SetBool("Walk", false);
                                DesirePos--;
                                 //  StartCoroutine(IldeMode());

                                }
                            }
                            else if (distance < 1.0 && !Reverse)
                            {
                             DesirePos--;
                            ReachDistance = true;
                                    if (DesirePos <= 0)
                                    {
                                        ReachDistance = true;
                                        Reverse = true;
                                        DesirePos = 0;
                                    }
                            }


                }

        }


        
    }

    //Name :Talking Function 
    // Method : Talking Function mainly is use for 
    // When Player is talking to the NPC Area
    // 
    void TalkingFunction()
    {
        if (isTalking)
        {
            _navMeshAgent.speed = 0f;
            Debug.Log("is Talking With Player");

        }
        else if(!isTalking)
        {
            _navMeshAgent.speed = 2f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && this.gameObject.tag == "NPC2")
        {
        
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && this.gameObject.tag == "NPC2")
        {

        }
    }


}
