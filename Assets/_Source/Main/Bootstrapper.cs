using Zenject;
using _Source.Abstract;
using _Source.FirstScreen;
using _Source.SecondScreen;
using UnityEngine;

namespace _Source.Main
{
    public class Bootstrapper : MonoBehaviour
    {
        private MainScreenController _mainScreenController;
        private PanelController _panelController;
        private UISwitcher _uiSwitcher;

        [Inject]
        public void Construct(
            MainScreenController mainScreenController,
            PanelController panelController,
            UISwitcher uiSwitcher)
        {
            _mainScreenController = mainScreenController;
            _panelController = panelController;
            _uiSwitcher = uiSwitcher;
        }

        private void Start()
        {
            _uiSwitcher.RegisterState<MainScreenController>(_mainScreenController);
            _uiSwitcher.RegisterState<PanelController>(_panelController);

            _uiSwitcher.SwitchState<MainScreenController>();
        }
    }
}