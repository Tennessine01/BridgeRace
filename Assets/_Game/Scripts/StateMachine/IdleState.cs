using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState<Character>
{
    public void OnEnter(Character t)
    {
        //Debug.Log("aaaaaa");
        t.ChangeAnim("Idle");
        if (t is Enemy enemy)
        {
            enemy.GetDestination(enemy.colortype);
            Debug.Log(" idle state----0------");
        }
    }

    public void OnExecute(Character t)
    {
        if(t is Enemy enemy)
        {
            enemy.CheckMoving();
            //Debug.Log( "-------------");

            if (enemy.isMoving == true)
            {
                enemy.ChangeState(new PatrolState());
            }
        }
    }

    public void OnExit(Character t)
    {

    }

}
