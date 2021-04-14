using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//NPC script
public class NPCFriend : MonoBehaviour
{
    //textbox
    public Text dialogueTextbox;

    //the string that the friend will say
    public string dialogueText;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            dialogueTextbox.text = "";
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Speak();
        }
    }

    //called when the player collides with the object.
    //It displays the message from the npc
    public void Speak()
    {
        dialogueTextbox.text = dialogueText;
    }
}
