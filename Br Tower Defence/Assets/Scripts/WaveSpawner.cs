using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
	public Transform enemyPrefab;

	public Transform spawnPoint;

	public float timeBetweenWaves = 5f;

	private float countDown = 2f;

	public Text waveCountDownText;

	private int waveIndex = 0;

	void Update()
	{
		if (countDown <= 0f)
		{
			StartCoroutine(SpawnWave());

			//Debug.Log(waveIndex);

			countDown = timeBetweenWaves;
		}

		countDown -= Time.deltaTime;

		waveCountDownText.text = Mathf.Round(countDown).ToString();
	}


	IEnumerator SpawnWave()
	{
		waveIndex++;

		for (int i = 0; i < waveIndex; i++)
		{
			SpawnEnemy();
			//Debug.Log("wave");

			yield return new WaitForSeconds(0.4f);
		}

	}

	void SpawnEnemy()
	{
		//Debug.Log("SpawnEnemy");
		Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation );
		//Debug.Log("AfterSpawnEnemy");
	}

}
