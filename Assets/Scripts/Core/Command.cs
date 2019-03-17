#define version1

#if version1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Command
    {
        public int ID = -1;
        public string Name = "NULLCOMMAND";
    }

    public class ButtonPressCommand : Command
    {
        public int ButtonID = -1;
        public string ButtonText = "NULLBUTTON";
    }

    public class UnitMoveCommand : Command
    {
        public int mapUnitID;
        public Vector3 targetPosition = new Vector3();
        private UnitMoveCommand(int ID, string Name, int mapUnitID, Vector3 targetPosition)
        {
            this.ID = ID;
            this.Name = Name;
            this.mapUnitID = mapUnitID;
            this.targetPosition = targetPosition;
        }

        private static int unitMoveCommandID = 0;
        public static UnitMoveCommand Create(string Name, int mapUnitID, Vector3 targetPosition)
        {
            return new UnitMoveCommand(UnitMoveCommand.unitMoveCommandID, Name, mapUnitID, targetPosition);
        }
    }

    public class BattleActionCommand : Command
    {
        public Battle.Unit Source = null;
        public Battle.Action Action = null;
        public List<Battle.Unit> TargetUnits = new List<Battle.Unit>();
    }
}

#endif