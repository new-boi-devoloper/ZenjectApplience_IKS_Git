using _Source.Services;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace _Source.AnotherTask
{
    public class DestructibleObstacle : MonoBehaviour
    {
        [SerializeField] private GameObject[] brokenPieces; // Массив разрушенных частей
        [SerializeField] private float maxSpiralRadius = 2f; // Максимальный радиус спирали
        [SerializeField] private float fastRotationDuration = 0.5f; // Длительность быстрого вращения
        [SerializeField] private float slowRotationDuration = 2.5f; // Длительность медленного вращения

        private ISoundPlayer _soundPlayer;

        [Inject]
        public void Construct(ISoundPlayer soundPlayer)
        {
            _soundPlayer = soundPlayer;
        }

        public void DestroyObstacle()
        {
            // Воспроизведение звука разрушения
            _soundPlayer.PlayDestroySound();

            // Запуск анимации для каждой части
            foreach (var piece in brokenPieces)
            {
                AnimatePiece(piece);
            }

            // Уничтожение целого препятствия
            Destroy(gameObject);
        }

        private void AnimatePiece(GameObject piece)
        {
            // Активируем часть (если она была неактивна)
            piece.SetActive(true);

            // Отделяем часть от родителя
            piece.transform.parent = null;

            // Выбор случайного направления вращения (влево или вправо)
            int direction = Random.Range(0, 2) == 0 ? 1 : -1;

            // Случайный радиус спирали
            float spiralRadius = Random.Range(0.5f, maxSpiralRadius);

            // Случайное смещение для спирали
            Vector3 spiralOffset = new Vector3(
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f)
            ).normalized * spiralRadius;

            // Создаем последовательность анимаций
            Sequence sequence = DOTween.Sequence();

            // Быстрое вращение
            sequence.Append(
                piece.transform.DORotate(new Vector3(0, 360 * direction, 0), fastRotationDuration,
                        RotateMode.FastBeyond360)
                    .SetEase(Ease.OutQuad)
            );

            // Медленное вращение и движение по спирали
            sequence.Append(
                piece.transform.DOMove(
                    piece.transform.position + spiralOffset,
                    slowRotationDuration
                ).SetEase(Ease.InOutQuad)
            );

            sequence.Join(
                piece.transform.DORotate(new Vector3(0, 180 * direction, 0), slowRotationDuration,
                        RotateMode.LocalAxisAdd)
                    .SetEase(Ease.InOutQuad)
            );

            // Уничтожение части через заданное время
            sequence.OnComplete(() => Destroy(piece));
        }
    }
}