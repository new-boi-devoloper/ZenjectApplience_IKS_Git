using Zenject;
using _Source.Abstract;
using _Source.FirstScreen;
using _Source.Services;
using _Source.Savers;
using _Source.SecondScreen;
using UnityEngine;

namespace _Source.Main
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip openSound;
        [SerializeField] private AudioClip closeSound;

        [SerializeField] private MainScreenView mainScreenView;
        [SerializeField] private PanelView panelView; 
        [SerializeField] private Score score; 

        public override void InstallBindings()
        {
            Container.Bind<IFadeService>().To<FadeService>().AsSingle().Lazy();
            Container.Bind<ISoundPlayer>().To<SoundPlayer>().AsSingle()
                .WithArguments(audioSource, openSound, closeSound).Lazy();
            Container.Bind<ISaver>().To<PlayerPrefsSaver>().AsSingle().Lazy();

            Container.Bind<MainScreenView>().FromInstance(mainScreenView).AsSingle();
            Container.Bind<PanelView>().FromInstance(panelView).AsSingle(); 

            Container.Bind<Score>().FromInstance(score).AsSingle(); 

            Container.Bind<MainScreenController>().AsSingle().Lazy();
            Container.Bind<PanelController>().AsSingle().Lazy();

            Container.Bind<UISwitcher>().AsSingle().Lazy();

            Container.Bind<Bootstrapper>().AsSingle().Lazy();
        }
    }
}