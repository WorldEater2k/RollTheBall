using System;
using System.Collections.Generic;

namespace RollTheBall
{
    [Serializable]
    internal struct SavedData
    {
        public string PlayerName;
        public PlayerType PlayerType;
        public Vector3Serializable PlayerPosition;
        public Dictionary<BonusType, List<Vector3Serializable>> BonusPositions;
    }
}
