public class StateMachine
{
    private IState currentState;

    public IState GetState()
    {
        return currentState;
    }

    public void SetState(IState state)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = state;
        currentState.Enter();
        }
}