using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class Unit
    {
        public int ID = -1;
        public int CoreID = -1;
        private Core.Unit coreUnit = null;

        // All parameter of one unit copyed from Core.Unit
        public float MaxHP = 0.0f;
        public float HP = 0.0f;
        public float MaxMP = 0.0f;
        public float MP = 0.0f;
        public float Strength = 0.0f;
        public float Fitness = 0.0f;
        public float Agility = 0.0f;
        public float Intelligence = 0.0f;
        public float Lucky = 0.0f;
        
        public float Attack = 0.0f;
        public float MagicPower = 0.0f;
        public float CriticalProbability = 0.0f;
        public float Defence = 0.0f;
        public float EvasionProbability = 0.0f;
        public float BlockProbability = 0.0f;
        public float WithstandProbability = 0.0f;
        public float MagicResistance = 0.0f;
        public float WeaponProficiency = 0.0f;

        private TurnBasedBattle battle = null;

        public bool IsCurrentActiveUnit()
        {
            return ID == battle.GetCurrentActiveUnitID();
        }

        // Unit take action to target Units or Areas
        // Action must be in the Actions List of Unit and is passed by index
        public void TakeAction(int actionIndex, List<Unit> targetUnits, List<Vector3> targetAreas)
        {
            // Action action = Actions[actionIndex];
            // if (action.Type == ActionType.ToUnit)
            // {
            //     action.Act(this, targetUnits);
            // }
        }

        // Unit get damage in type, damage can be reduced
        public float GetDamage(float damage, DamageType type = DamageType.Physical)
        {
            return 0;
        }
    }
}