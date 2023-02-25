using UnityEngine;

[CreateAssetMenu(fileName = "New Teleport Data", menuName = "Teleports/New Teleport Data")]
public class TeleportData : ScriptableObject
{
    [SerializeField] private AudioClip clip;
}
