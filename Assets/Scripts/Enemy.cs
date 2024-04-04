using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamaged
{
    private Rigidbody2D _rb;
    public int Health = 50;
    public int MaxHealth = 50;
    public float MaveSpeed = 5;
    public int AttackDistance = 2;
    public Healthbar Healthbar;
    public Animator Animator;
    public List<Item> spawnsItems = new List<Item>();


    private void Start()
    {
        Health = MaxHealth;
        Healthbar.SetMaxHealth(MaxHealth);
        spawnsItems = ItemList.GetItems();
        _rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Healthbar.SetHealth(Health);
        if (Health <= 0)
        {
            OnDie();
        }
    }

    public void MoveTo(Transform target, float distance)
    {
        Vector2 direction = (target.position - transform.position).normalized;
        _rb.MovePosition(_rb.position + (direction.normalized * MaveSpeed) * Time.fixedDeltaTime);
        if(distance < AttackDistance)
        {
            Animator.SetTrigger("Attack");
            target.GetComponent<IDamaged>().TakeDamage(1);
        }
    }

    protected virtual void OnDie()
    {
        Item refence = RandomItem();
        GameObject tempItem = Instantiate(refence.Prefab, transform.position, Quaternion.identity);
        tempItem.GetComponent<ItemDisplay>().ItemData = refence;
        Destroy(gameObject);
    }

    private Item RandomItem()
    {
        int random = Random.Range(0, spawnsItems.Count);
        return spawnsItems[random];
    }
}
