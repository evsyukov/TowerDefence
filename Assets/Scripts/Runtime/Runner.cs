using System.Collections.Generic;
using Enemy;
using EnemySpawn;
using Field;
using UnityEngine;

namespace Runtime
{
    public class Runner : MonoBehaviour {
        private List<IController> m_Controllers;
        private bool m_IsRunning = false;

        private void Update() {
            if(!m_IsRunning) { return; }
            TickControllers();
        }

        public void StartRunning() {
            CreateAllControllers();
            OnStartControllers();
            m_IsRunning = true;
        }

        public void StopRunning() {
            OnStopControllers();
            m_IsRunning = false;
        }

        private void CreateAllControllers() {
            m_Controllers = new List<IController>
            {
                new GridPointerController(Game.Player.GridHolder),
                new EnemySpawnController(Game.CurrentLevel.SpawnWavesAsset,
                                        Game.Player.Grid),
                new MovementController()
            };
        }

        private void OnStartControllers() {
            foreach (IController controller in m_Controllers) {
                try {
                    controller.OnStart();
                } catch (System.Exception e) {
                    Debug.Log(e);
                }
            }
        }

        private void TickControllers() {
            foreach (IController controller in m_Controllers) {
                try {
                    controller.Tick();
                } catch (System.Exception e) {
                    Debug.Log(e);
                }
            }
        }

        private void OnStopControllers() {
            foreach (IController controller in m_Controllers) {
                try {
                    controller.OnStop();
                } catch (System.Exception e) {
                    Debug.Log(e);
                }
            }
        }
    }
}
