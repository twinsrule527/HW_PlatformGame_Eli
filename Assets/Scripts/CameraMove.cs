using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PURPOSE: Moves the camera to be centered on the player as long as the trigger is active
//USAGE: Attached to the camera, which has a trigger child
public class CameraMove : MonoBehaviour
{
    //These two referential objects are for the Trigger for Camera Movement and the obejct the Camera Follows
    public CameraTrigger trigger;
    public Transform IsFollowing;

    //These two public floats determine where the actual "center" of the camera is
    //Positive values will push the center to the right/above the actual character
    public float x_offset;
    public float y_offset;
    
    //This is the possible range at which the camera will stop moving relative to the player
    public float range;
    
    //Rate the camera moves relative to frame rate
    public float cam_rate;

    //Distance between the camera and the player + their offset
    float x_distance;

    float y_distance;

    Vector3 Movement;
    Vector3 Movement_Normal;

    Transform MyTransform;

    void Start() {
        //Gets the Camera's Transform component
        MyTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       if(trigger.camera_move_x) {
           if(MyTransform.position.x > IsFollowing.position.x + x_offset + range || MyTransform.position.x < IsFollowing.position.x + x_offset - range ) {  
                x_distance = IsFollowing.position.x + x_offset - MyTransform.position.x;
           }
           else {
               trigger.camera_move_x = false;
               x_distance = 0f;
           }
       }
       else { 
           x_distance = 0f;
       }
       if(trigger.camera_move_y) {
            if(MyTransform.position.y > IsFollowing.position.y + y_offset + range || MyTransform.position.y < IsFollowing.position.y + y_offset - range ) {  
                y_distance = IsFollowing.position.y + y_offset - MyTransform.position.y;
           }
           else {
               trigger.camera_move_y = false;
               y_distance = 0f;
           }
       }
       else {
           y_distance = 0f;
       }
       Movement = new Vector3(x_distance,y_distance,0f);
       Movement_Normal = Movement*Time.deltaTime*cam_rate;
       MyTransform.position += Movement_Normal;
    }
}
