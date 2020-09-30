using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PURPOSE: When this button is pressed, it opens the end Door
//USAGE: Attached to a trigger child of the Button
public class ButtonTrigger : MonoBehaviour
{
    public SpriteRenderer myDoor;
    public Sprite End_Sprite;
    public AudioSource doorAudio;
    void OnTriggerEnter2D(Collider2D activator) {
        if(activator.name == "PlayerCharacter") {
            myDoor.sprite = End_Sprite;
            doorAudio.Play();
        }
    }
}
