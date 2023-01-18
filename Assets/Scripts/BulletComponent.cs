using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	[RequireComponent(typeof(Rigidbody))]
	public class BulletComponent : MonoBehaviour
	{
		private Rigidbody m_body;
		[SerializeField] private float m_force = 15f;

		private void Awake()
		{
			m_body = GetComponent<Rigidbody>();
		}

		public void Shoot()
		{
			m_body.AddForce(transform.forward * m_force, ForceMode.Impulse);
		}

		private void OnCollisionEnter(Collision other)
		{
			Destroy(gameObject);
		}
	}
}