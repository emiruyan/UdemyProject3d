using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UdemyProject1t.Controllers
{
    public class WallController : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other) //iki nesne çarpışmasında oncollisionenter devreye girer.
        {
            PlayerController player = other.collider.GetComponent<PlayerController>(); // İki nesne çarpıştırdık. Bu iki nesneden birinde player controller var mı demiş olduk

            if (player !=null)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

}

