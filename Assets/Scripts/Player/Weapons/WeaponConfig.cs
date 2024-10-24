using UnityEngine;

namespace MKubiak.RTETestTask.Weapons
{
    [CreateAssetMenu(menuName = "Weapons/WeaponConfig", fileName = "WeaponConfig")]
    public class WeaponConfig : ScriptableObject
    {
        [field: SerializeField] public int ID { get; private set; }
    }
}