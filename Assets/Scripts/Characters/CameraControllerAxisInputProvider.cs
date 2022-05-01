using System;
using Cinemachine;
using UnityEngine;

namespace BrieYourself.Characters {
    public class CameraControllerAxisInputProvider : MonoBehaviour, AxisState.IInputAxisProvider {
        [SerializeField]
        bool useXAxis = true;
        [SerializeField]
        bool useYAxis = true;

        public Func<Vector2> axisProvider = () => Vector2.zero;

        public float GetAxisValue(int axis) => axis switch {
            0 when useXAxis => axisProvider().x,
            1 when useYAxis => axisProvider().y,
            _ => 0,
        };
    }
}
