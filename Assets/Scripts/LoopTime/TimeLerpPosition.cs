using UnityEngine;

namespace LoopTime
{
    public class TimeLerpPosition: MonoBehaviour
    {
        [SerializeField] private TimeSO timeSO = default;
        [SerializeField] private GameObject target = default;
        [SerializeField] private Transform a = default;
        [SerializeField] private Transform b = default;

        private void OnEnable()
        {
            this.timeSO.TimeTicked += this.TimeTickedEventHandler;
        }

        private void OnDisable()
        {
            this.timeSO.TimeTicked -= this.TimeTickedEventHandler;
        }

        private void TimeTickedEventHandler(object sender, TimeTickedEventArgs e)
        {
            this.target.gameObject.transform.position = Vector3.Lerp(this.a.position, this.b.position, e.ToT);
        }
    }
}