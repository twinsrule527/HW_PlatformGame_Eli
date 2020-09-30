using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDoor_Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public bool finished;

    public Sprite OpenDoor;

    SpriteRenderer mySprite;

    void Start() {
        mySprite = GetComponent<SpriteRenderer>();

    }
    void OnTriggerEnter2D() {
        if(mySprite.sprite == OpenDoor) {
            finished = true;
        }
    }
}
