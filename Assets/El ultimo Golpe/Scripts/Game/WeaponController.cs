using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private Queue<Bullet> bulletQueue = new Queue<Bullet>();
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject bulletPrefab;

    private int maxAmmo = 10;
    private int reserveAmmo = 30;
    private float shootCooldown = 0.2f;
    private float lastShootTime = 0f;
    private bool isReloading = false;

    private void OnEnable()
    {
        InputReader.shootEvent += Shoot;
        InputReader.reloadEvent += TryReload;
    }

    private void OnDisable()
    {
        InputReader.shootEvent -= Shoot;
        InputReader.reloadEvent -= TryReload;
    }

    private void Start()
    {
        FillInitialAmmo();
    }

    private void Shoot()
    {
        if (isReloading || Time.time - lastShootTime < shootCooldown)
            return;

        if (bulletQueue.Count > 0)
        {
            Bullet bullet = bulletQueue.Dequeue();
            GameObject go = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody rb = go.GetComponent<Rigidbody>();
            rb.linearVelocity = shootPoint.forward * 30f;

            Destroy(go, 2f);
            lastShootTime = Time.time;

            Debug.Log($"Disparo: {bullet.id} | Munición restante: {bulletQueue.Count}");
        }
        else
        {
            Debug.Log("Sin balas, pulsa R para recargar.");
        }
    }

    private void TryReload()
    {
        if (!isReloading && bulletQueue.Count < maxAmmo && reserveAmmo > 0)
            StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Recargando...");
        yield return new WaitForSecondsRealtime(3f);

        int bulletsToReload = Mathf.Min(maxAmmo - bulletQueue.Count, reserveAmmo);

        for (int i = 0; i < bulletsToReload; i++)
        {
            Bullet newBullet = new Bullet("B" + Random.Range(1000, 9999));
            bulletQueue.Enqueue(newBullet);
            reserveAmmo--;
        }

        Debug.Log($"Recarga completa: {bulletQueue.Count}/{maxAmmo} | Reserva: {reserveAmmo}");
        isReloading = false;
    }

    private void FillInitialAmmo()
    {
        for (int i = 0; i < maxAmmo; i++)
        {
            bulletQueue.Enqueue(new Bullet("B" + Random.Range(1000, 9999)));
        }
    }
    public class Bullet
    {
        public string id;
        public Bullet(string id)
        {
            this.id = id;
        }

        public override string ToString()
        {
            return id;
        }
    }
}
