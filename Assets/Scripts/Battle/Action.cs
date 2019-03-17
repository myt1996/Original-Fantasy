using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Battle
{
    public enum ActionEffect
    {
        Damage = 0,
        DamageBasedOnAttack = 1
    }

    [Serializable]
    public class Action
    {
        public int ID;
        public string Name;
        public ActionType Type;
        public List<ActionEffect> Effects;
        public List<float> Powers;

        // Source Unit take this action to targets Unit
        public void Act(Unit source, List<Unit> targets)
        {
            foreach (Unit target in targets)
            {
                Act(source, target);
            }
        }

        // Source Unit take this action to one target Unit
        public void Act(Unit source, Unit target)
        {
            for (int index = 0; index < Effects.Count; index++)
            {
                if (Effects[index] == ActionEffect.Damage)
                {
                    target.HP -= Powers[index];
                }
                else if (Effects[index] == ActionEffect.DamageBasedOnAttack)
                {
                    float damage = Powers[index] * source.Attack;
                    target.HP -= damage;
                }
            }
        }
    }
}
