using System;
using System.Collections;
using Collectibles;
using Player;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private SpeedDisplay speedDisplay;
        [SerializeField] private CountDownDisplay countDownDisplay;
        [SerializeField] private LivesDisplay livesDisplay;
        [SerializeField] private MessageDisplay messageDisplay;
        [SerializeField] private Wallet wallet;
        [HideInInspector] public bool startGame = false;
        private int countDown;
        private Coroutine speedIncreaseCoroutine, countDownCoroutine;
        private int remainingLives;

        private void Awake()
        {
            Application.targetFrameRate = 60;
        }

        private void Start()
        {
            InitializeLevel();
        }

        private void InitializeLevel()
        {
            ResumeGame();
            countDown = DataManager.Instance.countDown;
            if (DataManager.Instance.freshGame)
            {
                DataManager.Instance.speed = DataManager.Instance.initialSpeed;
                DataManager.Instance.remainingLives = DataManager.Instance.lives;
            }
            livesDisplay.UpdateLivesDisplay(DataManager.Instance.remainingLives);
            messageDisplay.messageType = MessageDisplay.MessageType.Start;
            messageDisplay.UpdateMessageDisplay(DataManager.Instance.startGameMessage);
            messageDisplay.ShowDisplay();
            startGame = false;
            countDownCoroutine = StartCoroutine(CountDown());
        }

        private IEnumerator CountDown()
        {
            for (int i = countDown; i > 0; i--)
            {
                countDownDisplay.UpdateCountDownDisplay(i);
                yield return new WaitForSeconds(1f);
            }

            countDownDisplay.EndCountDown();
            messageDisplay.HideDisplay();
            startGame = true;
            speedIncreaseCoroutine = StartCoroutine(IncreaseSpeed());
        }

        private IEnumerator IncreaseSpeed()
        {
            if (countDownCoroutine != null)
            {
                StopCoroutine(countDownCoroutine);
            }

            speedDisplay.UpdateDisplay(playerMovement.speed);
            while (true)
            {
                yield return new WaitForSeconds(DataManager.Instance.speedIncreaseInterval);
                playerMovement.speed += DataManager.Instance.speedIncreaseAmount;
                speedDisplay.UpdateDisplay(playerMovement.speed);
            }
        }

        public void LevelComplete()
        {
            PauseGame();
            if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings-1)
            {
                DataManager.Instance.speed = playerMovement.speed;
                messageDisplay.messageType = MessageDisplay.MessageType.Succeed;
                messageDisplay.UpdateMessageDisplay(DataManager.Instance.successMessage);
                messageDisplay.ShowDisplay();
            }
            else
            {
                GameOver(true);
            }
        }

        public void LevelFailed()
        {
            PauseGame();
            if (speedIncreaseCoroutine != null)
            {
                StopCoroutine(speedIncreaseCoroutine);
            }

            DataManager.Instance.remainingLives--;
            livesDisplay.UpdateLivesDisplay(DataManager.Instance.remainingLives);
            if (DataManager.Instance.remainingLives > 0)
            {
                messageDisplay.messageType = MessageDisplay.MessageType.Fail;
                messageDisplay.UpdateMessageDisplay(DataManager.Instance.failMessage);
                messageDisplay.ShowDisplay();
            }
            else
            {
                GameOver(false);
            }
        }

        private void GameOver(bool win)
        {
            PauseGame();
            startGame = false;
            if (win)
            {
                messageDisplay.messageType = MessageDisplay.MessageType.Win;
                messageDisplay.UpdateMessageDisplay(DataManager.Instance.winMessage);
            }
            else
            {
                messageDisplay.messageType = MessageDisplay.MessageType.Lose;
                messageDisplay.UpdateMessageDisplay(DataManager.Instance.loseMessage);
            }

            messageDisplay.ShowDisplay();
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
        }

        public void RestartLevel()
        {
            if (DataManager.Instance.purchasing)
            {
                DataManager.Instance.remainingLives--;
                DataManager.Instance.purchasing = false;
            }
            else
            {
                wallet.ResetWallet();
            }

            DataManager.Instance.freshGame = false;
            messageDisplay.HideDisplay();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void NextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void RestartGame()
        {
            DataManager.Instance.freshGame = true;
            DataManager.Instance.remainingLives = DataManager.Instance.lives;
            wallet.ResetWallet();
            SceneManager.LoadScene(0);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}