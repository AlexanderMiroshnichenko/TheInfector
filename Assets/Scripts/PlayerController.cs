using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace TopDownShooter
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private InputActionReference m_moveActionRef;
		[SerializeField] private InputActionReference m_attackActionRef;
		[SerializeField] private CinemachineVirtualCamera m_virtualCamera;

		private Character m_character;
		private AttackManager m_attackManager;

		private Vector2 m_move;
		private InputAction m_moveAction => m_moveActionRef.action;
		private InputAction m_attackAction => m_attackActionRef.action;

		private void OnEnable()
		{
			m_moveAction.Enable();
			m_attackAction.Enable();
		}

		private void OnDisable()
		{
			m_moveAction.Disable();
			m_attackAction.Disable();
		}

		public void Init(Character character)
		{
			m_character = character;
			m_virtualCamera.Follow = character.transform;
			m_attackManager = character.GetComponent<AttackManager>();
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
				m_character.Move(offset);

				if (m_move.x != 0f || m_move.y != 0f)
				{
					m_character.SetLook(offset);
				}


				if (m_attackAction.WasPerformedThisFrame())
				{
					m_attackManager.Attack();
				}
			}
		}
	}
}