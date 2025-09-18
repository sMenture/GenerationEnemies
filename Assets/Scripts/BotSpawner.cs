using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spawnPoint = new List<GameObject>();
    [SerializeField] private BotMover _botPrefab;
    private float _spawnDelay = 2;

    private void Awake()
    {
        StartCoroutine(BotSpawnWithDelay());
    }

    private IEnumerator BotSpawnWithDelay()
    {
        var wait = new WaitForSeconds(_spawnDelay);

        while (enabled)
        {
            CreateBot();
            yield return wait;
        }
    }

    private void CreateBot()
    {
        BotMover newBot = Instantiate(_botPrefab, transform);
        Vector3 spawnPosition = GiveRandomSpawnPosition();
        Vector3 nextPosition = Vector3.zero;

        do
        {
            nextPosition = GiveRandomSpawnPosition();

        } while (spawnPosition == nextPosition);

        newBot.transform.position = spawnPosition;
        newBot.MoveToPoint(nextPosition);
    }

    private Vector3 GiveRandomSpawnPosition()
    {
        return _spawnPoint[UserUtility.GetRandomValue(0, _spawnPoint.Count - 1)].transform.position;
    }
}

