using _Source.AnotherTask;
using UnityEngine;
using Zenject;

public class BulletPool : MonoMemoryPool<Bullet>
{
    protected override void OnCreated(Bullet bullet)
    {
        // Инициализация пули при создании
        bullet.gameObject.SetActive(false);
    }

    protected override void OnSpawned(Bullet bullet)
    {
        // Активация пули при появлении
        bullet.gameObject.SetActive(true);
    }

    protected override void OnDespawned(Bullet bullet)
    {
        // Деактивация пули при возврате в пул
        bullet.gameObject.SetActive(false);
    }
}