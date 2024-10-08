using UnityEngine;

namespace Model
{
    public class Timer
	{
		public float Time { get; private set; }

		public void Start()
		{
			Time = UnityEngine.Time.time;
		}

		public void Stop()
		{
			Time = UnityEngine.Time.time - Time;
		}

        public override string ToString()
        {
            return $"{Mathf.FloorToInt(Time / 60):D2} мин. {Mathf.FloorToInt(Time % 60):D2} сек.";
        }
    }
}
