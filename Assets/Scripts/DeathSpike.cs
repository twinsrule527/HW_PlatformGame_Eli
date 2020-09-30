using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//PURPOSE: Used to kill the player when they enter the trigger area of a Spike
//USAGE: Attached to spikes
public class DeathSpike : MonoBehaviour
{
    public GameObject MyPlayer;
    public bool death;

    void OnTriggerEnter2D(Collider2D activator) {
        if(activator.name == MyPlayer.name) {
            death = true;
        }
    }
}
