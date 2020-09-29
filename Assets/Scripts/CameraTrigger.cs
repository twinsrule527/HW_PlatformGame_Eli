using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PURPOSE: This trigger exists so that we can have deadzones associated with the middle of the screen
//USAGE: Attached to a trigger which is a child of the camera.
public class CameraTrigger : MonoBehaviour
{
    public bool camera_move_x;
    public bool camera_move_y;
    public bool go_up = false;

    // Update is called once per frame
    void OnTriggerExit2D(Collider2D activator) {
        if(activator.name == "PlayerCharacter") {
            camera_move_x = true;
            if(go_up) {
                camera_move_y = true;
            }
        }
    }
}
