using System;
using System.Collections;
using System.Collections.Generic;
using Code.Controllers.ControllerMethods;
using Code.Utility.ControllerMethods;
using UnityEngine;
using Zenject;

namespace Code.Controllers.ControllerUtility
{
    public class ControllerRunner: MonoBehaviour
    {
        private List<IControllerAction> _controllers;

        [Inject]
        public void Construct(List<IControllerAction> controllers)
        {
            _controllers = controllers;
        }
        public void Awake()
        {
            foreach (var controller in _controllers)
            {
                if (controller is IAwake awake)
                {
                    awake.Awake();
                }
            }
        }

        public void Start()
        {
            foreach (var controller in _controllers)
            {
                if (controller is IStart start)
                {
                    start.Start();
                }
            }
        }

        private void Update()
        {
            foreach (var controller in _controllers)
            {
                if (controller is IExecute execute)
                {
                    execute.Execute();
                }
            }
        }

        public void FixedUpdate()
        {
            foreach (var controller in _controllers)
            {
                if (controller is IFixedExecute execute)
                {
                    execute.FixedExecute();
                }
            }
        }

        private void OnDestroy()
        {
            foreach (var controller in _controllers)
            {
                if (controller is IClean clean)
                {
                    clean.Clean();
                }
            }
        }
    }
}