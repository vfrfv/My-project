using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transactions;

    protected Enemy Target { get; private set; }

    public void Enter(Enemy target)
    {
        if (enabled == false)
        {
            Target = target;
            enabled = true;

            foreach (var transaction in _transactions)
            {
                transaction.enabled = true;
                transaction.Init(Target);
            }
        }
    }

    public void Exit()
    {
        if(enabled == true)
        {
            foreach (var transaction in _transactions)
            {
                transaction.enabled = false;
            }

            enabled = false;
        }
    }

    public State GetNextState()
    {
        foreach (var transaction in _transactions)
        {
            if (transaction.NeedTransit)
            {
                return transaction.TargetState;
            }
        }

        return null;
    }
}
