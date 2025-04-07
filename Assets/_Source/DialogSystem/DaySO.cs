using System.Collections.Generic;
using UnityEngine;

namespace DialogSystem
{
    [CreateAssetMenu(fileName = "DaySO", menuName = "SO/DaySO")]
    public class DaySO : ScriptableObject
    {
        public List<SpeakerSlot> Dialog;
    }
}