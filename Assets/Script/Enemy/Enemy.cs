using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(AIStateMachine))]
public class Enemy : MonoBehaviour
{   
    private AIStateMachine _stateMachine;
        
    private void Start()
    {
        _stateMachine = GetComponent<AIStateMachine>();
        _stateMachine.Enable();
    }
    
    private void OnDeath()
    {
        _stateMachine.Disable();
    }
}
