using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : MonoBehaviour
{
    public GameObject blockPrefab; // 블럭 프리팹
    public int numberOfBlocks = 10; // 생성할 블럭의 수
    public float spawnAreaWidth = 10f; // 생성 영역의 너비
    public float spawnAreaHeight = 5f; // 생성 영역의 높이
    public float blockWidth = 1f; // 블럭의 너비 (Collider2D의 크기와 일치해야 함)
    public float blockHeight = 0.5f; // 블럭의 높이 (Collider2D의 크기와 일치해야 함)

    private void Start()
    {
        SpawnBlocks();
    }

    private void SpawnBlocks()
    {
        int blocksSpawned = 0;

        while (blocksSpawned < numberOfBlocks)
        {
            // 랜덤한 위치 생성
            Vector2 spawnPosition = new Vector2(
                Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2),
                Random.Range(-spawnAreaHeight / 2, spawnAreaHeight / 2)
            );

            // 블럭이 겹치는지 확인
            if (!IsPositionOccupied(spawnPosition))
            {
                // 블럭 생성
                Instantiate(blockPrefab, spawnPosition, Quaternion.identity);
                blocksSpawned++;
            }
        }
    }

    private bool IsPositionOccupied(Vector2 position)
    {
        // 주어진 위치에 Collider2D가 있는지 확인
        Collider2D[] colliders = Physics2D.OverlapBoxAll(position, new Vector2(blockWidth, blockHeight), 0);
        return colliders.Length > 0;
    }
}
