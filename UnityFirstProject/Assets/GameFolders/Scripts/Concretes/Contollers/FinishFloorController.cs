using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProject1.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UdemyProject1t.Controllers
{
    public class FinishFloorController : MonoBehaviour
    {
        [SerializeField] GameObject _finishFireWork; 
        [SerializeField] GameObject _finishLight;

        private void OnCollisionEnter(Collision other)
        {
            PlayerController player = other.collider.GetComponent<PlayerController>();
            
            if (player == null) return;
          
            if (other.GetContact(0).normal.y == -1)
                
            {
                _finishLight.gameObject.SetActive(true);
                _finishFireWork.gameObject.SetActive(true);
                GameManager.Instance.MissionSucced();
            }
            else
            {
                //Game Over
                GameManager.Instance.GameOver();
            }

        }
    }

}

