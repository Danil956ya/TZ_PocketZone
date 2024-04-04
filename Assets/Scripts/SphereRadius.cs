using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SphereRadius : MonoBehaviour
{
    public pivot ArmRotation;
    public List<Enemy> OnCircle = new List<Enemy>();

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (!OnCircle.Contains(enemy))
            {
                OnCircle.Add(enemy);
            }
            if(OnCircle.Count > 0)
            {
                ArmRotation.LookAt(GetNearEnemy());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            print($"ywel + {collision.name}");
            OnCircle.Remove(collision.GetComponent<Enemy>());
        }
    }

    private Enemy GetNearEnemy()
    {
        float distance;
        float minDistance = Mathf.Infinity;
        int index = 0;

        if (OnCircle.Count > 0)
        {
            foreach (Enemy enemy in OnCircle)
            {
                distance = Vector3.Distance(enemy.transform.position, transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    index = OnCircle.IndexOf(enemy);
                }
            }
        }
        return OnCircle[index];
    }
}
