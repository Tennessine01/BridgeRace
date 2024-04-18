using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : UICanvas
{

    public void PlayButton()
    {
        Resume();
        LevelManager.Ins.OnInit();
        UIManager.Ins.OpenUI<GamePlay>();
        Close(0);
    }
}
