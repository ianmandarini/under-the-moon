using UnityEngine;

namespace NPCs
{
    [CreateAssetMenu(menuName = "Custom/NPCsSO")]
    public class NPCSO: ScriptableObject
    {
        public bool CanInteract { get; private set; }

        public void AllowInteractions() => this.CanInteract = true;
        public void BlockInteractions() => this.CanInteract = false;
    }
}