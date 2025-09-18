using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BotSpawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints = new List<SpawnPoint>();
    [SerializeField] private PrefabBotType[] _botType;
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
        SpawnPoint spawnPosition = GiveRandomSpawnPosition();

        BotMover newBot = Instantiate(_botType.First(bot => bot.BotType == spawnPosition.BotType).BotMover, transform);

        newBot.transform.position = spawnPosition.transform.position;
        newBot.MoveToPoint(spawnPosition.Target.position);
    }

    private SpawnPoint GiveRandomSpawnPosition()
    {
        return _spawnPoints[Random.Range(0, _spawnPoints.Count)];
    }
}

