using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class BattleUnitUI : MonoBehaviour
    {
        private enum MenuPosition
        {
            RightDown = 1,
            LeftDown = 2,
            RightUp = 3,
            LeftUp = 4
        }

        public Vector3 BattleUnitPosition = new Vector3();

        private readonly Battle.Unit unit = null;
        private List<string> items = new List<string>();
        private List<string> skills = new List<string>();
        private List<string> menu = new List<string>();
        private bool isShowing = false;
        private Vector3 screenPos = new Vector3();
        private Vector3 worldPos = new Vector3();

        void Start()
        {
            // Camera.main.SendMessage("AddCommand", new Core.Command(), SendMessageOptions.RequireReceiver);

            // menu = new List<string>
            // {
            //     "test1",
            //     "test2",
            //     "test3"
            // };
            // Show();
        }

        void Update()
        {
          
        }

        private void OnGUI() 
        {
            if (isShowing)
            {
                screenPos = Camera.main.WorldToScreenPoint(transform.position);
                Print();

            }
        }

        private void Print()
        {
            if (Screen.width - screenPos.x <= 50)
            {
                if (screenPos.y >=   menu.Count * 20)
                {
                    PrintButtonWithDir(MenuPosition.LeftDown);
                }
                else
                {
                    PrintButtonWithDir(MenuPosition.LeftUp);
                }
            }
            else
            {
                if (screenPos.y >=  + menu.Count * 20)
                {
                    PrintButtonWithDir(MenuPosition.RightDown);
                }
                else
                {
                    PrintButtonWithDir(MenuPosition.RightUp);
                }
            }
        }

        private void PrintButtonWithDir(MenuPosition position)
        {
            switch (position)
            {
                case MenuPosition.RightDown:
                    for (int i = 0; i < menu.Count; i++)
                    {
                        if(GUI.Button(new Rect(screenPos.x +10, Screen.height - screenPos.y + i * 20, 50, 20), menu[i]))
                            ClickButton(menu[i]);
                    }
                    break;
                case MenuPosition.LeftDown:
                    for (int i = 0; i < menu.Count; i++)
                    {
                        if(GUI.Button(new Rect(screenPos.x - 60, Screen.height - screenPos.y + i * 20, 50, 20), menu[i]))
                            ClickButton(menu[i]);
                    }
                    break;
                case MenuPosition.RightUp:
                    for (int i = 0; i < menu.Count; i++)
                    {
                        if(GUI.Button(new Rect(screenPos.x + 10, Screen.height - screenPos.y - i * 20, 50, 20), menu[i]))
                            ClickButton(menu[i]); ;

                    }
                    break;
                case MenuPosition.LeftUp:
                    for (int i = 0; i < menu.Count; i++)
                    {
                        if(GUI.Button(new Rect(screenPos.x - 60, Screen.height - screenPos.y - i * 20, 50, 20), menu[i]))
                            ClickButton(menu[i]);
                    }
                    break;
            }
        }


        private void ClickButton(string buttonName)
        {
            Debug.Log(buttonName);
            //foreach(string buttonName in menu)
            //{

            //}
        }

        public void Show()
        {
            isShowing = true;
        }

        public void Hide()
        {
            isShowing = false;
        }
    }
}
