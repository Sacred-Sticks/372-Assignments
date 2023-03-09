using SOLID.Events;
using UnityEngine;

namespace SOLID.DataSending
{
    public abstract class Sender : MonoBehaviour
    {
        [SerializeField] protected EventLinker eventTarget;
    }
}
