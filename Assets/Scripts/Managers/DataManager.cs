using UnityEngine;
using UnityEngine.Serialization;

namespace Managers
{
    public class DataManager : MonoBehaviour
    {
        private static DataManager instance;
        public static DataManager Instance => instance;
        [Header("Game Management")]
        public int lives;
        public int remainingLives;
        public int countDown;
        [HideInInspector] public bool freshGame;
        [Header("Wallet")] 
        public int coins;
        public int keyPrice;
        public float coinPrice;
        [HideInInspector] public bool purchasing;
        [Header("Player Movement")] 
        public float initialSpeed;
        public float speed;
        public float lateralSpeed;
        public float fallThreshold;
        public float gravityMultiplier;
        public JoystickType joystickType;
        [Header("Player Jumping")]
        public float jumpForcePercentage;
        public float maxJumpForce;
        public int maxJumps;
        public float jumpLoadThreshold;
        [Header("Messages")] 
        public string failMessage;
        public string successMessage;
        public string winMessage;
        public string loseMessage;
        public string startGameMessage;
        public string purchaseKeyMessage1;
        public string purchaseKeyMessage2;
        public string purchaseKeyMessage3;
        public string purchaseCoinsMessage;
        public string purchaseCoinsCostMessage;

        private void Awake()
        {
            freshGame = true;
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
