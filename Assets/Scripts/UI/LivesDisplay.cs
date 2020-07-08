using TMPro;
using UnityEngine;

namespace UI
{
    public class LivesDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI livesDisplayText;

        public void UpdateLivesDisplay(int lives)
        {
            livesDisplayText.text = lives.ToString();
        }
    }
}
