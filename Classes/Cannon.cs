using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticeMod.Classes
{
    class Cannon : PhentrixGames.NewColonyAPI.Classes.Type, PhentrixGames.NewColonyAPI.Interfaces.IAutoType
    {
        public Cannon()
        {
            this.BoxColliders.Add(new Pipliz.BoundsPip(new UnityEngine.Vector3(0, 0), new UnityEngine.Vector3(1, 1)));

            this.CollidePlayer = true;
            this.IsDestructible = true;

            this.
        }
    }
}
