using TMPro;
using UnityEngine;

namespace UI
{
    public class CoinsDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coinsText;

        public void UpdateCoinsDisplay(int coins)
        {
            coinsText.text = coins.ToString();
        }
    }
}
