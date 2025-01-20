using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.FirstScreen
{
    public class MainScreenView : MonoBehaviour
    {
        [SerializeField] private Button openButton;

        public void SubscribeOpenButton(Action action)
        {
            openButton.onClick.RemoveAllListeners();
            openButton.onClick.AddListener(() => action());
        }

        public void UnsubscribeOpenButton(Action action)
        {
            openButton.onClick.RemoveListener(() => action());
        }
    }
}