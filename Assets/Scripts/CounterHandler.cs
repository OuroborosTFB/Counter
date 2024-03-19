using UnityEngine;
using System.Collections;

public class CounterHandler : MonoBehaviour
{
	private const float Delay = 0.5f;

	private Counter _counter;
	private Coroutine _countCoroutine;
	private WaitForSeconds _waitForSeconds;
	private bool _isWorking;

	private void Awake()
	{
		_counter = GetComponent<Counter>();
		_waitForSeconds = new WaitForSeconds(Delay);
		_isWorking = false;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			ToggleCounting();
		}
	}

	private void ToggleCounting()
	{
		if (_countCoroutine != null)
		{
			StopCoroutine(_countCoroutine);
			_countCoroutine = null;
			_isWorking = false;
		}
		else
		{
			_countCoroutine = StartCoroutine(CountCoroutine());
			_isWorking = true;
		}
	}

	private IEnumerator CountCoroutine()
	{
		while (_isWorking)
		{
			_counter.IncrementCounter();
			
			yield return _waitForSeconds;
		}
	}
}