using UnityEngine;

namespace AsphaltAnarchy.Echo
{
    public class TrafficLight : MonoBehaviour
    {
        [SerializeField] private LightState currentState = LightState.Red;

        public LightState CurrentState => currentState;

        public void ForceGreenForPlayer()
        {
            currentState = LightState.Green;
        }
    }

    public enum LightState
    {
        Red,
        Yellow,
        Green
    }
}
