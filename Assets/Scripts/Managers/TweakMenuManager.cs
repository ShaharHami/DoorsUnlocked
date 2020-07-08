using System;
using Player;
using TMPro;
using UI;
using UnityEngine;

namespace Managers
{
    public class TweakMenuManager : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private GameObject tweakMenuGameObject;
        [SerializeField] private TMP_Dropdown joystickTypeDropdown;
        [SerializeField] private TMP_InputField lives;
        [SerializeField] private TMP_InputField countDown;
        [SerializeField] private TMP_InputField coins;
        [SerializeField] private TMP_InputField keyPrice;
        [SerializeField] private TMP_InputField coinPrice;
        [SerializeField] private TMP_InputField initialSpeed;
        [SerializeField] private TMP_InputField lateralSpeed;
        [SerializeField] private TMP_InputField fallThreshold;
        [SerializeField] private TMP_InputField gravityMultiplier;
        [SerializeField] private TMP_InputField jumpForcePercentage;
        [SerializeField] private TMP_InputField maxJumpForce;
        [SerializeField] private TMP_InputField maxJumps;
        [SerializeField] private TMP_InputField jumpLoadThreshold;
        private DataManager dataManager;

        private void Start()
        {
            tweakMenuGameObject.SetActive(false);
            dataManager = DataManager.Instance;
            InitializeFieldValues();
        }

        private void InitializeFieldValues()
        {
            joystickTypeDropdown.value = (int) dataManager.joystickType;
            lives.text = dataManager.lives.ToString();
            countDown.text = dataManager.countDown.ToString();
            coins.text = dataManager.coins.ToString();
            keyPrice.text = dataManager.keyPrice.ToString();
            coinPrice.text = dataManager.coinPrice.ToString();
            initialSpeed.text = dataManager.initialSpeed.ToString();
            lateralSpeed.text = dataManager.lateralSpeed.ToString();
            fallThreshold.text = dataManager.fallThreshold.ToString();
            gravityMultiplier.text = dataManager.gravityMultiplier.ToString();
            jumpForcePercentage.text = dataManager.jumpForcePercentage.ToString();
            maxJumpForce.text = dataManager.maxJumpForce.ToString();
            maxJumps.text = dataManager.maxJumps.ToString();
            jumpLoadThreshold.text = dataManager.jumpLoadThreshold.ToString();
        }
        public void OpenTweakMenu()
        {
            gameManager.PauseGame();
            tweakMenuGameObject.SetActive(true);
        }

        public void CloseTweakMenu()
        {
            tweakMenuGameObject.SetActive(false);
            gameManager.ResumeGame();
        }
        public void SetJoystick(int selection)
        {
            dataManager.joystickType = (JoystickType) selection;
        }
        
        private void ApplyChanges()
        {
            if (!string.IsNullOrEmpty(lives.text))
            {
                dataManager.lives = dataManager.remainingLives = int.Parse(lives.text);
            }
            if (!string.IsNullOrEmpty(countDown.text))
            {
                dataManager.countDown = int.Parse(countDown.text);
            }
            if (!string.IsNullOrEmpty(coins.text))
            {
                dataManager.coins = int.Parse(coins.text);
            }
            if (!string.IsNullOrEmpty(keyPrice.text))
            {
                dataManager.keyPrice = int.Parse(keyPrice.text);
            }
            if (!string.IsNullOrEmpty(coinPrice.text))
            {
                dataManager.coinPrice = float.Parse(coinPrice.text);
            }
            if (!string.IsNullOrEmpty(initialSpeed.text))
            {
                dataManager.initialSpeed = float.Parse(initialSpeed.text);
            }
            if (!string.IsNullOrEmpty(lateralSpeed.text))
            {
                dataManager.lateralSpeed = float.Parse(lateralSpeed.text);
            }
            if (!string.IsNullOrEmpty(fallThreshold.text))
            {
                dataManager.fallThreshold = float.Parse(fallThreshold.text);
            }
            if (!string.IsNullOrEmpty(gravityMultiplier.text))
            {
                dataManager.gravityMultiplier = float.Parse(gravityMultiplier.text);
            }
            if (!string.IsNullOrEmpty(jumpForcePercentage.text))
            {
                dataManager.jumpForcePercentage = float.Parse(jumpForcePercentage.text);
            }
            if (!string.IsNullOrEmpty(maxJumpForce.text))
            {
                dataManager.maxJumpForce = float.Parse(maxJumpForce.text);
            }
            if (!string.IsNullOrEmpty(maxJumps.text))
            {
                dataManager.maxJumps = int.Parse(maxJumps.text);
            }
            if (!string.IsNullOrEmpty(jumpLoadThreshold.text))
            {
                dataManager.jumpLoadThreshold = float.Parse(jumpLoadThreshold.text);
            }
            tweakMenuGameObject.SetActive(false);
        }

        public void ApplyAndRestartLevel()
        {
            ApplyChanges();
            gameManager.RestartLevel();
        }
        public void ApplyAndRestartGame()
        {
            ApplyChanges();
            gameManager.RestartGame();
        }
    }
}
