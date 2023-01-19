using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;


namespace TopDownShooter
{
	public class PlayerController : MonoBehaviour
	{
		private PlayerInputActions m_input;
		
		

		[SerializeField] private CinemachineVirtualCamera m_virtualCamera;

		private Character m_character;
		private AttackManager m_attackManager;

		private Vector2 m_move;
		

        private void Awake()
        {
			m_input = new PlayerInputActions();
			m_input.Player.Fire.performed += context => m_attackManager.Attack();
        }

        private void OnEnable()
		{
			m_input.Enable();
		}

		private void OnDisable()
		{
			m_input.Disable();
		}

		public void Init(Character character)
		{
			m_character = character;
			m_virtualCamera.Follow = character.transform;
			m_virtualCamera.LookAt = character.transform;
			m_attackManager = character.GetComponent<AttackManager>();
		}

		

		private void Update()
		{
			if (m_character)
			{
				m_move = m_input.Player.Move.ReadValue<Vector2>();
				Vector3 offset = new Vector3(m_move.x, 0f, m_move.y);
				m_character.Move(offset);

				if (m_move.x != 0f || m_move.y != 0f)
				{
					m_character.SetLook(offset);
				}


				
			}
		}
	}
}