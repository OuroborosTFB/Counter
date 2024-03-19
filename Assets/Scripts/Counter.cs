using UnityEngine;

public class Counter : MonoBehaviour
{
	public float Value { get; private set; } = 0;

	public void IncrementCounter() =>
		Value++;
}