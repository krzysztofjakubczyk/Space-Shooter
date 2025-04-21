using UnityEngine;

[CreateAssetMenu(fileName = "Object Data", menuName = "Data/EnemyData")]
public class AiScriptable : ScriptableObject
{
    [SerializeField]
    public int health = 5;
    [SerializeField]
    [Range(1, 5)]
    public float speed;
    [SerializeField]
    public int spawnTimer;
    [SerializeField]
    public int iloscMonet;
    [Range(1,5)]
    public float shootTime;
}
