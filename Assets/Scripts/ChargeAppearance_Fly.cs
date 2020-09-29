using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeAppearance_Fly : MonoBehaviour
//PURPOSE: A charge bar for how much flying power a player has
//USAGE: Attach to a child bar of the Main Camera
{ 
    public PlayerJump myPlayer;
    public Powerup_Fly myFly;
    
    Transform myTransform;

    void Start() {
        myTransform = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        //Every update frame, it readjusts its size
        float scalar = 1500 / (myFly.PowerupTime);//*Time.deltaTime);
        myTransform.localScale = new Vector3(myPlayer.IsFlying*scalar, myTransform.localScale.y, myTransform.localScale.z);
    }
}