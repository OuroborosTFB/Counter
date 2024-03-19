using System;
using UnityEngine;

public class Counter : MonoBehaviour
{
	public event Action ValueChanged; 

	private float _counterValue = 0;

	public float Value 
	{ 
		get => _counterValue;

		private set 
		{
			_counterValue = value;
			ValueChanged?.Invoke();
		}
	}

	public void IncrementCounter() =>
		Value++;
}