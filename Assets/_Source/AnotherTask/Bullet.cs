using DG.Tweening.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Source.AnotherTask
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float lifeTime = 3f;
        [SerializeField] private float speed = 10f;
        
        private float _timer;

        private void Update()
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);

            _timer += Time.deltaTime;
            if (_timer >= lifeTime)
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // Уничтожение пули при столкновении
            Destroy(gameObject);

            if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
            {
                if (collision.gameObject.TryGetComponent<DestructibleObstacle>(out var destructibleObstacle))
                {
                    destructibleObstacle.DestroyObstacle();
                }
            }
        }
    }
}