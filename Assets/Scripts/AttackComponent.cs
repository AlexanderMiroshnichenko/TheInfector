using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{

	public class AttackComponent : MonoBehaviour
	{
		[SerializeField] private BulletComponent m_bulletPrefab;

		public void Attack()
		{
			var bullet = Instantiate(m_bulletPrefab, transform.position, transform.rotation);
			bullet.Shoot();
		}
	}
}