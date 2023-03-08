using System;
using UnityEngine;

namespace SOLID.Events
{
    [CreateAssetMenu(fileName = "Event Object", menuName = "Events/Link Object")]
    public class EventLinker : ScriptableObject
    {
        public delegate void ChainEvent(object sender, EventArgs e);

        public event ChainEvent ChainedEvent;
        
        public void CallChainedEvent(object sender, EventArgs e)
        {
            ChainedEvent?.Invoke(sender, e);
        }
    }
}
