using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.SecondScreen
{
    public class PanelView : MonoBehaviour
    {
        [SerializeField] private Button closeButton;

        public void SubscribeCloseButton(Action action)
        {
            closeButton.onClick.RemoveAllListeners();
            closeButton.onClick.AddListener(() => action());
        }

        public void UnsubscribeCloseButton(Action action)
        {
            closeButton.onClick.RemoveListener(() => action());
        }
    }
}