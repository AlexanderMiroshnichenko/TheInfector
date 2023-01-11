using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	[RequireComponent(typeof(CharacterController))]
	public class Character : MonoBehaviour
	{
		private CharacterController m_characterController;

		private void Awake()
		{
			m_characterController = GetComponent<CharacterController>();
		}

		public void Move(Vector3 offset)
		{
			m_characterController.Move(offset);
		}
	}
}