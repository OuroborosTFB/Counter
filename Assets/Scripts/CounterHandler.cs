using System;
using UnityEngine;
using System.Collections;

public class CounterHandler : MonoBehaviour
{
	[SerializeField] private float _delay = 0.5f;

	private Counter _counter;
	private Coroutine _countCoroutine;
	private WaitForSeconds _waitForSeconds;

	private void Awake()
	{
		_counter = GetComponent<Counter>();
		_waitForSeconds = new WaitForSeconds(_delay);
	}

	private void Start() =>
		_countCoroutine = StartCoroutine(CountCoroutine());

	private void Update() =>
		TryCount();

	private IEnumerator CountCoroutine()
	{
		while (enabled)
		{
			_counter.IncrementCounter();

			yield return _waitForSeconds;
		}
	}

	private void TryCount()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (_countCoroutine != null)
			{
				StopCoroutine(_countCoroutine);
				_countCoroutine = null;
			}
			else
			{
				_countCoroutine = StartCoroutine(CountCoroutine());
			}
		}
	}
}