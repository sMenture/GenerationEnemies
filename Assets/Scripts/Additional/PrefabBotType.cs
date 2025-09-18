using UnityEngine;

[System.Serializable]
public struct PrefabBotType
{
    [SerializeField] private BotMover _botMover;
    [SerializeField] private BotType _botType;

    public BotMover BotMover => _botMover;
    public BotType BotType => _botType;
}
