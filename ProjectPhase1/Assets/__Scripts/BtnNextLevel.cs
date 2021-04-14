using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//When the player wants to move to this next level.
public class BtnNextLevel : ButtonOperations
{
    public GameObject planet1, planet2;//The two different planets.

    public override void OnClick()
    {
        planet2.SetActive(true);
        planet1.SetActive(false);
    }
}
