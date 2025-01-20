using System;
using UnityEngine.UI;

namespace _Source.Services
{
    public interface IFadeService
    {
        void FadeIn(Image image, float duration, Action onComplete);
        void FadeOut(Image image, float duration, Action onComplete);
    }
}