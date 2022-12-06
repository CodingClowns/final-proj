using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSource : MonoBehaviour
{
    [Tooltip("If true, the bullet source will fire on input in the aim direction.")]
    [SerializeField] private bool player = false;
    [Tooltip("How long the player has to wait before firing again.")]
    [SerializeField] private float coolDownTime;
    [Tooltip("How fast the bullet should move.")]
    [SerializeField] private float bulletSpeed;
    [Tooltip("What position relative to the object the bullet will be fired from.")]
    [SerializeField] private Vector2 fireOffset;
    [Tooltip("The range of angles that the player can fire in.")]
    [SerializeField] private float angleRange = 90;

    [Header("References:")]
    [SerializeField] private Bullet bulletPrefab;

    private float cooldown = 0;

    public void Fire(Vector2 direction)
    {
        Bullet bullet = Instantiate(bulletPrefab, transform.position + new Vector3(fireOffset.x, fireOffset.y, 10), Quaternion.FromToRotation(Vector2.up, direction));
        bullet.Initialize(direction, player);
    }

    private void HandleInput()
    {
        if (player && Input.GetMouseButtonDown(0) && cooldown <= 0)
        {
            Vector2 cursorLocal = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

            float angle = Mathf.Clamp(Vector2.SignedAngle(-transform.up, cursorLocal), -angleRange, angleRange) / 45f;
            Vector2 finalDir = new Vector2(Mathf.Cos((Mathf.Round(angle) * 45 + 90) * Mathf.Deg2Rad), -Mathf.Sin((Mathf.Round(angle) * 45 + 270) * Mathf.Deg2Rad));
            Fire(finalDir * bulletSpeed);
            cooldown = coolDownTime;
        }

        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }

    private void Update()
    {
        HandleInput();
    }
}
