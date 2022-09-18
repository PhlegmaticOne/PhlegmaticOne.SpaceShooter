using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.Spawners
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _enemyPrefabs;
        [SerializeField] private Vector2 _spawnYRange;
        void Start()
        {
            StartCoroutine(Spawn());
        }

        IEnumerator Spawn()
        {
            while (true)
            {
                var randomIndex = Random.Range(0, _enemyPrefabs.Count);
                var random = _enemyPrefabs[randomIndex];
                var x = transform.position.x;
                var y = Random.Range(_spawnYRange.x, _spawnYRange.y);
                Instantiate(random, transform);
                random.transform.position = new Vector2(x, y);
                yield return new WaitForSeconds(6);
            }
        }
    }
}
