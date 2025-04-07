namespace BarSystem
{
    [System.Serializable]
    public class OrderTypeSlot
    {
        public OrderType OrderType;
        public int Count;
        public int CompletedCount = 0;
        public bool IsSpawnedAsFirst;
        public bool IsCompleted { get { return CompletedCount >= Count; } }
    }
}
