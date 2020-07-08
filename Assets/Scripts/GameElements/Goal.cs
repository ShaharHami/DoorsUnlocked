using System;
using Managers;
using UnityEngine;

namespace GameElements
{
    public class Goal : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        private void OnTriggerEnter(Collider coll)
        {
            if (coll.CompareTag("Player"))
            {
                gameManager.LevelComplete();
            }
        }
    }
}
