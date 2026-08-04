using UnityEngine;

namespace AsphaltAnarchy.Echo
{
    public class PoliceUnit : MonoBehaviour
    {
        [SerializeField] private bool isDiverted;

        public bool IsDiverted => isDiverted;

        public void DivertPatrol()
        {
            isDiverted = true;
        }
    }
}
