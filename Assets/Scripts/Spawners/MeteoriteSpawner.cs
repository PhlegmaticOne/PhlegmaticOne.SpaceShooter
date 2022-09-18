using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{
    [SerializeField] private Vector2 _spawnLine;
    [SerializeField] private List<GameObject> _meteorPrefabs;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {

            var randomIndex = Random.Range(0, _meteorPrefabs.Count);
            var random = _meteorPrefabs[randomIndex];
            var y = transform.position.y;
            var x = Random.Range(_spawnLine.x, _spawnLine.y);
            Instantiate(random, transform);
            random.transform.position = new Vector2(x, y);

            yield return new WaitForSeconds(4);
        }
    }
}
