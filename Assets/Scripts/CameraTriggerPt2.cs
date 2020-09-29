using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//PURPOSE: This trigger, the first time it is activated will make it so the player's camera moves up
//USAGE: Attached to an invisible trigger that is right before the player starts needing to head up.
public class CameraTriggerPt2 : MonoBehaviour
{
    public CameraTrigger myTrigger;
    public GameObject myPlayer;
    void OnTriggerEnter2D(Collider2D activator) {
        if(activator.name == myPlayer.name) {
            myTrigger.go_up = true;
        }
    }
}
