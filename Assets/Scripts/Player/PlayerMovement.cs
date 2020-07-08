using Managers;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [HideInInspector] public float speed;
        [SerializeField] private GameManager gameManager;
        [SerializeField] private PlayerInput playerInput;
        private Rigidbody rb;
        private Vector3 move;
        public float jumpSpeed { get; set; }
        private void Start()
        {
            speed = DataManager.Instance.speed;
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (!gameManager.startGame) return;
                rb.AddForce(Physics.gravity * DataManager.Instance.gravityMultiplier, ForceMode.Acceleration);
            if (rb.velocity.y <= -DataManager.Instance.fallThreshold)
            {
                gameManager.LevelFailed();
            }
            move = new Vector3(
                playerInput.GetHorizontalInput() * DataManager.Instance.lateralSpeed * Time.fixedDeltaTime,
                rb.velocity.y + jumpSpeed * Time.fixedDeltaTime,
                speed * Time.fixedDeltaTime
            );
            rb.velocity = move;
            jumpSpeed = 0;
        }
    }
}
