using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PURPOSE: While triggered, the selected platform will move a certain distance
//USAGE: Attach to a child trigger of a parent platform that you want to move

public class MovingPlatformTrigger : MonoBehaviour
{
    public Transform myPlatform;

    public Transform myPlayer;

//These two floats will determine the speed the platform moves in both directions
//+: moves up/right. -: moves left/down
    public float x_speed;

    public float y_speed;

//These two floats determine the positions at which the platform should stop relative to its start
//NOTE: must always be in the direction of the x_speed/y_speed, otherwise they won't stop
    public float x_stop;
    public float y_stop;

//This variable is used to determine if the platform will return to its starting position or not
    public bool return_when_done;

//These referential floats are used to determine where the platform starts, in case it moves back
    float x_start;

    float y_start;

//This final variable is used to trigger when the object no longer is interacting with anything else
    public bool done;
    // Start is called before the first frame update
    void Start()
    {
        x_start = myPlatform.position.x;
        
        y_start = myPlatform.position.y;

        done = true;
    }

    //While an object is in the trigger, this object will move if it has not reached its end
    void OnTriggerEnter2D(Collider2D activator) {
        if(activator.name == myPlayer.name) {
            done = false;
        }

    }
//When an object leaves the trigger, it will move back to its start
    void OnTriggerExit2D(Collider2D activator) {
        if(activator.name == myPlayer.name) {
            done = true;
        }
    }

//if the platform is not being interacted with, and return_when_done is selected,
//the platform will go back to start when finished
    void Update() {
        if(!done) {
            if(( myPlatform.position.x < x_start + x_stop && x_speed > 0 ) || ( myPlatform.position.x > x_start + x_stop && x_speed < 0 ) ) {
                myPlatform.position += new Vector3(x_speed, 0f, 0f);
                myPlayer.position += new Vector3(x_speed, 0f, 0f);
            }
            if(( myPlatform.position.y < y_start + y_stop && y_speed > 0 ) || ( myPlatform.position.y > y_start + y_stop && y_speed < 0 ) ) {
                myPlatform.position += new Vector3(0f, y_speed, 0f);
            }
        }   
        else if(return_when_done && done) {
             if(( myPlatform.position.x > x_start && x_speed > 0 ) || ( myPlatform.position.x < x_start && x_speed < 0 ) ) {
                myPlatform.position -= new Vector3(x_speed, 0f, 0f);
             }
             if(( myPlatform.position.y > y_start && y_speed > 0 ) || ( myPlatform.position.y < y_start && y_speed < 0 ) ) {
                myPlatform.position -= new Vector3(0f, y_speed, 0f);
             }
        }

    }
}
