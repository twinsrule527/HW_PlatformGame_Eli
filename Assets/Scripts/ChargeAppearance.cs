using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PURPOSE: Visually, this shows the player how much their jump has charged
//USAGE: attached to a purely visual bar at the top of the room

public class ChargeAppearance : MonoBehaviour
{
    public PlayerJump myPlayer;
    
    Transform myTransform;

    void Start() {
        myTransform = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        //Every update frame, it readjusts its size
        float scalar = 27 / myPlayer.max_charge;
        if(myPlayer.charging) {
            myTransform.localScale = new Vector3(myPlayer.charge*scalar, myTransform.localScale.y, myTransform.localScale.z);
        }
        else if(myTransform.localScale.x>myPlayer.charge*scalar) {
            myTransform.localScale = new Vector3(myTransform.localScale.x-Time.deltaTime*100, myTransform.localScale.y, myTransform.localScale.z);
        }
        else {
            myTransform.localScale = new Vector3(myPlayer.charge*scalar, myTransform.localScale.y, myTransform.localScale.z);
        
        }
    }
}