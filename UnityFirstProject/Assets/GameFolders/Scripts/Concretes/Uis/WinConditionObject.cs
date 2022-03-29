using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProject1.Managers;
using UnityEngine;

namespace UdemyProject1.Uis
{
    public class WinConditionObject : MonoBehaviour
    {
        [SerializeField] private GameObject _winConditionPanel;

        private void Awake()
        {
            if (_winConditionPanel.activeSelf)
            {
                _winConditionPanel.SetActive(false);
            }

        }

        private void OnEnable()
        {
            
            GameManager.Instance.OnMissionSucced += HandleOnMissionSucced;
        }

       

        private void OnDisable()
        {
            GameManager.Instance.OnMissionSucced -= HandleOnMissionSucced;
        }
        
        private void HandleOnMissionSucced()
        {
            if (!_winConditionPanel.activeSelf)
            {
                _winConditionPanel.SetActive(true);
            }
        }

        
    }
    
        
}


