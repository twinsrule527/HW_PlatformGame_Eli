using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup_Fly : MonoBehaviour
{
    public PlayerJump MyPlayer;
    public float PowerupTime;

    void OnTriggerStay2D(Collider2D activator) {
        if(activator.name == "PlayerCharacter") {
            MyPlayer.IsFlying = Time.deltaTime*PowerupTime;
            //Destroy(this.gameObject);
        }
    }
}
