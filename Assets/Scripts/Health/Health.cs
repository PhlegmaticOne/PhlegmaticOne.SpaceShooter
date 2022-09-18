using System;
using AssemblyCSharp.Assets.Scripts.Interfaces;
using JetBrains.Annotations;
using UnityEngine;

namespace AssemblyCSharp.Assets.Health
{
    public class Health : MonoBehaviour
    {
        private float _health;
        private bool _isImmortal;

        [SerializeField] private float _maxHealth;
        [CanBeNull] public event EventHandler<float> HealthChanged; 
        void Start()
        {
            _health = _maxHealth;
            InvokeHealthChanged();
        }

        public float GetHealth() => _health;
        public void TakeDamage(float damage)
        {
            if(_isImmortal) return;

            _health -= damage;
            if (_health >= 0)
            {
                InvokeHealthChanged();
            }
            if (_health <= 0 && TryGetComponent(out IDestroyable destroyable))
            {
                destroyable.Destroy();
            }
        }

        public void SetImmortality(float time)
        {
            _isImmortal = true;
            Invoke(nameof(ReturnMortality), time);
        }

        private void ReturnMortality() => _isImmortal = false;

        private void InvokeHealthChanged() => HealthChanged?.Invoke(this, _health);
    }
}
