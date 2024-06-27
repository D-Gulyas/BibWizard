using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    public static Wizard player;

    public GameObject fireballPrefab;
    float castTimer = 0f;
    float movementSpeed = 2.0f;
    Vector3 lastMovement = Vector3.zero;
    private Animator animator;

    public static PlayerStats stats;

    public int hp;
    public float mana;
    

    // Start is called before the first frame update
    void Start()
    {
        stats = new PlayerStats();
        hp = stats.maxHP;
        mana = stats.maxMana;
        

        player = this;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        if (false)
        {
            return;
        }


        //
        // Movement 
        //
        Vector3 movement = Vector3.zero;

        if (Input.GetKey("w"))
        {
            movement += Vector3.up;
        }
        if (Input.GetKey("s"))
        {
            movement += Vector3.down;
        }
        if (Input.GetKey("a"))
        {
            movement += Vector3.left;
        }
        if (Input.GetKey("d"))
        {
            movement += Vector3.right;
        }

        if (movement.x > 0 || movement.y > 0 || movement.x < 0 || movement.y < 0)
        {
            lastMovement = movement;
        }

        float sprintSpeedFactor = 1.0f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprintSpeedFactor = 2.0f;
        }

        transform.position += movement.normalized * Time.deltaTime * stats.movementSpeed * sprintSpeedFactor;

        //
        // Animation
        // 
        if (movement.magnitude > 0)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }

        // Flip Character
        if (movement.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (movement.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }





        //
        // Casting
        //
        castTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && castTimer <= 0 && mana > 0)
        {
            animator.SetBool("Attack", true);
            stats.mana -= 10;
            GameObject obj = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
            obj.GetComponent<Fireball>().direction = lastMovement;
            castTimer = stats.castingTime;  
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("Attack", false);
        }

        if (stats.mana < stats.maxMana) 
        {
            stats.mana += stats.manaRegeneration;
        } else
        {
            stats.mana = stats.maxMana;
        }


        // Mana Handling
        mana = mana + Time.deltaTime * stats.manaRegeneration;

    }



    public static PlayerStats GetStats()
    {
        return stats;
    }


}
