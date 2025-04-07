using UnityEngine;

namespace DialogSystem
{
    [System.Serializable]
    public class SpeakerSlot
    {
        public string Name;
        [TextArea] public string Text;
        public bool IsPause;
        public bool IsEnd;
    }
}