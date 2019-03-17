using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UI
{
    public class ResourceLoader
    {
        //public string Path;
        private Dictionary<string, UnityEngine.Object> prefabs = new Dictionary<string, UnityEngine.Object>();

        public ResourceLoader()
        {
            LoadAllPrefab();
        }
        
        private void LoadAllPrefab()
        {
            prefabs.Clear();
            UnityEngine.Object[] tempObjects = Resources.LoadAll("Prefab");
            foreach (var tempObject in tempObjects)
            {
                string name = tempObject.name;
                prefabs.Add(name, tempObject);
            }
        }

        // Create a GameObject in the map by data in the passed Map.Unit
        public UI.MapUnitUI GetGameObjectClone( Map.Unit mapUnit)
        {
            if (!prefabs.ContainsKey(mapUnit.CoreUnit.Type.ToString())) 
            {
                Debug.Log("Warning! No GameObject was generated because of type error!");
                return null;
            }
            GameObject clonedGameObject = GameObject.Instantiate(prefabs[mapUnit.CoreUnit.Type.ToString()] as GameObject, mapUnit.Position, mapUnit.Rotation);
            MapUnitUI clonedMapUnitUI = clonedGameObject.AddComponent<MapUnitUI>();
            clonedMapUnitUI.SendMessage("SetMapUnit", mapUnit, SendMessageOptions.RequireReceiver);
            return clonedMapUnitUI;
        }
    }
}