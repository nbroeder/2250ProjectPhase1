using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnNextLevel : ButtonOperations
{
    public override void OnClick()
    {
        SceneManager.LoadScene(2);
    }
}
