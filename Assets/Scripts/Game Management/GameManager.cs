using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject[] enemies;

    [SerializeField]
    FreeMovement player;

    SceneChangeTrigger sct;

    public void Start()
    {
        sct = new SceneChangeTrigger();

        //Empty enemies if needed

        //Maybe give player a link to easily trigger functions
        //Wait no, that's unecessary. Neither are destroyed on load.
        //I can just hard link them.
    }

    //Logic for any in game transition involving more thatn 1 disconnected objects
    //Probably will need to add observer where all enemies individually update GM
    public void TriggerProgress()
    {
        //Reduce number of enemies present in count (Not implemented, but this is where it would go)

        //Trigger second phase if appicable

        //For now, send to hub
        SendToHub();
    }

    //Logic for player death
    public void PlayerDead()
    {

        //Somehow pause gameplay

        //Trigger death screen overlay with buttons to either restart or quit

        //Temporary auto send to hub
        SendToHub();
    }

    private void SendToHub()
    {
        sct.ManualChangeScene(1);
    }
}
