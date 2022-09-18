using System;
using AssemblyCSharp.Assets.Scripts.Levels;
using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.Other
{
    public class PlayerDead : MonoBehaviour
    {
        void OnEnable()
        {
            Player.Enabled += PlayerOnEnabled;
        }

        private void PlayerOnEnabled(object sender, EventArgs e)
        {
            Player.Disabled += PlayerOnDisabled;
        }

        private void PlayerOnDisabled(object sender, EventArgs e)
        {
            LevelManager.LoadStartMenu();
        }

        void OnDisable()
        {
            Player.Enabled -= PlayerOnEnabled;
            Player.Disabled -= PlayerOnDisabled;
        }
    }
}
