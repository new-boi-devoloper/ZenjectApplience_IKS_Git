using Zenject;
using _Source.Abstract;
using _Source.AnotherTask;
using _Source.FirstScreen;
using _Source.Services;
using _Source.Savers;
using _Source.SecondScreen;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Source.Main
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip openSound;
        [SerializeField] private AudioClip closeSound;
        [SerializeField] private AudioClip shootSound;
        [SerializeField] private AudioClip destroySound;

        [SerializeField] private GameObject bulletPrefab;

        [SerializeField] private MainScreenView mainScreenView;
        [SerializeField] private PanelView panelView;
        [SerializeField] private Score score;

        public override void InstallBindings()
        {
            Container.BindMemoryPool<Bullet, BulletPool>()
                .WithInitialSize(10)
                .FromComponentInNewPrefab(bulletPrefab)
                .UnderTransformGroup("Bullets")
                .Lazy();

            Container.Bind<IFadeService>().To<FadeService>().AsSingle().Lazy();
            Container.Bind<ISoundPlayer>().To<SoundPlayer>().AsSingle()
                .WithArguments(audioSource, openSound, closeSound, shootSound, destroySound).Lazy();
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