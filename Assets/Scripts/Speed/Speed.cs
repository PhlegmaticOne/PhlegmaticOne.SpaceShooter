using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.Speed
{
    public class Speed : MonoBehaviour
    {
        private List<float> _speedHistory;
        [SerializeField] private float _speed;
        [CanBeNull] public event EventHandler<float> SpeedChanged;
        void Start()
        {
            _speedHistory = new List<float>();
        }

        public float GetSpeed() => _speed;
        public void ChangeSpeed(float speed, float actTime)
        {
            _speedHistory.Add(_speed);
            _speed += speed;
            InvokeOnSpeedChanged();
            Invoke(nameof(ReturnSpeed), actTime);
        }

        private void ReturnSpeed()
        {
            var speed = _speedHistory.First();
            _speedHistory.Remove(speed);
            _speed = speed;
            InvokeOnSpeedChanged();
        }

        private void InvokeOnSpeedChanged() => SpeedChanged?.Invoke(this, _speed);
    }
}
