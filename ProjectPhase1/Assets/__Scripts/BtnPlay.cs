using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//When the player wants to start playing from main menu.
public class BtnPlay : ButtonOperations
{

    public Dropdown dropdown;//Dropdown UI
    public GameObject menu, planet1;//Menu and planet screens

    public override void OnClick()
    {
        Globals.SPECIAL_TOOL = dropdown.value;//Set special tool.
        menu.SetActive(false);
        planet1.SetActive(true);
    }
}
