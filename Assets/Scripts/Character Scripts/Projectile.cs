using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] [Range(0f, 10f)] private float speed = 1f;
    public int damage;

    // Sets how much damage the projectile deals
    public void setProjectileDamage(int setDamage)
    {
        damage = setDamage;
    }

    // Sets how fast the projectile is
    public void setProjectileSpeed(int setSpeed)
    {
        speed = setSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Ignore Allied Layers (10 - Projectiles, 11 - Humans, 12 - Heroes)
        Physics2D.IgnoreLayerCollision(10, 12);
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    // Whenever it detects a titan
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var attacker = otherCollider.GetComponent<Titan>();
        // Reduce Health
        if (attacker)
        {
            otherCollider.GetComponent<Titan>().receiveDamage(damage);
            Destroy(gameObject);
        }
    }
}
