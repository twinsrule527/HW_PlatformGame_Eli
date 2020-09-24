using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PURPOSE: Rotates the arrow which is used to determine the player's movement
//USAGE: Attach to hinge object which is a child of the Player Character,
//and a parent of the arrow sprite.
public class ArrowRotate : MonoBehaviour
{
    //General initial variables:
    public float rotationSpeed = 30f;

    Transform myTransform;

    void Start() {

        myTransform = GetComponent<Transform>();

    }
    // Update is called once per frame
    void Update()
    {
        //Gets the player's horizontal movement
        float arrowSpeed = Input.GetAxis("Horizontal");

        transform.Rotate( 0f, 0f, -1f * arrowSpeed * Time.deltaTime * rotationSpeed);

        float z_Rotate = myTransform.eulerAngles.z;
        
       // Debug.Log(z_Rotate.ToString());
        //Clamp the possible rotation
        
        if(z_Rotate > 85 && z_Rotate < 180 ) {
            myTransform.eulerAngles = new Vector3(0f, 0f, 85f);
        }
        else if(z_Rotate > 180 && z_Rotate < 275) {
            
            myTransform.eulerAngles = new Vector3(0f, 0f, 275f);
        }

    }
}
