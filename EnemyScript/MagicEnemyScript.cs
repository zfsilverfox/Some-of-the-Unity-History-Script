using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicEnemyScript : MonoBehaviour
{

    public Animator _anim;
    SphereCollider _detectPlayerCollider;
    public GameObject _AttkArea;


    public int Life;


    public bool CanAttack = false;
    public float AttackTimer = 0.0f;
   public float stopAttackTimer = 5.0f;
    public int AttackCountingNumber = 0;
    bool DoAttack = false;
    public bool CanAttackArea = false;
    [SerializeField] bool Dead = false;
public    bool HasPlayerBefore = false;
    public bool GetHurt = false;

    public bool isAlreadyGetHurt;



    public GameObject _DeadEffectInstan;
    public GameObject _HurtEffectInstan;


    // Name : Awake 
    // Method : This Function Mainly is use for Get Component 
    void Awake()
    {
        GetComponentFunction();
    }

    // Name : Start
    // Method : This Function Mainly is use for
    // Set The Basic Data or Get the Component  
    private void Start()
    {
        GetComponentFunction();
        Life = Random.Range(5, 10);
        AttackCountingNumber = Random.Range(0, 8);
        HasPlayerBefore = false;
        GetHurt = false;
    }
    //Name: GetComponentFunction
    // Method : This Method is Mainly is used for
    //Get Component 
    void GetComponentFunction()
    {
        if (_anim == null)
        {
            _anim = GetComponentInChildren<Animator>();
        }
        if (_detectPlayerCollider == null)
        {
            _detectPlayerCollider = GetComponent<SphereCollider>();
        }
    }


    //Name: Update 
    // Method :Update Function which is checked 
    // the Dead Function ||
    // Attack Function   
    void Update()
    {
        DeadOrHurtFunction();
      AttackFunction();
    }




    //Name : OnTriggerEnter
    //Method : Now This Function  mainly
    // is used for Detect Player and Attack
    // Player,
    // if it's not Attack
    // Please Refenrence
    // On Trigger Exit
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("MagicEnemyDetect")&& !Dead)
        {
            Debug.Log("Magic Rider Attack Player");
            CanAttackArea = true;
        }
        if (other.gameObject.CompareTag("PlayerWeapon"))
        {
            if (!GetHurt )
            {
                GetHurt = true;
                StartCoroutine("GetHurtTurnBackToFalse");
            }
        }
    }

    //Name : OnTriggerExit 
    //Method : Now This Function  mainly
    // is used for Detect Player and Not 
    // Going continue Attack
    // Player,
    // if it's Attack
    // Please Refenrence
    // On Trigger Enter 
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            //Magic Enemy Can Stop Attack 
            Debug.Log("Magic Rider Stop Attack Player");
            CanAttackArea = false;
            AttackTimer = 0.0f;
        }
    }



    //Name : AttackFunction 
    // Method : This Function Mainly use for
    // AI Attack Function 
    void AttackFunction()
    {
        if (!Dead)
        {
          if (CanAttackArea)
            {
                    if (CanAttack)
                    {
                            if (AttackCountingNumber >= 0 && AttackCountingNumber <= 3)
                            {
                                _anim.SetTrigger("Attack1");
                                CanAttack = false;
                            }
                            else if (AttackCountingNumber >= 4 && AttackCountingNumber <= 5)
                            {
                                _anim.SetTrigger("Attack2");
                                CanAttack = false;
                            }
                            else if (AttackCountingNumber >= 6 && AttackCountingNumber <= 8)
                            {
                                _anim.SetTrigger("Attack3");
                                CanAttack = false;
                            }
                    }

                    if (!CanAttack)
                    {
                    AttackCountingNumber = Random.Range(0, 8);
                    AttackTimer += Time.deltaTime;
                        if (AttackTimer >= stopAttackTimer)
                        {
                       
                        CanAttack = true;
                            AttackTimer = 0.0f;
                        }
                    }

            }
        }
    }


    // IEnumerator Function : AttackCoroutine Change 
   // Method :This Function Mainly use for 
   // the boolean which is Can Attack Return to
   // true
    IEnumerator AttackCoroutineChange()
    {
        yield return new WaitForSeconds(5f);
        CanAttack = true;
    }

    IEnumerator GetHurtTurnBackToFalse()
    {
        yield return new WaitForSeconds(0.0000001f);
        GetHurt = false;
    }



    // name :DeadOrHurtFunction
    // Method :This Function is
    // Use for Check the MagicEnemy which is dead 
    // or not
    void DeadOrHurtFunction()
    {

        if (!Dead && GetHurt)
        {
            _anim.SetBool("Dead", false); 
            _anim.SetTrigger("GetHurt");

            if (!isAlreadyGetHurt)
            {
                Life-=1;
                Debug.Log("Life"+ Life);
                isAlreadyGetHurt = true;
                StartCoroutine("isAlreadyGetHurtReturntoFalse");
         GameObject HURTEFFECT =       Instantiate(_HurtEffectInstan,new Vector3(transform.position.x,transform.position.y + 0.559f, transform.position.z),transform.rotation);
                Destroy(HURTEFFECT, 0.3f);
            }
           
           
            if(Life <= 0)
            {
                Dead = true;
                Life = 0;
            }
        }
        if (Dead && GetHurt)
        {
            if (!HasPlayerBefore)
            {
                GameObject DEADEFFECT = Instantiate(_DeadEffectInstan, new Vector3(transform.position.x, transform.position.y + 0.559f, transform.position.z), transform.rotation);
                Destroy(DEADEFFECT,0.3f);
                HasPlayerBefore = true;
                _anim.SetBool("Dead", true);
                _anim.applyRootMotion = true;
                _AttkArea.SetActive(false);
                StopCoroutine("GetHurtTurnBackToFalse");
                StopCoroutine("isAlreadyGetHurtReturntoFalse");
            }
        }

       
      
    }

    IEnumerator isAlreadyGetHurtReturntoFalse()
    {
        yield return new WaitForSeconds(0.35f);
        isAlreadyGetHurt = false       ;
    }

    


}
