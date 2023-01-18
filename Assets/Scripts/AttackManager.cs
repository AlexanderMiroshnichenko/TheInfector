using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	public class AttackManager : MonoBehaviour
	{
		[SerializeField] private AttackComponent m_weapon;

		public void Attack()
		{
			m_weapon.Attack();
		}
	}
}