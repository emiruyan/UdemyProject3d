using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject1.Movements
{
    public class Fuel : MonoBehaviour
    {
        [SerializeField] float _maxFuel = 100f; //fuelimizin alabileceği maksimum kapasite   
        [SerializeField] float _currentFuel; // o an ki yakıtımız
        [SerializeField] ParticleSystem _particle;

        public bool IsEmpty => _currentFuel < 1f; //yakıt kalmamışsa gibi düşünebiliriz.       
        public float CurrentFuel => _currentFuel / _maxFuel;
        
        private void Awake()
        {
            _currentFuel = _maxFuel;
        }

        public void FuelIncrease(float increase) //increase artıştır.
        {
            _currentFuel += increase; // bu sürekli artmaya çalışacak   
            _currentFuel = Mathf.Min(_currentFuel, _maxFuel);  //Mathf komutu unitynin bizim için oluşturduğu matematik formulüdür. Bu iki değerden düşük olanını al deriz

            if (_particle.isPlaying)
            {
                _particle.Stop();
            }
        }

        public void FuelDecrease(float decrease)
        {
            _currentFuel -= decrease;
            _currentFuel = Mathf.Max(_currentFuel, 0f);

            if (_particle.isStopped)
            {
                _particle.Play();
            }
        }
    }

}

