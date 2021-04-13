using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOperations : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    public virtual void OnClick()
    {

    }
}
