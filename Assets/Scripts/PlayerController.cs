using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace TopDownShooter
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField]
		private InputActionReference m_moveActionRef;

		[SerializeField]
		private Character m_character;
		[SerializeField]
		private float m_speed = 10f;

		private Vector2 m_move;
		private InputAction m_moveAction;

		private void Awake()
		{
			m_moveAction = m_moveActionRef.action;
		}

		private void OnEnable()
		{
			m_moveAction.Enable();
		}

		private void OnDisable()
		{
			m_moveAction.Disable();
		}

		public void Init(Character character)
		{
			m_character = character;
		}

		public void OnMove(CallbackContext context)
		{
			m_move = context.ReadValue<Vector2>();
		}

		private void Update()
		{
			if (m_character)
			{
				m_move = m_moveAction.ReadValue<Vector2>();
				Vector3 offset = new Vector3(m_move.x, 0f, m_move.y);
				m_character.Move(offset * m_speed * Time.deltaTime);
			}
		}
	}
}