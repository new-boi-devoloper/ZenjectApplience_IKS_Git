using Zenject;
using _Source.Abstract;
using _Source.FirstScreen;

namespace _Source.Main
{
    public class MainScreenController : IUIState
    {
        private readonly UISwitcher _uiSwitcher;
        private readonly MainScreenView _view;

        [Inject]
        public MainScreenController(MainScreenView view, UISwitcher uiSwitcher)
        {
            _view = view;
            _uiSwitcher = uiSwitcher;
        }

        public void Enter()
        {
            _view.SubscribeOpenButton(OnOpenButtonClicked);
        }

        public void Exit()
        {
            _view.UnsubscribeOpenButton(OnOpenButtonClicked);
        }

        private void OnOpenButtonClicked()
        {
            _uiSwitcher.SwitchState<PanelController>();
        }
    }
}