using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private Rigidbody rb;
    private Transform player;

    public bool enableJump = true;
    public float jumpPower = 1f;
    public float minDistance = 4f;

    // Internal Variables
    private bool isGrounded = false;

     private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(rb.transform.position, player.position);
        if(enableJump && isGrounded && dist < minDistance)
        {
            // Debug.Log("hmm");
            Jump();
        }

        CheckGround();
    }

    private void CheckGround()
    {
        Vector3 origin = new Vector3(transform.position.x, transform.position.y - (transform.localScale.y * .5f), transform.position.z);
        Vector3 direction = transform.TransformDirection(Vector3.down);
        float distance = .75f;

        if (Physics.Raycast(origin, direction, out RaycastHit hit, distance))
        {
            Debug.DrawRay(origin, direction * distance, Color.red);
            // Debug.Log("ïsGrounded");
            // rb.position.x = 
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void Jump()
    {
        // Adds force to the player rigidbody to jump
        if (isGrounded)
        {
        // Debug.Log("here");
        float dist = Vector3.Distance(rb.transform.position, player.position);
        // rb.AddForce(0,5,0);
            // rb.AddForce(dist, 0f, 0f, ForceMode.Impulse);
            rb.AddForce(0, 5, 0);
            // rb.AddForce(0f, jumpPower, 0f, ForceMode.Impulse);
            isGrounded = false;
        }

        // When crouched and using toggle system, will uncrouch for a jump
        // if(isCrouched && !holdToCrouch)
        // {
        //     Crouch();
        // }
    }

    void OnTriggerEnter(Collider other)
{
        // Debug.Log("going down and giving demage");
    if (other.gameObject.CompareTag("Player"))
    {
        Debug.Log("going down and giving demage");
        // moveCube.getComponent<Rigidbody>()transform.addForce(Vector3(0, 2, 0));
        // return;
    }
}

// void OnCollisionStay (Collision collision)
// {
//         Debug.Log("going down on collision and giving demage");
//     foreach (ContactPoint contact in collision.contacts)
//     {
//         if (Vector3.Angle(contact.normal, Vector3.up) < 20)  
//             isGrounded = true;                                       
//     }
// }
 
// void OnCollisionExit ()
// {
//     isGrounded = false;                                             
// }
}
