using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProject1.Inputs;
using UdemyProject1.Managers;
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
        Fuel _fuel;
        
        bool _canMove; 
        bool _canForceUp; 
        float _leftRight;
       public float TurnSpeed => _turnSpeed;

       public float Force => _force;
       public bool CanMove => _canMove;


       private void Awake()
        {
             
            _input = new DefaultInput();
            _mover = new Mover(this);
            _rotator = new Rotator(this);
            _fuel = GetComponent<Fuel>();

        }

       private void Start()
       {
           _canMove = true;
       }

       private void OnEnable()
       {
           GameManager.Instance.OnGameOver += HandleOnEventTrigger;
           GameManager.Instance.OnMissionSucced += HandleOnEventTrigger;
       }

       

       private void OnDisable()
       {
           GameManager.Instance.OnGameOver -= HandleOnEventTrigger;
           GameManager.Instance.OnMissionSucced -= HandleOnEventTrigger;
       }

       private void Update() //inputları buradan alacağız. 
        { 
            if (!_canMove) return;
            
                
            
            
            if (_input.IsForceUp && !_fuel.IsEmpty) // eğer ki hem yukarı basıp hem fuelim boş olsa burası true olsun
            {
                _canForceUp = true; 
            }
            else //burası basmadığımız an olacak
            {
                _canForceUp = false;
                _fuel.FuelIncrease(0.01f);
            }

            _leftRight = _input.LeftRight;
        }
  
        private void FixedUpdate() //fixed updateda fizik işlemlerini yaparız
        {
            if (_canForceUp)
            {
                _mover.FixedTick();
                _fuel.FuelDecrease(0.2f);
                
            }  
            
            _rotator.FixedTick(_leftRight);
            
        }
        private void HandleOnEventTrigger() //kazandığımızda veya kaybettiğimizde bu bölüm çalışıyor
        {
            _canMove = false;
            _canForceUp = false;
            _leftRight = 0f;
            _fuel.FuelIncrease(0f);
        }
    }

}
