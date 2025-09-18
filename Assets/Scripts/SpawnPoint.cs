using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private BotType _botType;

    public Transform Target => _target;
    public BotType BotType => _botType;
}
