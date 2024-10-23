using UnityEngine;

namespace MKubiak.RTETestTask.InteractionSystem
{
    [CreateAssetMenu(menuName = "InteractionSystem/InteractionRuntimeSet", fileName = "InteractionsRuntimeSet")]
    public class InteractionsRuntimeSet : RuntimeSet<IInteractable>
    {
    }
}