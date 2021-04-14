using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnMainMenu : ButtonOperations
{
    public GameObject Menu, Planet1, Planet2;

    public override void OnClick()
    {
        HeroController.health = 3;
        HeroController.xp = 0;
        Menu.SetActive(true);
        Planet1.SetActive(false);
        Planet2.SetActive(false);
    }
}
