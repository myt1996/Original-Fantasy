using System;
using UnityEngine;
using System.Collections.Generic;


namespace UI
{
    public class MapUnitUI : MonoBehaviour
    {
        private Map.Unit mapUnit = null;
        private bool isPlayerControling = false;

        // Start is called before the first frame update
        void Start()
        {
 
        }

        private void GetPlayerInput()
        {
            if(Input.GetMouseButton(1))
            {
                Vector3 targetWorldPosition = ScreenPositionToWorldPosition(Input.mousePosition);
                targetWorldPosition.z = 0;
                Core.UnitMoveCommand command = Core.UnitMoveCommand.Create("MapUnitMove", this.mapUnit.ID, targetWorldPosition);
                Camera.main.GetComponent<Core.Main>().SendMessage("AddCommand", command, SendMessageOptions.RequireReceiver);
            }
        }

        private Vector3 ScreenPositionToWorldPosition(Vector3 screenPosition)
        {
            return Camera.main.ScreenToWorldPoint(screenPosition);
        }

        // Update is called once per frame
        void Update()
        {
            if (isPlayerControling) GetPlayerInput();
            if(null!=mapUnit) UpdateCloneObjectPosition();
        }

        public void UpdateCloneObjectPosition()
        {
            //Debug.Log(string.Format("Update to position {0}", mapUnit.Position));
            if (gameObject.transform.position != mapUnit.Position)
            {
                SetAnimator("Run");
            }
            gameObject.transform.position = mapUnit.Position;
            
  
            
        }
        // Add Map.Unit to this script
        public void SetMapUnit(Map.Unit mapUnit)
        {
            this.mapUnit = mapUnit;
        }

        // Set this flag is this Unit is controled by player input
        public void SetPlayerControl(bool flag)
        {
            this.isPlayerControling = flag;
        }


        //Set anima for roles.
        //Untill now there are 2 key words, including Attack and Run
        //there is no need to make difference between types
        public void SetAnimator(string keyword)
        {
            GetComponent<Animator>().SetTrigger(keyword);
        }
    }

}

