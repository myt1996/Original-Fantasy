using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public enum ActionType
    {
        ToUnit = 1,
        ToArea = 2,
        NoTarget = 3
    }

    public enum DamageType
    {
        Physical = 1
    }

    // Used to control one turn-based battle
    public class TurnBasedBattle
    {
        public int ID = -1;

        public int ActiveSpeedNeed = Core.Config.ConfigSingleton().ActiveSpeedNeed;
        public List<Unit> Units = new List<Unit>();

        private List<int> activePoints = new List<int>();
        private Unit currentActiveUnit = null;

        public TurnBasedBattle()
        {
            //ActiveSpeedNeed = Core.Config.ActiveSpeedNeed;
            //activePoints = new List<int>();
            for (int i = 0; i < Units.Count; i++)
            {
                //activePoints.Add(Units[i].Speed);
            }
            UpdateNextActiveUnit();
        }

        public Unit GetCurrentActiveUnit()
        {
            return currentActiveUnit;
        }
        public int GetCurrentActiveUnitID()
        {
            return currentActiveUnit.ID;
        }

        // Try to process a Command, only BattleActionCommand can be processed in Battle
        public bool ProcessCommand(Core.Command command)
        {
            Core.BattleActionCommand actionCommand;
            try
            {
                actionCommand = (Core.BattleActionCommand)command;
            }
            catch (System.Exception)
            {
                return false;
            }
            // TODO, need check but TRUST command in version1
            if (actionCommand.Source == GetCurrentActiveUnit())
            {
                actionCommand.Action.Act(actionCommand.Source, actionCommand.TargetUnits);
                return true;
            }
            else
            {
                return false;
            }
        }

        // After battle init and action taken, check next active unit
        public void UpdateNextActiveUnit()
        {
            while (true)
            {
                for (int i = 0; i < Units.Count; i++)
                {
                    if (activePoints[i] >= ActiveSpeedNeed)
                    {
                        currentActiveUnit = Units[i];
                        activePoints[i] -= ActiveSpeedNeed;
                        return;
                    }
                }
            }
        }

        // TODO : Get all legal actions for a Unit
        public List<Action> GetAllLegalActions(Unit unit)
        {
            return new List<Action>();
        }

        // TODO : If currentActiveUnit is playe Unit, set Battle UI for it
        public void SetBattleUnitUI()
        {

        }
    }
}