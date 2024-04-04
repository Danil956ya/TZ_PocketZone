using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyRadius : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Enemy owner = transform.parent.GetComponent<Enemy>();
            float distance = Vector2.Distance(collision.transform.position, transform.position);
            owner.MoveTo(collision.transform,distance);
        }
    }
}
