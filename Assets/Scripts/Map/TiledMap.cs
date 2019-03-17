using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    public class TiledMap
    {
        public List<Unit> Units = new List<Unit>();

        public bool CheckIfCanBattle(Unit source, Unit target)
        {
            return false;
        }
    }
}