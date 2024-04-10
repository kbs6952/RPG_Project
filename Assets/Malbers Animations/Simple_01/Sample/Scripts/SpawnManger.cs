using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject powerupObject;
    [SerializeField] private Transform enemySpawnPosition;

    public int enemyCount = 0;
    public int waveNumber = 1;

    public float limitWidth = 5;
    public float limitHeight = 11;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy(waveNumber);

        // �� ���� ����, Ư�� ��ġ���� �����Ǵ� �ڵ� �ۼ�
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<SampleEnemy>().Length; // ���̾��Ű���� SampleEnemy ��ũ��Ʈ�� ���� �ִ� ������Ʈ�� ã�Ƽ� �� ������ ��ȯ�ϴ� �ڵ�

        if (enemyCount == 0)                                  // SampleEnemy ��ũ��Ʈ�� ���� �ִ� ������Ʈ 0 "��� Enemy�� �׾��� ��" ���� �����Ѵ�.
        {
            waveNumber++;
            SpawnEnemy(waveNumber);
        }
    }

    private void SpawnEnemy(int spawnNumber)                  // ���� ���� óġ�� �� ���� Wave�� ���� 1�� �����ϰ�, ������ Wave �� ��ŭ ���� ���̺�(Enemy)�� �����Ѵ�.
    {
        for (int i = 0; i < spawnNumber; i++)
        {
            GameObject enemyObj = Instantiate(enemy, RandomSpawnPoistion(), Quaternion.identity);
        }  
    }

    private Vector3 RandomSpawnPoistion()
    {
        float randomX = UnityEngine.Random.Range(-limitWidth, limitWidth);
        float randomZ = UnityEngine.Random.Range(-limitHeight, limitHeight);
        
        Vector3 randomPos = new Vector3(randomX, 0, randomZ);

        return randomPos;
    }
}
