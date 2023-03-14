using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    public int damage = 10;  // Lượng máu mà người chơi mất khi va chạm với quái vật

	

	//void OnTriggerEnter2D(Collision2D other)
	//{
	//	if (other.gameObject.tag == "Player")
	//	{
	//		Player playerController = other.gameObject.GetComponent<Player>();
	//		playerController.TakeDamage(damage);
	//	}
	//}
}
