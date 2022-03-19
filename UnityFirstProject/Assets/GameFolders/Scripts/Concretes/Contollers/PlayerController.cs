using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProject1.Inputs;
using UdemyProject1.Movements;
using UnityEngine;


namespace  UdemyProject1t.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        
        //sseriliaze field yapmamızın amacı hem private hem inspectordan erişebiliyoruz.Public yapsakta erişebiliridk ancak genelde private kullanmalıyız.
        
        
        DefaultInput _input;
        Mover _mover;

       bool _isForceUp;

        private void Awake()
        {
            
            _input = new DefaultInput();
            _mover = new Mover(GetComponent<Rigidbody>());

        }


        private void Update() //inputları buradan alacağız.
        {
            if (_input.IsForceUp)
            {
                _isForceUp = true;
            }
            else
            {
                _isForceUp = false;
            }
            
            
        }
 
        private void FixedUpdate() //fixed updateda fizik işlemlerini yaparız
        {
            if (_isForceUp)
            {
                _mover.FixedTick();
                
            }  
        }
    }

}
