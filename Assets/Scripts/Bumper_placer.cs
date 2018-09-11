using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnEntity
{
    Bumper, Ball
}

public class Bumper_placer : MonoBehaviour
{
    [Header("External Scripts")]
    public Ball_Spawn b_s;

    [Header("Misc")]
    public GameObject bumper;
    public int spawns;
    public float timer = 5f;
    public bool timerOn;

    public static Bumper_placer instance;

    [HideInInspector]
    public SpawnEntity[,] board = new SpawnEntity[6, 6];
    private Vector2 ballBoardIndex;
    public float horizontalSpacing;
    public float verticalSpacing;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        timerOn = true;

        GenereateRandomBumper();
    }

    void Update()
    {

    }

    void GenereateRandomBumper()
    {
        //Randomize ball position first because the bumper needs to be aware of where the ball spawns before it can be generated
        RandomizeBallPosition();

        var randomBumperIndex = GenerateRandomBumperIndex();
        int bumperDirection = Random.Range(0, 1);
        //TODO:Validate index first, set new value to random bumperindex if valid is not true until valid is true

        SpawnBumper(randomBumperIndex, bumperDirection);
    }

    private void SpawnBumper(Vector2 randomBumperIndex, int bumperDirection)
    {
        board[(int) randomBumperIndex.x, (int) randomBumperIndex.y] = SpawnEntity.Bumper;
        var position = GetSpawnPositionByIndex((int) randomBumperIndex.x, (int) randomBumperIndex.y);

        //Calculate rotation
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 45, 0));
        if (bumperDirection != 0)
            rotation = Quaternion.Euler(new Vector3(0, -45, 0));

        Instantiate(bumper, position, rotation);
    }

    private Vector2 GenerateRandomBumperIndex()
    {
        return new Vector2(Random.Range(1, 4),Random.Range(1,4));
    }

    private void RandomizeBallPosition()
    {
        int randomDirection = Random.Range(0, 3);
        int randomBallPosition = Random.Range(1, 4);

        switch (randomDirection)
        {
            case 0:
                ballBoardIndex = new Vector2(0, randomBallPosition);
                board[0, randomBallPosition] = SpawnEntity.Ball;
                b_s.SetUpcomingBallPosition(GetSpawnPositionByIndex(0, randomBallPosition), Vector3.up * 90);
                break;
            case 1:
                ballBoardIndex = new Vector2(4, randomBallPosition);
                board[4, randomBallPosition] = SpawnEntity.Ball;
                b_s.SetUpcomingBallPosition(GetSpawnPositionByIndex(0, randomBallPosition), Vector3.up * -90);
                break;
            case 2:
                ballBoardIndex = new Vector2(randomBallPosition, 0);
                board[randomBallPosition, 0] = SpawnEntity.Ball;
                b_s.SetUpcomingBallPosition(GetSpawnPositionByIndex(0, randomBallPosition), Vector3.zero);
                break;
            case 3:
                ballBoardIndex = new Vector2(randomBallPosition, 4);
                board[randomBallPosition, 4] = SpawnEntity.Ball;
                b_s.SetUpcomingBallPosition(GetSpawnPositionByIndex(0, randomBallPosition), Vector3.up * 180);
                break;
        }

    }

    public Vector3 GetSpawnPositionByIndex(int x, int y)
    {
        Vector3 verticalOffset = Vector3.forward * verticalSpacing * y;
        Vector3 horizontalOffset = Vector3.right * horizontalSpacing * x;
        return transform.position + verticalOffset + horizontalOffset;
    }

    void OnDrawGizmos()
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                var targetPos = transform.position + Vector3.right * horizontalSpacing * i +
                                Vector3.forward * verticalSpacing * j;
                Gizmos.DrawCube(targetPos, Vector3.one * .5f);
            }
        }
    }

}