using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProject1t.Abstract.Controllers;
using UnityEngine;

namespace UdemyProject1.Controllers
{
    public class MoverWallController : WallController
    {

        [SerializeField] Vector3 _direction;  //nesnemiz yukarı yönde ilerleyip orijinal yerine geri dönecek
       // [Range(0f,1f)] //range komutu ile sınır koyuyoruz. Float faktörümüz 0 ve 1 arasında gidiek demek oluıyor.  
        [SerializeField] float _factor;
        [SerializeField] float _speed = 1f; 

        Vector3 _startPosition; //orijinal transgform tanımladık
        const float FULL_CIRCLE = Mathf.PI * 2F;                              //Const komutu değiştirelemeyen anlamına gelir.Ona bir değer atıyoruz ve değiştirelmiyor.

        private void Awake()
        {
            _startPosition = transform.position;
        } 

        private void Update()
        {
            float cycle = Time.time / _speed;
            float sinWave = Mathf.Sin(cycle * FULL_CIRCLE);

            _factor = Mathf.Abs((sinWave));

 
            Vector3 offset = _direction * _factor;
            transform.position = offset + _startPosition;



        }
    }
}


