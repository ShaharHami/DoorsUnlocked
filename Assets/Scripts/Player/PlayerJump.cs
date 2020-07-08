using System;
using Managers;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerJump : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private JumpForceDisplay jumpForceDisplay;
        private float jumpForcePercentage;
        private float maxJumpForce;
        private int maxJumps;
        private int jumps;
        private PlayerMovement playerMovement;
        private float jumpLoadedForce;
        private bool grounded;

        private void Start()
        {
            playerMovement = GetComponent<PlayerMovement>();
            jumpLoadedForce = 0;
            jumps = 0;
            jumpForcePercentage = DataManager.Instance.jumpForcePercentage;
            maxJumpForce = DataManager.Instance.maxJumpForce;
            maxJumps = DataManager.Instance.maxJumps;
            jumpForceDisplay.UpdateJumpsRemainingDisplay(maxJumps - jumps);
        }

        private void OnCollisionEnter(Collision coll)
        {
            if (coll.collider.CompareTag("Ground"))
            {
                grounded = true;
                jumps = 0;
                jumpForceDisplay.UpdateJumpsRemainingDisplay(maxJumps - jumps);
            }
        }

        private void OnCollisionExit(Collision coll)
        {
            if (coll.collider.CompareTag("Ground"))
            {
                grounded = false;
            }
        }

        private void Update()
        {
            LoadJump();
        }

        private void LoadJump()
        {
            if (playerInput.GetJumpLoadInput())
            {
                if (jumpLoadedForce <= maxJumpForce && jumps < maxJumps)
                {
                    jumpLoadedForce += ((maxJumpForce / 100) * jumpForcePercentage);
                    jumpForceDisplay.UpdateForceDisplay(jumpLoadedForce, maxJumpForce);
                }
            }

            if (playerInput.GetJumpInput() && jumpLoadedForce > 0)
            {
                Jump();
            }
        }

        private void Jump()
        {
            if (jumps < maxJumps)
            {
                jumps += 1;
                playerMovement.jumpSpeed = jumpLoadedForce;
                jumpForceDisplay.UpdateJumpsRemainingDisplay(maxJumps - jumps);
            }

            jumpLoadedForce = 0;
            jumpForceDisplay.UpdateForceDisplay(jumpLoadedForce, maxJumpForce);
        }
    }
}