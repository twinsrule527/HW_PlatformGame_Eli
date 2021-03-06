﻿using System.Collections;
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
    public bool isGrounded;
    public float IsFlying = 0;
    public float flyCharge;
    public float minCharge;
    bool isJumping = false;
    public bool charging = false;
    public float charge;
    public float charge_rate;
    public float max_charge;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(Directional.localPosition.y.ToString());
        charge = minCharge;
        myRigidbody = GetComponent<Rigidbody2D>();//caches the reference
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //When the player holds SPACE to jump, it begins to charge
        if(Input.GetButton("Jump") && (isGrounded || IsFlying > 0 )) {
            charging = true;
            if( charge < max_charge ) {
                charge+=charge_rate*Time.deltaTime;
            }
            if(IsFlying > 0 && charge < flyCharge ) {
                charge = flyCharge;
            }
        }
        //Whent the player first releases SPACE, it stops charging and the player jumps
        else if(charging) {
            isJumping = true;
            charging = false;
        }
        if( IsFlying > 0 ) {
            IsFlying -=1;
        }
    }

    void FixedUpdate() {
        if( isJumping ) {
            myRigidbody.velocity = new Vector2(Directional.position.x-myTransform.position.x,Directional.position.y-myTransform.position.y)*charge;
            charge = minCharge;
            isJumping = false;
        }
    }
}
