using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStateController : ControllerBase
{
    public static GameState CurrentState;
    private static GameStateController instance;
    public List<GameStateModel> StateModels;
    [HideInInspector] public GameStateModel ActiveStateModel;

    public override void Initialize()
    {
        base.Initialize();
        instance = this;
        changeState(GameState.Loading);
    }

    private void Update()
    {
        stateUpdates();
    }

    private void stateUpdates()
    {
        if (instance != null)
        {
            if (instance.ActiveStateModel != null)
            {
                instance.ActiveStateModel.StateUpdate();
            }
        }
    }

    public static void ChangeState(GameState state)
    {
        if (CurrentState != state)
        {
            instance.changeState(state);
        }
    }

    private void changeState(GameState state)
    {
        CurrentState = state;
        instance.ActiveStateModel = instance.StateModels[(int)state];
        instance.ActiveStateModel.OnStateChange();
    }

    [System.Serializable]
    public class GameStateModel
    {
        public GameState State;
        public List<UnityEvent> OnStateChangeEvents;
        public List<ControllerBase> StateControllers;

        public void StateUpdate()
        {
            for (int i = 0; i < StateControllers.Count; i++)
            {
                StateControllers[i].ControllerUpdate();
            }
        }

        public void OnStateChange()
        {
            for (int i = 0; i < OnStateChangeEvents.Count; i++)
            {
                OnStateChangeEvents[i]?.Invoke();
            }

        }
    }
}
