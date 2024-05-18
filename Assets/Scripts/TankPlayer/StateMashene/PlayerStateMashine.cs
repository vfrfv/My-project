using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerStateMashine : MonoBehaviour
{
    [SerializeField] State _firstState;

    private Enemy _target;
    private State _currentState;

    public State CurrentState => _currentState;

    private void Start()
    {
        //_target = GetComponent<Player>().Target;
        Reset(_currentState);
    }

    private void Update()
    {
        if (_currentState == null)
        {
            return;
        }

        var nextState = _currentState.GetNextState();

        if (nextState != null)
        {
            Transit(nextState);
        }
    }

    private void Reset(State startState)
    {
        _currentState = startState;

        if (_currentState != null)
        {
            _currentState.Enter(_target);
        }
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = nextState;

        if( _currentState != null )
        {
            _currentState.Enter(_target);
        }
    }
}
