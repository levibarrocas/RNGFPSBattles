using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {
    [SerializeField]
    int Life;
    [SerializeField]
    int MaxLife = 100;

    private void Start()
    {
        Life = MaxLife;
    }

    public bool TakeDamage(int Damage)
    {
        Life -= Damage;
        if(Life < 1)
        {
            Die();
            return true;

        } else
        {
            return false;
        }
        
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void Respawn()
    {

    }
}
