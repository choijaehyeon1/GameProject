using System.Collections;
using System.Security.Permissions;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    public PlayerParams playerParams;
    public Collider weaponCollider;

    public float speed = 5f;
    public bool isRolling = false;
    public bool isDead = false;
    public float deadTime = 3;
    public float rollingCooldown = 1f;
    public float parryingCooldown;


    Vector2 inputVector;

    float nextRollingTime = 0.0f;

    private void Awake()
    {
        playerParams = GetComponent<PlayerParams>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        deadTime = 0f;
        parryingCooldown = 3f;
    }

    private void Update()
    {
        if(!isDead)
        {
            inputVector.x = Input.GetAxis("Horizontal");
            inputVector.y = Input.GetAxis("Vertical");

            if (Input.GetMouseButtonDown(0) && !isRolling)
            {
                animator.SetTrigger("Attack");
            }

            if (Input.GetMouseButtonDown(1) && !isRolling)
            {
                if (parryingCooldown > 3f)
                {
                    parryingCooldown = 0f;
                    animator.SetTrigger("Parrying");
                }
            }

            if(Input.GetKeyDown(KeyCode.Alpha1) && !isRolling)
            {
                animator.SetTrigger("skill1");
            }

            if (Input.GetKeyDown(KeyCode.LeftControl) && !isRolling && Time.time >= nextRollingTime)
            {
                StartCoroutine(Roll());
            }
        }
        

        //플레이어 죽음
        if (playerParams.stat.Hp <= 0)
        {
            if (deadTime >= 6f)
            {
                SceneManager.LoadScene("GameOver");
            }
            deadTime += Time.deltaTime;
            isDead = true;
            animator.SetBool("Death", true);
            
        }
        else
        {
            isDead = false;
        }
    }
    IEnumerator Roll()
    {

        animator.SetTrigger("Roll");

        animator.SetFloat("RollX", inputVector.x);
        animator.SetFloat("RollY", inputVector.y);

        Vector2 normalizedInput = inputVector.normalized;        
        Vector3 rollingVec = inputVector.sqrMagnitude < 0.81f ? Vector3.forward : new Vector3(normalizedInput.x, 0, normalizedInput.y);

        isRolling = true;

        while (isRolling)
        {
            transform.Translate(rollingVec * Time.fixedDeltaTime * speed * 3.0f);
            yield return new WaitForFixedUpdate();
        }
    }


    public void EndRoll()
    {
        animator.SetFloat("RollX", 0);
        animator.SetFloat("RollY", 0);
        isRolling = false;
        nextRollingTime = Time.time + rollingCooldown;
    }

    private void FixedUpdate()
    {
        parryingCooldown += Time.deltaTime;


        if (isRolling)
        {
            return;
        }


        Vector3 direction = new Vector3(inputVector.x, 0f, inputVector.y);
        float runSpeed = Mathf.Clamp01(direction.sqrMagnitude);

        animator.SetFloat("Speed", runSpeed);

        animator.SetFloat("X", inputVector.x);
        animator.SetFloat("Y", inputVector.y);

        transform.Translate(direction.normalized * Time.fixedDeltaTime * speed);
    }

    public void Interaction()
    {
    }

    public void ActivateWeapon()
    {
        weaponCollider.enabled = true;
    }

    public void DeactivateWeapon()
    {
        weaponCollider.enabled = false;
    }
}