using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private UnityEvent _walkRightEvent;
    [SerializeField] private UnityEvent _walkLeftEvent;
    [SerializeField] private UnityEvent _runRightEvent;
    [SerializeField] private UnityEvent _runLeftEvent;
    [SerializeField] private UnityEvent _flipEvent;
    [SerializeField] private UnityEvent _moveVerticalEvent;
    [SerializeField] private UnityEvent _attackEvent;

    private Coroutine _coroutine;

    private void Start()
    {
        _coroutine = StartCoroutine(BeginControlsListener());
    }

    private IEnumerator BeginControlsListener()
    {
        bool IsContinue = true;

        while (IsContinue)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _moveVerticalEvent.Invoke();
            }

            if (Input.GetKey(KeyCode.D))
            {
                _flipEvent.Invoke();

                if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
                    _runRightEvent.Invoke();
                else
                    _walkRightEvent.Invoke();
            }

            if (Input.GetKey(KeyCode.A))
            {
                _flipEvent.Invoke();

                if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
                    _runLeftEvent.Invoke();
                else
                    _walkLeftEvent.Invoke();
            }
            
            if (Input.GetKeyDown(KeyCode.Space))
                    _attackEvent.Invoke();

            yield return null;
        }
    }

    private void OnDeath()
    {
        StopCoroutine(_coroutine);
    }
}
