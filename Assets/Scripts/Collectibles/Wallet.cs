using System;
using Managers;
using UI;
using UnityEngine;

namespace Collectibles
{
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private CoinsDisplay coinsDisplay;

        private void Start()
        {
            coinsDisplay.UpdateCoinsDisplay(DataManager.Instance.coins);
        }

        private void OnTriggerEnter(Collider coll)
        {
            Coin coin = coll.GetComponent<Coin>(); 
            if (coin != null)
            {
                DataManager.Instance.coins += coin.value;
                coin.gameObject.SetActive(false);
                coinsDisplay.UpdateCoinsDisplay(DataManager.Instance.coins);
            }
        }

        public void ResetWallet()
        {
            DataManager.Instance.coins = 0;
        }
        public void SpendCoins(int spentCoins)
        {
            DataManager.Instance.coins -= spentCoins;
            coinsDisplay.UpdateCoinsDisplay(DataManager.Instance.coins);
        }
    }
}
