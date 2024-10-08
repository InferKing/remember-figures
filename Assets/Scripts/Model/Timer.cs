using UnityEngine;

namespace Model
{
	public class Timer
	{
		private const int SecondsInMinute = 60;

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
			return $"{Mathf.FloorToInt(Time / SecondsInMinute):D2} мин. {Mathf.FloorToInt(Time % SecondsInMinute):D2} сек.";
		}
	}
}
