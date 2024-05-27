﻿using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player has died.
    /// </summary>
    /// <typeparam name="PlayerDeath"></typeparam>
    public class PlayerDeath : Simulation.Event<PlayerDeath>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();
       
	
        public override void Execute()
        {
           
            var player = model.player;
            //Debug.Log(player);
            //Debug.Log(gameOverMenu);
            if (player.health.IsAlive)
            {
                player.health.Die();
                model.virtualCamera.m_Follow = null;
                model.virtualCamera.m_LookAt = null;
                // player.collider.enabled = false;
                player.controlEnabled = false;       
                
                if (player.audioSource && player.ouchAudio)
                    player.audioSource.PlayOneShot(player.ouchAudio);
                player.animator.SetTrigger("hurt");
                player.animator.SetBool("dead", true);
                // Find the GameOverManager in the scene and call ShowGameOverMenu
                var gameOverManager = GameObject.FindObjectOfType<GameOverController>();
                if (gameOverManager != null)
                {
                    gameOverManager.ShowGameOverMenu();
                }
                else
                {
                    Debug.LogError("GameOverManager not found in the scene.");
                }
               
                
                //Simulation.Schedule<PlayerSpawn>(2);
            }
        }
    }
}
