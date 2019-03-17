using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Battle;
using Map;

namespace Core
{
    public enum UnitType
    {
        Warrior,
        Wizard,
        Eagle,
        Frog,
        Player
    }

    [Serializable]
    public class Unit
    {
        public int ID = -1;
        public string Name = "NULLCOREUNIT";
        public int MapUnitID = -1;
        private Map.Unit mapUnit = null;
        public int BattleUnitID = -1;
        private Battle.Unit battleUnit = null;
        public UnitType Type = 0;

        // All parameter of one unit
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

        public override bool Equals(object obj)
        {
            var unit = obj as Unit;
            return unit != null &&
                   ID == unit.ID &&
                   Name == unit.Name &&
                   MapUnitID == unit.MapUnitID &&
                   EqualityComparer<Map.Unit>.Default.Equals(mapUnit, unit.mapUnit) &&
                   BattleUnitID == unit.BattleUnitID &&
                   EqualityComparer<Battle.Unit>.Default.Equals(battleUnit, unit.battleUnit) &&
                   Type == unit.Type &&
                   MaxHP == unit.MaxHP &&
                   HP == unit.HP &&
                   MaxMP == unit.MaxMP &&
                   MP == unit.MP &&
                   Strength == unit.Strength &&
                   Fitness == unit.Fitness &&
                   Agility == unit.Agility &&
                   Intelligence == unit.Intelligence &&
                   Lucky == unit.Lucky &&
                   Attack == unit.Attack &&
                   MagicPower == unit.MagicPower &&
                   CriticalProbability == unit.CriticalProbability &&
                   Defence == unit.Defence &&
                   EvasionProbability == unit.EvasionProbability &&
                   BlockProbability == unit.BlockProbability &&
                   WithstandProbability == unit.WithstandProbability &&
                   MagicResistance == unit.MagicResistance &&
                   WeaponProficiency == unit.WeaponProficiency;
        }

        public override int GetHashCode()
        {
            var hashCode = 589912188;
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + MapUnitID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Map.Unit>.Default.GetHashCode(mapUnit);
            hashCode = hashCode * -1521134295 + BattleUnitID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Battle.Unit>.Default.GetHashCode(battleUnit);
            hashCode = hashCode * -1521134295 + Type.GetHashCode();
            hashCode = hashCode * -1521134295 + MaxHP.GetHashCode();
            hashCode = hashCode * -1521134295 + HP.GetHashCode();
            hashCode = hashCode * -1521134295 + MaxMP.GetHashCode();
            hashCode = hashCode * -1521134295 + MP.GetHashCode();
            hashCode = hashCode * -1521134295 + Strength.GetHashCode();
            hashCode = hashCode * -1521134295 + Fitness.GetHashCode();
            hashCode = hashCode * -1521134295 + Agility.GetHashCode();
            hashCode = hashCode * -1521134295 + Intelligence.GetHashCode();
            hashCode = hashCode * -1521134295 + Lucky.GetHashCode();
            hashCode = hashCode * -1521134295 + Attack.GetHashCode();
            hashCode = hashCode * -1521134295 + MagicPower.GetHashCode();
            hashCode = hashCode * -1521134295 + CriticalProbability.GetHashCode();
            hashCode = hashCode * -1521134295 + Defence.GetHashCode();
            hashCode = hashCode * -1521134295 + EvasionProbability.GetHashCode();
            hashCode = hashCode * -1521134295 + BlockProbability.GetHashCode();
            hashCode = hashCode * -1521134295 + WithstandProbability.GetHashCode();
            hashCode = hashCode * -1521134295 + MagicResistance.GetHashCode();
            hashCode = hashCode * -1521134295 + WeaponProficiency.GetHashCode();
            return hashCode;
        }
    }
}