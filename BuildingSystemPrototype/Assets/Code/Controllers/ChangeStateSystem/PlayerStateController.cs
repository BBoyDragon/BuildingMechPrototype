using Code.Models.PlayerStates;
using Zenject;

namespace Code.Controllers.ChangeStateSystem
{
    public class PlayerStateController: IExecute, IClean
    {
        private IState _curentState;
        
        public PlayerStateController([Inject(Id = "StartingState")] IState curentState)
        {
            _curentState = curentState;
            _curentState.OnStateChanged += ChangeState;
            _curentState.Activate();
        }

        public void Execute()
        {
            _curentState.Execute();
        }

        private void ChangeState(IState newState)
        {
            _curentState.OnStateChanged -= ChangeState;
            _curentState.Deactivate();
            _curentState = newState;
            _curentState.OnStateChanged += ChangeState;
            _curentState.Activate();
        }
        public void Clean()
        {
            _curentState.OnStateChanged -= ChangeState;
        }
    }
}