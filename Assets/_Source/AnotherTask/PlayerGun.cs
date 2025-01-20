using _Source.Services;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace _Source.AnotherTask
{
    public class PlayerGun : MonoBehaviour
    {
        [SerializeField] private Transform bulletSpawnPoint; // Точка появления пули
        [SerializeField] private float shootCooldown = 0.5f; // Задержка между выстрелами
        private float _timer;

        private ISoundPlayer _soundPlayer;
        private BulletPool _bulletPool;

        [Inject]
        public void Construct(ISoundPlayer soundPlayer, BulletPool bulletPool)
        {
            _soundPlayer = soundPlayer;
            _bulletPool = bulletPool;
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            // Выстрел по ЛКМ
            if (Input.GetMouseButtonDown(0) && _timer >= shootCooldown)
            {
                Shoot();
                _timer = 0f;
            }
        }

        private void Shoot()
        {
            // Получение пули из пула
            var bullet = _bulletPool.Spawn();
            bullet.transform.position = bulletSpawnPoint.position;
            bullet.transform.rotation = bulletSpawnPoint.rotation;

            // Воспроизведение звука выстрела
            _soundPlayer.PlayShootSound();
        }
    }
}