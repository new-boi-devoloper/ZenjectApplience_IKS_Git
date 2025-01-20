using System;
using System.Collections.Generic;
using _Source.Abstract;

namespace _Source.Main
{
    public class UISwitcher
    {
        private readonly Dictionary<Type, IUIState> _states = new();
        private IUIState _currentState;

        public void RegisterState<T>(IUIState state) where T : IUIState
        {
            _states[typeof(T)] = state;
        }

        public void SwitchState<T>() where T : IUIState
        {
            if (_states.TryGetValue(typeof(T), out var state))
            {
                _currentState?.Exit();
                _currentState = state;
                _currentState.Enter();
            }
            else
            {
                throw new InvalidOperationException($"State {typeof(T)} is not registered.");
            }
        }
    }
}