using System.Collections;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State startState;

    protected State currentState;
    protected virtual void Start()
    {
        ChangeState(startState);
    }

    void Update()
    {
        if (currentState != null)
            currentState.UpdateLogic();

        if (currentState == null)
            Debug.LogWarning($"{this.gameObject.name} has no CurrentState!!!");
    }

    private void FixedUpdate()
    {
        if (currentState != null)
            currentState.UpdatePhysics();
    }

    public void ChangeState(State newState)
    {
        StartCoroutine(changeState(newState));
    }

    private IEnumerator changeState(State newState)
    {
        yield return new WaitForEndOfFrame();
        if (currentState != null)
            currentState.Exit();

        currentState = newState;
        currentState.Enter();

        Debug.Log($"Entered new State: {newState}");
    }
}