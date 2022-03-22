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
        [SerializeField] float _turnSpeed = 10f;

        [SerializeField] float _force = 55f;
        //sseriliaze field yapmamızın amacı hem private hem inspectordan erişebiliyoruz.Public yapsakta erişebiliridk ancak genelde private kullanmalıyız.
        
        
        DefaultInput _input;
        Mover _mover;
        Rotator _rotator;
        

       bool _isForceUp; 
       float _leftRight;
       public float TurnSpeed => _turnSpeed;

       public float Force => _force;
       

       private void Awake()
        {
             
            _input = new DefaultInput();
            _mover = new Mover(this);
            _rotator = new Rotator(this);

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

            _leftRight = _input.LeftRight;
        }
 
        private void FixedUpdate() //fixed updateda fizik işlemlerini yaparız
        {
            if (_isForceUp)
            {
                _mover.FixedTick();
                
            }  
            
            _rotator.FixedTick(_leftRight);
            
        }
    }

}
