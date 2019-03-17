#define version1

#if version1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public enum GameState
    {
        Menu = 1,
        Game = 2,
        Battle = 3,
    }

    public class Main : MonoBehaviour
    {
        public GameState CurrentState = GameState.Menu;

        private Battle.TurnBasedBattle battle = null; // Only one battle can be used

        private Queue<Command> commandQueue = new Queue<Command>();

        private int battleID = 0;

        private Map.Unit mapUnit;
        private UI.MapUnitUI mapUnitUI;
        private Map.FreeMap map;

        // Start is called before the first frame update
        void Start()
        {
            //CurrentState = GameState.Menu;
            //commandQueue = new Queue<Command>();

            CurrentState = GameState.Game;
            Core.Unit coreUnit = new Core.Unit
            {
                Type = UnitType.Player
            };
            map = new Map.FreeMap();
            map.AddCoreUnit(coreUnit, Vector3.right);
            // mapUnit = new Map.Unit(0, coreUnit, Vector3.right, Quaternion.identity);
            // mapUnitUI = resourceLoader.GetGameObjectClone(mapUnit);
            // mapUnitUI.SendMessage("SetMapUnit", mapUnit, SendMessageOptions.RequireReceiver);
            // mapUnitUI.SendMessage("SetPlayerControl", true, SendMessageOptions.RequireReceiver);
        }

        // Update is called once per frame
        void Update()
        {
            //mapUnit.Position.y += 0.1f;
            // mapUnitUI.UpdateCloneObjectPosition();

            ProcessFirstCommand();
            map.UpdateUnitMove();
        }

        // Add one command to queue
        public void AddCommand(Command command)
        {
            Debug.Log("Main get a command");
            commandQueue.Enqueue(command);
        }

        // Process first command in queue and delete it
        private bool ProcessFirstCommand()
        {
            Debug.Log(string.Format("Queue count: {0}", commandQueue.Count));
            if (commandQueue.Count == 0) return true;

            Command command = commandQueue.Dequeue();
            if (!CheckCommandActive(command)) return false;

            if (command.GetType() == typeof(UnitMoveCommand) )
            {
                UnitMoveCommand unitMoveCommand = command as UnitMoveCommand;
                //Debug.Log(string.Format("Target move position {}", unitMoveCommand.targetPosition));
                //mapUnit.Position = unitMoveCommand.targetPosition;
                map.SetUnitMoveTarget(unitMoveCommand.mapUnitID, unitMoveCommand.targetPosition);
                return true;
            }
            else if (command.GetType().Equals(typeof(BattleActionCommand)))
            {
                return battle.ProcessCommand(command);
            }

            return false;
        }

        // Check if command is active in current game state
        private bool CheckCommandActive(Command command)
        {
            //Debug.Log(string.Format("Gamestate: {0}", CurrentState));

            if (CurrentState == GameState.Game && command.GetType() == typeof(UnitMoveCommand) )
            {
                return true;
            }
            else if (CurrentState == GameState.Battle && command.GetType().Equals(typeof(BattleActionCommand)) && battle != null)
            {
                return true;
            }
            return false;
        }

        // Used to start a battle without units info
        public Battle.TurnBasedBattle StartBattle()
        {
            ++battleID;

            List<Battle.Unit> units = new List<Battle.Unit>();

            // first add player battle unit to units
            // units.Add( playerBattleUnit );
            // then add all battle units around player
            // for xxx { units.Add( aroundBattleUnit ); }

            battle = new Battle.TurnBasedBattle
            {
                ID = battleID,
                Units = units
            };
            return battle;
        }

        // Used to start a battle
        public Battle.TurnBasedBattle StartBattle(List<Battle.Unit> units)
        {
            ++battleID;
            battle = new Battle.TurnBasedBattle
            {
                ID = battleID,
                Units = units
            };
            return battle;
        }

        // Call when a started battle end
        public void EndBattle()
        {
            // TODO, modify everything according to battle end info
            battle = null;
        }
    }
}

#endif