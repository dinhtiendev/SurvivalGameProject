using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    public int damage = 10;  // Lượng máu mà người chơi mất khi va chạm với quái vật

	void OnCollisionEnter(Collision collision)
	{

		if (collision.gameObject.tag == "Player")
		{
			Player playerController = collision.gameObject.GetComponent<Player>();
			playerController.TakeDamage(damage);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			Player playerController = other.gameObject.GetComponent<Player>();
			playerController.TakeDamage(damage);
		}
	}
}
