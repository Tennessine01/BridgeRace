using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPos : MonoBehaviour
{
  
    private void OnTriggerEnter(Collider other)
    {
        LevelManager.Ins.OnDespawn();

        if (other.CompareTag("Player"))
        {
            UICanvas.Ins.Pause();
            UIManager.Ins.OpenUI<Win>();
        }
        if (other.CompareTag("currentEnemy"))
        {
            UICanvas.Ins.Pause();
            UIManager.Ins.OpenUI<Lose>();
        }
    }
}
