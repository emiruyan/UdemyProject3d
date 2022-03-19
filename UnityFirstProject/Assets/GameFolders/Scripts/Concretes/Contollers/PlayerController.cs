using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProject1.Inputs;
using UnityEngine;

namespace  UdemyProject1t.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]  float _force;  
        //sseriliaze field yapmamızın amacı hem private hem inspectordan erişebiliyoruz.Public yapsakta erişebiliridk ancak genelde private kullanmalıyız.
        
        Rigidbody _rigidbody;
        DefaultInput _input;

       bool _isForceUp;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _input = new DefaultInput();

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
                _rigidbody.AddForce(Vector3.up * Time.deltaTime * _force); //bu kod ile yukarı doğru bir kuvvet vermiş, itmiş oluyoruz
            }  
        }
    }

}
