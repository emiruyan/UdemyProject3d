using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UdemyProject1.Managers
{
    public class GameManager : MonoBehaviour
    {
        public event System.Action OnGameOver;
        public event System.Action OnMissionSucced;
        
        public static GameManager Instance { get; private set; }
        
        private void Awake()
        {
            SingletonThisGameObject();
            
        }

        private void SingletonThisGameObject()
        {
            if (Instance == null)
            {
                Instance = this;
                
                DontDestroyOnLoad(this.gameObject);
                
            }
            else
            {   
                Destroy(this.gameObject);
            }
        }

        public void GameOver()
        {
            OnGameOver?.Invoke();
        }

        public void MissionSucced()
        {
            OnMissionSucced?.Invoke();
        }

        public void LoadLevelScene(int levelIndex = 0) //UI, Button Clicklerde bunu çağıracağız
        {
            StartCoroutine(LoadLevelSceneAsync(levelIndex)); //Coroutine methodlar diğer methodlardan aykırı bir şekilde çalışbiliryor.
            //coroutine method (async) çalışırken diğer methodlarımızda çalışabiliyor.
        }

        private IEnumerator LoadLevelSceneAsync(int levelIndex) // Arka planda bu çalışacak
        {
            yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + levelIndex); //Yield Return mantığı yukarıdaki işlem bitene kadar burda ki işlem beklemek zorunda
        }

        public void LoadMenuScene()
        {
            StartCoroutine(LoadLevelSceneAsync());
        }

        private IEnumerator LoadLevelSceneAsync()
        {
            yield return SceneManager.LoadSceneAsync("Menu");
        }

        public void Exit()
        {
            Debug.Log("Exit process on triggered");
            Application.Quit();
        }
    }

}

