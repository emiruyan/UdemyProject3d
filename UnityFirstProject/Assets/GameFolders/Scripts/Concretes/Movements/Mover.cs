using System.Collections;
using System.Collections.Generic;
using UdemyProject1t.Controllers;
using UnityEngine;

namespace  UdemyProject1.Movements
{
    public class Mover
    {
         Rigidbody _rigidbody;
         PlayerController _playerController;
         public Mover(PlayerController playerController)
         {
             _playerController = playerController;  
             _rigidbody = playerController.GetComponent<Rigidbody>();
         }

         public void FixedTick()
         {
             if (_rigidbody != null)
             {
                  _rigidbody.AddRelativeForce(Vector3.up * Time.deltaTime *_playerController.Force);
             }
            
         }
    }
}


