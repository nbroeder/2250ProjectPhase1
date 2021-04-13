﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnPlay : ButtonOperations
{

    public Dropdown dropdown;

    public override void OnClick()
    {
        Globals.SPECIAL_TOOL = dropdown.value;
        SceneManager.LoadScene(1);
    }
}