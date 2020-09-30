using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//PURPOSE: A basic manager script that does actions when the player either loses or wins the game
//USAGE: Attached to an invisible manager object
public class Start_EndScript : MonoBehaviour
{
    public DeathSpike death;
    public EndDoor_Trigger EndDoor;
    public float death_delay;
    public float victory_delay;
    float delay = 0;

    // Update is called once per frame
    void Update()
    {
        if(death.death) {
            delay++;
            if(delay>death_delay*Time.deltaTime) {
                SceneManager.LoadScene(0);
            }
        }
        else if(EndDoor.finished) {
            delay++;
            if(delay>victory_delay*Time.deltaTime) {
                SceneManager.LoadScene(0);
            }
        }
    }
}
