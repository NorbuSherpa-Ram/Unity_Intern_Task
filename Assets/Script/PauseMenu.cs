using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PauseMenu : LoadLevel
{
    public static event Action onPause;
    public static PauseMenu instance;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape ))
        {
            onPause?.Invoke();
        }
    }
}
