using System;
using Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Player
{
    [RequireComponent(typeof(PlayerJump))]
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;
        private float jumpLoadThreshold;
        // public JoystickType joystickType;

        private void Start()
        {
            jumpLoadThreshold = DataManager.Instance.jumpLoadThreshold;
            if (joystick.GetType() != typeof(VariableJoystick)) return;
            VariableJoystick jStick = joystick as VariableJoystick;
            if (jStick != null) jStick.SetMode(DataManager.Instance.joystickType);
        }

        public float GetHorizontalInput()
        {
            return joystick.Horizontal + Input.GetAxis("Horizontal");
        }

        private float GetVerticalInput()
        {
            return joystick.Vertical + Input.GetAxis("Vertical");
        }


        private static bool GetButtonJumpInput()
        {
            return Input.GetButtonUp("Jump");
        }

        private bool GetTouchJumpInput()
        {
            if (Input.touchCount <= 0) return false;
            Touch touch = Input.GetTouch(0);
            return touch.phase == TouchPhase.Ended;
        }
        
        public bool GetJumpLoadInput()
        {
            return Input.GetButton("Jump") || GetVerticalInput() < -jumpLoadThreshold;
        }

        public bool GetJumpInput()
        {
            return GetButtonJumpInput() || GetTouchJumpInput() || GetVerticalInput() > 0;
        }
    }
}
