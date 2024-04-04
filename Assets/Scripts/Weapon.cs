using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public TMP_Text text; 
    public int Damage;
    public int CurrentBullets;
    public const int MaxBullets = 30;
    public const int BulletSpeed = 20;
    public float timeBetweenStrike;

    private void Start()
    {
        CurrentBullets = MaxBullets;
    }

    public void Shoot()
    {
        if (CurrentBullets > 0)
        {
            CurrentBullets--;
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
            rigidbody.velocity = BulletSpeed * firePoint.right;
            UpdateVisual();
        }
    }

    private void UpdateVisual()
    {
        text.text = $"{CurrentBullets} / {MaxBullets}";
    }

    public void Reload()
    {
        CurrentBullets = MaxBullets;
        UpdateVisual();
    }
}
