using Collectibles;
using Doors;
using Keys;
using UI;
using UnityEngine;

namespace Managers
{
    public class EconomyManager : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private KeyHolder keyHolder;
        [SerializeField] private MessageDisplay messageDisplay;
        [SerializeField] private Wallet wallet;
        private Key.KeyType keyType;
        private int coinsToPurchase;
        private Door currentDoor;

        public void OfferPurchaseKey(Door door)
        {
            gameManager.PauseGame();
            DataManager.Instance.purchasing = true;
            currentDoor = door;
            keyType = door.GetKeyType();
            messageDisplay.messageType = MessageDisplay.MessageType.PurchaseKey;
            messageDisplay.UpdateMessageDisplay(DataManager.Instance.purchaseKeyMessage1 + keyType + 
                                                DataManager.Instance.purchaseKeyMessage2 + DataManager.Instance.keyPrice + 
                                                DataManager.Instance.purchaseKeyMessage3);
            messageDisplay.ShowDisplay();
        }
        public void PurchaseKey()
        {
            if (DataManager.Instance.coins >= DataManager.Instance.keyPrice)
            {
                wallet.SpendCoins(DataManager.Instance.keyPrice);
                keyHolder.AddKey(keyType);
                currentDoor.OpenDoor();
                gameManager.ResumeGame();
                messageDisplay.HideDisplay();
                keyHolder.RemoveKey(keyType);
                DataManager.Instance.purchasing = false;
            }
            else
            {
                OfferPurchaseCoins(DataManager.Instance.keyPrice - DataManager.Instance.coins);
            }
        }
        private void OfferPurchaseCoins(int qty)
        {
            coinsToPurchase = qty;
            messageDisplay.messageType = MessageDisplay.MessageType.PurchaseCoins;
            var price = qty * DataManager.Instance.coinPrice;
            messageDisplay.UpdateMessageDisplay(DataManager.Instance.purchaseCoinsMessage + qty + DataManager.Instance.purchaseCoinsCostMessage + price + "$?");
            messageDisplay.ShowDisplay();
        }

        public void PurchaseCoins()
        {
            DataManager.Instance.coins += coinsToPurchase;
            messageDisplay.HideDisplay();
            PurchaseKey();
        }
    }
}
