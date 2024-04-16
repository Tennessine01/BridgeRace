    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.TextCore.Text;

    public class PatrolState : IState<Character>
    {
        public void OnEnter(Character t)
        {
            t.ChangeAnim("Running");
            if (t is Enemy enemy)
            {
                enemy.MoveToBrick();
            }

    }

    public void OnExecute(Character t)
        {
            if (t is Enemy enemy)
            {
                enemy.CheckMoving();
                if (enemy.isMoving == false)
                {
                    //Debug.Log("change state-----");
                    enemy.ChangeState(new IdleState());
                }
            }
            
        }

        public void OnExit(Character t)
        {

        }

    }
