using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PURPOSE: When the player holds SPACE and releases,
//they will fly forward in the direction of the arrow
//USAGE: Attached to the player character

public class PlayerJump : MonoBehaviour
{
    //This transform is used to determine the player's jumping direction
    public Transform Directional;

    Transform myTransform;
    Rigidbody2D myRigidbody;
    bool isGrounded;

    bool isJumping = false;
    bool charging = false;
    float charge;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(Directional.localPosition.y.ToString());
        charge = 0f;
        myRigidbody = GetComponent<Rigidbody2D>();//caches the reference
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //When the player holds SPACE to jump, it begins to charge
        if(Input.GetButton("Jump") && isGrounded ) {
            charging = true;
            if( charge < 20 ) {
                charge+=0.05f;
            }
        }
        else if(charging) {
            isJumping = true;
            charging = false;
        }
    }

    void FixedUpdate() {
        if( isJumping ) {
            myRigidbody.velocity = new Vector2(Directional.position.x-myTransform.position.x,Directional.position.y-myTransform.position.y)*charge;
            charge = 0;
            isJumping = false;
        }
    }
}
