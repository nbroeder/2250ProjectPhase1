using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnMainMenu : ButtonOperations
{
    public override void OnClick()
    {
       SceneManager.LoadScene(0);
    }
}
