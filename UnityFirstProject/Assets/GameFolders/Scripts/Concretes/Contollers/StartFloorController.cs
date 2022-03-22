using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject1t.Controllers
{
    public class StartFloorController : MonoBehaviour
    {
        private void OnCollisionExit(Collision other) //bir nesnemiz diğerine dokunmayı bıraktığında devreye girecek.
        //yani bu durumda roketimiz start floordan ayrıldığında devreye giriyor.
        {
            {
                PlayerController player = other.collider.GetComponent<PlayerController>();

                if (player != null)
                {
                    Destroy((this.gameObject));
                }
            }
        }
    }

}

