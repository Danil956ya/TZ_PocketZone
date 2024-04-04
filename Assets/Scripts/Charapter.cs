using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.InputSystem;


public class Charapter : MonoBehaviour, IDamaged
{
    private Vector2 _moveInput;
    private AgentMover _agentMover;
    public int CurrentHealth = 50;
    public int MaxHealth = 100;
    public InputActionReference movement, attack;
    public Weapon weapon;
    public Healthbar healthbar;

    private void Start()
    {
        CurrentHealth = MaxHealth;
        healthbar.SetMaxHealth(MaxHealth);
        _agentMover = GetComponent<AgentMover>();
        weapon = GetComponent<Weapon>();
    }

    private void FixedUpdate()
    {
        _moveInput = movement.action.ReadValue<Vector2>();
    }

    private void Update()
    {
        _agentMover.MovementInput = _moveInput;
    }

    public void OnFire()
    {
        weapon.Shoot();
    }

    public void OnReload()
    {
        weapon.Reload();
    }

    public void OnInventory()
    {
        InventoryManager inventory = FindObjectOfType<InventoryManager>();
        if (inventory != null)
        {
            inventory.ShowInventory();
        }
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        healthbar.SetHealth(CurrentHealth);
        if (CurrentHealth < 0)
        {
            GameManager.Instance.UpdateGameState(GameState.OnDie);
        }
    }
}
