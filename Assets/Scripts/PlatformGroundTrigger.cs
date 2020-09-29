using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PURPOSE: A trigger that dictates whther a player is on the ground, and thus, whether they can jump
//USAGE: A trigger box parented by the player sprite
public class PlatformGroundTrigger : MonoBehaviour
{
    public PlayerJump myPlayer;
    public GameObject playerName;

    void OnTriggerEnter2D(Collider2D activator ) {
       if(activator.name != playerName.name && activator.name != "CameraTrigger" && activator.name != "CameraTriggerPt2") {
          myPlayer.isGrounded = true;
       }
    }

    void OnTriggerExit2D(Collider2D activator ) {
       if(activator.name != playerName.name && activator.name != "CameraTrigger" && activator.name != "CameraTriggerPt2") {
          myPlayer.isGrounded = false;
       }
    }
}
