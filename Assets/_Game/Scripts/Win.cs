using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : UICanvas
{
    public Text score;

    public void MainMenuButton()
    {
        LevelManager.Ins.OnDespawn();
        UIManager.Ins.OpenUI<Menu>();
        Close(0);
    }
}
