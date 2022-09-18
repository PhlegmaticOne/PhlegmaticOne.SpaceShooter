using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField] private Rect _spawnBounds;
    [SerializeField] private List<GameObject> _bonusPrefabs;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);

            var randomIndex = Random.Range(0, _bonusPrefabs.Count);
            var random = _bonusPrefabs[randomIndex];

            var x = _spawnBounds.x + Random.Range(0, _spawnBounds.width);
            var y = _spawnBounds.y - Random.Range(0, _spawnBounds.y);

            Instantiate(random, transform);
            random.transform.position = new Vector2(x, y);
        }
    }
}
