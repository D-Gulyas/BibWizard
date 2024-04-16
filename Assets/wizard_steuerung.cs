using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    public GameObject fireballPrefab;
    float castTimer = 0f;
    float movementSpeed = 2.0f;
    Vector3 lastMovement = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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

        transform.position += movement.normalized * Time.deltaTime * movementSpeed * sprintSpeedFactor;

        //
        // Casting
        //

        castTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && castTimer <= 0)
        {
            GameObject obj = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
            obj.GetComponent<Fireball>().direction = lastMovement;
            castTimer = 1;
        }

    }
}
