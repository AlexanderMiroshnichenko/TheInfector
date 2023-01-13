using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	[RequireComponent(typeof(CharacterController))]
	public class Character : MonoBehaviour
	{
		private CharacterController m_characterController;
		[SerializeField] private float m_speed = 5f;

		private void Awake()
		{
			m_characterController = GetComponent<CharacterController>();
		}

		public void Move(Vector3 dir)
		{
			m_characterController.SimpleMove(dir * m_speed);

		}

		public void SetLook(Vector3 dir)
		{
			transform.rotation = Quaternion.Euler(0f, Mathf.Atan2(-dir.z, dir.x) * Mathf.Rad2Deg + 90f, 0f);
		}
	}
}