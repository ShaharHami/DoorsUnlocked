using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class MessageDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI messageDisplayText;
        [SerializeField] private GameObject messageDisplay;
        [SerializeField] private Button restartGameButton;
        [SerializeField] private Button restartLevelButton;
        [SerializeField] private Button quitGameButton;
        [SerializeField] private Button nextLevelButton;
        [SerializeField] private Button purchaseKeyButton;
        [SerializeField] private Button purchaseCoinsButton;
        public enum MessageType
        {
            Fail,
            Succeed,
            Lose,
            Win,
            Start,
            PurchaseKey,
            PurchaseCoins,
        }
        public MessageType messageType;
        public void UpdateMessageDisplay(string message)
        {
            messageDisplayText.text = message;
            UpdateMessageButtons();
        }

        public void UpdateMessageButtons()
        {
            restartGameButton.gameObject.SetActive(false);
            restartLevelButton.gameObject.SetActive(false);
            quitGameButton.gameObject.SetActive(false);
            nextLevelButton.gameObject.SetActive(false);
            purchaseKeyButton.gameObject.SetActive(false);
            purchaseCoinsButton.gameObject.SetActive(false);
            switch (messageType)
            {
                case MessageType.Fail:
                    restartLevelButton.gameObject.SetActive(true);
                    quitGameButton.gameObject.SetActive(true);
                    break;
                case MessageType.Succeed:
                    nextLevelButton.gameObject.SetActive(true);
                    quitGameButton.gameObject.SetActive(true);
                    break;
                case MessageType.Lose:
                    restartGameButton.gameObject.SetActive(true);
                    quitGameButton.gameObject.SetActive(true);
                    break;
                case MessageType.Win:
                    restartGameButton.gameObject.SetActive(true);
                    quitGameButton.gameObject.SetActive(true);
                    break;
                case MessageType.Start:
                    break;
                case MessageType.PurchaseKey:
                    if (DataManager.Instance.remainingLives > 0)
                    {
                        restartLevelButton.gameObject.SetActive(true);
                    }
                    else
                    {
                        restartGameButton.gameObject.SetActive(true);
                    }
                    purchaseKeyButton.gameObject.SetActive(true);
                    break;
                case MessageType.PurchaseCoins:
                    if (DataManager.Instance.remainingLives > 0)
                    {
                        restartLevelButton.gameObject.SetActive(true);
                    }
                    else
                    {
                        restartGameButton.gameObject.SetActive(true);
                    }
                    purchaseCoinsButton.gameObject.SetActive(true);
                    break;
                default:
                    break;
            }
        }
        public void ShowDisplay()
        {
            messageDisplay.SetActive(true);
        }
        public void HideDisplay()
        {
            messageDisplay.SetActive(false);
        }
    }
}
