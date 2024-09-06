using System;

namespace Code.Models.PlayerStates
{
    public interface IState
    {
        public void Activate();
        public void Deactivate();
        public void Execute();
        public event Action<IState> OnStateChanged;
    }
}