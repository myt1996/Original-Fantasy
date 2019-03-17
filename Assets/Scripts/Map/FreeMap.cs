using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    public class FreeMap
    {
        //TODO!!!!!!!!!!!!!!!!

        public List<Unit> Units = new List<Unit>();
        private UI.ResourceLoader resourceLoader = null;

        public FreeMap()
        {
            resourceLoader = new UI.ResourceLoader();
        }
        
        public void AddCoreUnit(Core.Unit coreUnit, Vector3 startPosition)
        {
            Unit mapUnit = new Unit(0, coreUnit, startPosition, Quaternion.identity);
            Units.Add(mapUnit);
            UI.MapUnitUI mapUnitUI = resourceLoader.GetGameObjectClone(mapUnit);
            mapUnitUI.SendMessage("SetMapUnit", mapUnit, SendMessageOptions.RequireReceiver);
            mapUnitUI.SendMessage("SetPlayerControl", true, SendMessageOptions.RequireReceiver); // for test
        }

        public bool CheckIfCanBattle(Unit source, Unit target)
        {
            return false;
        }

        public bool CheckIfCanMove(Unit unit, Vector3 worldPoint)
        {
            return false;
        }

        public bool SetUnitMoveTarget(int unitID, Vector3 worldPoint)
        {
            foreach (var unit in Units)
            {
                if (unitID == unit.ID)
                {
                    unit.MoveTargetPosition = worldPoint;
                    return true;
                }
            }
            return false;
        }

        public void UpdateUnitMove()
        {
            foreach (var unit in Units)
            {
                unit.MoveTowardsTarget();
            }
        }
    }
}