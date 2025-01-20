using Zenject;
using _Source.Abstract;
using _Source.SecondScreen;
using _Source.Services;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.Main
{
    public class PanelController : IUIState
    {
        private readonly IFadeService _fadeService;
        private readonly ISoundPlayer _soundPlayer;
        private readonly UISwitcher _uiSwitcher;
        private readonly PanelView _view;
        private readonly Score _score;
        private readonly ISaver _saver;

        [Inject]
        public PanelController(
            PanelView view,
            UISwitcher uiSwitcher,
            IFadeService fadeService,
            ISoundPlayer soundPlayer,
            ISaver saver,
            Score score)
        {
            _view = view;
            _uiSwitcher = uiSwitcher;
            _fadeService = fadeService;
            _soundPlayer = soundPlayer;
            _saver = saver;
            _score = score;
        }

        public void Enter()
        {
            _view.gameObject.SetActive(true);
            _view.SubscribeCloseButton(OnCloseButtonClicked);

            _fadeService.FadeIn(_view.GetComponent<Image>(), 0.5f, () => { _view.gameObject.SetActive(true); });

            _soundPlayer.PlayOpenSound();
        }

        public void Exit()
        {
            _view.UnsubscribeCloseButton(OnCloseButtonClicked);

            _fadeService.FadeOut(_view.GetComponent<Image>(), 0.5f, () => { _view.gameObject.SetActive(false); });

            _soundPlayer.PlayCloseSound();
            _saver.SaveScore(_score.GetScore());
        }

        private void OnCloseButtonClicked()
        {
            _uiSwitcher.SwitchState<MainScreenController>();
        }
    }
}