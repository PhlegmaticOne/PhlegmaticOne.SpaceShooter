using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.Attacking
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] private GameObject _bullet;
        [SerializeField] private float _attackTime;
        [SerializeField] private float _bulletSpawnOffset;
        private float _currentAttackTime;
        private bool _canAttack;
        private GameObject _newBullet;
        private float _defaultAttackTime;
        void Start()
        {
            _currentAttackTime = _attackTime;
            _defaultAttackTime = _attackTime;
        }

        public void UpdateTime()
        {
            _attackTime += Time.deltaTime;
            if (_attackTime > _currentAttackTime)
            {
                _canAttack = true;
            }
        }

        public void TryShoot()
        {
            if (_canAttack)
            {
                _canAttack = false;
                _attackTime = 0;
                var position = new Vector3(transform.position.x + _bulletSpawnOffset, transform.position.y);

                Instantiate(_newBullet ?? _bullet, 
                    position, Quaternion.AngleAxis(90, Vector3.back));
            }
        }

        public void SetNewBullet(GameObject bulletPrefab, float attackTime, float time)
        {
            _newBullet = bulletPrefab;
            _currentAttackTime = attackTime;
            Invoke(nameof(ReturnDefaultBullet), time);
        }

        private void ReturnDefaultBullet()
        {
            _newBullet = null;
            _currentAttackTime = _defaultAttackTime;
        }
    }
}
