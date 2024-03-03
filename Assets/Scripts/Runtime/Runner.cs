using System.Collections.Generic;
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
            m_Controllers = new List<IController>();
            // TODO add controllers

            // testController
            m_Controllers.Add(new TestController());
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
