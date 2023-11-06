using System.Collections;
using UnityEngine;

public class AIStateMachine : MonoBehaviour
{
    [SerializeField] private State _startState;

    private State _currentState;
    private Coroutine _coroutine;

    private void Start()
    {
        _currentState = _startState;
    }
    
    public void Enable()
    {
        _coroutine = StartCoroutine(Run());
    }

    public void Disable()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator Run()
    {
        bool isContinue = true;

        while (isContinue)
        {
            State nextState = _currentState?.Run();

            if (nextState != null)
                SwitchToNextState(nextState);

            yield return new WaitForFixedUpdate();
        }
    }

    private void SwitchToNextState(State nextState)
    {
        _currentState = nextState;
    }
}
