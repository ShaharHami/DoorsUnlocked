using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class CountDownDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI countDownDisplayText;
        [SerializeField] private GameObject countDownDisplay;

        private void Start()
        {
            countDownDisplayText.gameObject.SetActive(true);
        }

        public void UpdateCountDownDisplay(int count)
        {
            countDownDisplayText.text = count.ToString();
        }

        public void EndCountDown()
        {
            countDownDisplay.gameObject.SetActive(false);
        }
    }
}
