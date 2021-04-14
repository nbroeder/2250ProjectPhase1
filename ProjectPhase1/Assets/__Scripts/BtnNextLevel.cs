using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnNextLevel : ButtonOperations
{
    public GameObject planet1, planet2;

    public override void OnClick()
    {
        planet2.SetActive(true);
        planet1.SetActive(false);
    }
}
