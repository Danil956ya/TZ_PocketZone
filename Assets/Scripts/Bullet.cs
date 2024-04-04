using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            collision.GetComponent<IDamaged>().TakeDamage(5);
            Destroy(gameObject);
        }
        else if (collision.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
