using System;
using System.Collections.Generic;
using _Source.Abstract;
using _Source.Savers;
using _Source.Services;
using UnityEngine;

namespace _Source.Main
{
    public class ServiceLocator : IService
    {
        private readonly Dictionary<Type, object> _services = new();

        public ServiceLocator(AudioSource audioSource, AudioClip openSound, AudioClip closeSound, AudioClip shootSound, AudioClip destroySound)
        {
            RegisterService<IFadeService>(new FadeService());
            RegisterService<ISoundPlayer>(new SoundPlayer(audioSource, openSound, closeSound, shootSound, destroySound));
            
            RegisterService<ISaver>(new PlayerPrefsSaver());
        }

        public T GetService<T>()
        {
            return (T)_services[typeof(T)];
        }

        public void RegisterService<T>(T service)
        {
            _services[typeof(T)] = service;
        }
    }
}