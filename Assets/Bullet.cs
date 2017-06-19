using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int Damage;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 3);
	}

    private void OnTriggerEnter(Collider other)
    {

        if(other.GetComponent<CharacterManager>() != null)
        {
            other.GetComponent<CharacterManager>().TakeDamage(Damage);
        }

        Destroy(gameObject);
    }

}
