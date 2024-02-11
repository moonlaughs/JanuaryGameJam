using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnemyAttacker : MonoBehaviour
{
    float distance;
    Transform target;  
    //Rango de distancias  
    float lookAtDistance = 15f;
    float attackRange = 10f;
    float moveSpeed = 5f;
 
    float jumpRangeMin = 2f;
    float jumpRangeMax = 5f;
    float jumpYSpeed = 20f;
    float jumpZSpeed = 5f;
   
    float damping = 6f;
bool grounded  = false; //setea el grounded como false de entrada
float maxSlope  = 60f; 

public bool enableJump = true;
    public KeyCode jumpKey = KeyCode.Space;
    public float jumpPower = 5f;

    // Internal Variables
    private bool isGrounded = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            // Calculate how fast we should be moving
            Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Debug.Log("jump");
        if(distance < jumpRangeMin)
        {
            jump ();
        }
    }

    void jump ()
{
    if (grounded)
    {
    GetComponent<Rigidbody>().AddForce(0f, jumpPower, 0f, ForceMode.Impulse);
    }
 
}

 // Sets isGrounded based on a raycast sent straigth down from the player object
    private void CheckGround()
    {
        Vector3 origin = new Vector3(transform.position.x, transform.position.y - (transform.localScale.y * .5f), transform.position.z);
        Vector3 direction = transform.TransformDirection(Vector3.down);
        float distance = 0.75f;

        if (Physics.Raycast(origin, direction, out RaycastHit hit, distance))
        {
            Debug.DrawRay(origin, direction * distance, Color.red);
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
