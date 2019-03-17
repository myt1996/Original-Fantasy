using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Map
{
    [Serializable]
    public class Unit
    {
        public int ID = -1;
        public int CoreID = -1;
        private readonly Core.Unit coreUnit = null;

        public Vector3 Position = new Vector3();
        public Quaternion Rotation = new Quaternion();
        public float Speed = 2 * Time.deltaTime;
        public bool CanBattle = false;
        public Vector3 MoveTargetPosition = new Vector3();

        // Only for unit can battle
        public float BattleTendency = 0.0f;

        public Unit(int ID, Core.Unit coreUnit, Vector3 position, Quaternion rotation)
        {
            this.ID = ID;
            this.coreUnit = coreUnit;
            this.CoreID = coreUnit.ID;
            this.Position = position;
            this.Rotation = rotation;
            this.MoveTargetPosition = position;
        }

        public void MoveTowardsTarget()
        {
            Position = Vector3.MoveTowards(Position, MoveTargetPosition, Speed);
            
        }

        public Core.Unit CoreUnit => coreUnit;
    }
}