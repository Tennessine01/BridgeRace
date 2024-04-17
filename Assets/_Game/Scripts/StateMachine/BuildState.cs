using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildState : IState<Character>
{
    public void OnEnter(Character t)
    {
        t.ChangeAnim("Running");
    }

    public void OnExecute(Character t)
    {
        if( t is Enemy enemy)
        {
            if (enemy.charListBricks.Count == 0)
            {
                //enemy.rb.velocity = Vector3.zero;
                enemy.ChangeState(new PatrolState());
            }
            else
            {
                enemy.MoveToWinPos();
            }
            //Debug.Log("Build_State");

            
        }
    }

    public void OnExit(Character t)
    {

    }

}
