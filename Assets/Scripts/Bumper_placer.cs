using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnEntity
{
    Empty, Bumper, Ball
}

public enum Direction
{
    Up, Down, Right, Left
}

public class Bumper_placer : MonoBehaviour
{
    [Header("External Scripts")]
    public Ball_Spawn b_s;

    [Header("Misc")]
    public GameObject bumper;
    public int spawns;
    public float timer = 1f;
    public bool timerOn;
    [SerializeField] private float bumperSpawnAmount = 2;

    public static Bumper_placer instance;
    Direction ballDirection;
    SpawnEntity spawnPlace;
    bool lastBumperIsBumper1;

    [HideInInspector] public SpawnEntity[,] board = new SpawnEntity[6, 6];
    private Vector2 ballBoardIndex;
    Vector2 lastBumperIndex;
    Vector2 randomBumperIndex = Vector2.zero;
    private Direction ballDirectionIndex;
    public float horizontalSpacing;
    public float verticalSpacing;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        timer = 1f;
        timerOn = true;
        GenerateBumpers(3);
    }

    void Update()
    {
        timer -= Time.deltaTime;
    }

    void GenerateBumpers(int bumperAmount)
    {
        //Randomize ball position first because the bumper needs to be aware of where the ball spawns before it can be generated
        RandomizeBallPosition();

        for (int i = 0; i < bumperAmount; i++)
        {
            GenerateBumper(i == 0);
        }
    }

    void GenerateBumper(bool firstIteration)
    {
        //Vector2 randomBumperIndex = Vector2.zero;
        if (firstIteration)
        {
            //Calculate a new random bumper index using the location of where the ball spawns
            if (ballBoardIndex.x == 0)
            {
                ballDirection = Direction.Right;
                randomBumperIndex = GenerateRandomBumperIndex();
                randomBumperIndex.y = ballBoardIndex.y;
            }
            if (ballBoardIndex.y == 0)
            {
                ballDirection = Direction.Up;
                randomBumperIndex = GenerateRandomBumperIndex();
                randomBumperIndex.x = ballBoardIndex.x;
            }
            if (ballBoardIndex.x == board.GetLength(0) - 1)
            {
                ballDirection = Direction.Left;
                randomBumperIndex = GenerateRandomBumperIndex();
                randomBumperIndex.y = ballBoardIndex.y;
            }
            if (ballBoardIndex.y == board.GetLength(0) - 1)
            {
                ballDirection = Direction.Down;
                randomBumperIndex = GenerateRandomBumperIndex();
                randomBumperIndex.x = ballBoardIndex.x;
            }
        }
        else
        {
            //Calculate a new random bumper index using the location of the last bumper
            if (ballDirection == Direction.Up && lastBumperIsBumper1 == true)
            {
                ballDirection = Direction.Left;
                randomBumperIndex = GenerateRandomBumperyLeftIndex();
                randomBumperIndex.y = lastBumperIndex.y;
            }
            if (ballDirection == Direction.Down && lastBumperIsBumper1 == true)
            {
                ballDirection = Direction.Right;
                randomBumperIndex = GenerateRandomBumperyRightIndex();
                randomBumperIndex.y = lastBumperIndex.y;
            }
            if (ballDirection == Direction.Left && lastBumperIsBumper1 == true)
            {
                ballDirection = Direction.Up;
                randomBumperIndex = GenerateRandomBumperxDownIndex();
                randomBumperIndex.x = lastBumperIndex.x;
            }
            if (ballDirection == Direction.Right && lastBumperIsBumper1 == true)
            {
                ballDirection = Direction.Down;
                randomBumperIndex = GenerateRandomBumperxUpIndex();
                randomBumperIndex.x = lastBumperIndex.x;
            }

            if (ballDirection == Direction.Down && lastBumperIsBumper1 == false)
            {
                ballDirection = Direction.Right;
                randomBumperIndex = GenerateRandomBumperyRightIndex();
                randomBumperIndex.y = lastBumperIndex.y;
            }
            if (ballDirection == Direction.Up && lastBumperIsBumper1 == false)
            {
                ballDirection = Direction.Left;
                randomBumperIndex = GenerateRandomBumperyLeftIndex();
                randomBumperIndex.y = lastBumperIndex.y;
            }
            if (ballDirection == Direction.Right && lastBumperIsBumper1 == false)
            {
                ballDirection = Direction.Down;
                randomBumperIndex = GenerateRandomBumperxDownIndex();
                randomBumperIndex.x = lastBumperIndex.x;
            }
            if (ballDirection == Direction.Left && lastBumperIsBumper1 == false)
            {
                ballDirection = Direction.Up;
                randomBumperIndex = GenerateRandomBumperxUpIndex();
                randomBumperIndex.x = lastBumperIndex.x;
            }
        }

        spawnPlace = board[(int)randomBumperIndex.x, (int)randomBumperIndex.y];
        lastBumperIsBumper1 = true;
        lastBumperIndex = randomBumperIndex;

        if (spawnPlace == SpawnEntity.Empty) {
            Instantiate(bumper, GetSpawnPositionByIndex((int)randomBumperIndex.x, (int)randomBumperIndex.y), Quaternion.Euler(0, 45, 0));
        }
        else
        {
            GenerateBumper(false);
        }
    }

    void GenerateRandomBumper()
    {

        
        int bumperDirection = Random.Range(0, 1);
        
        int x = (int)randomBumperIndex.x;
        int y = (int)randomBumperIndex.y;
        bool leftSide = x == 1;
        bool bottomSide = y == 1;
        bool rightSide = x == board.GetLength(0) - 2;
        bool topSide = y == board.GetLength(0) - 2;
        bool onBorder = leftSide || bottomSide || rightSide || topSide;

        if (!onBorder)
            SpawnBumper(randomBumperIndex, bumperDirection);

        if (onBorder)
            SpawnBumper(randomBumperIndex, bumperDirection);
        //TODO:Validate index first, set new value to random bumperindex if valid is not true until valid is true
    }

    private void SpawnBumper(Vector2 randomBumperIndex, int bumperDirection)
    {
        board[(int)randomBumperIndex.x, (int)randomBumperIndex.y] = SpawnEntity.Bumper;
        Vector3 position = GetSpawnPositionByIndex((int)randomBumperIndex.x, (int)randomBumperIndex.y);

        //Calculate rotation
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 45, 0));
        if (bumperDirection != 0)
            rotation = Quaternion.Euler(new Vector3(0, -45, 0));

        Instantiate(bumper, position, rotation);
    }

    private Vector2 GenerateRandomBumperIndex()
    {
        return new Vector2(Random.Range(1, 5), Random.Range(1, 5));


    }

    private Vector2 GenerateRandomBumperxUpIndex()
    {
        return new Vector2(Random.Range(1, 5), Random.Range(randomBumperIndex.y + 1, 5));
    }
    private Vector2 GenerateRandomBumperxDownIndex()
    {
        return new Vector2(Random.Range(1, 5), Random.Range(1, randomBumperIndex.y ));
    }
    private Vector2 GenerateRandomBumperyLeftIndex()
    {
        return new Vector2(Random.Range(randomBumperIndex.x +1, 5), Random.Range(1, 5));
    }
    private Vector2 GenerateRandomBumperyRightIndex()
    {
        return new Vector2(Random.Range(1, randomBumperIndex.x ), Random.Range(1, 5));
    }

    private void RandomizeBallPosition()
    {
        int randomDirection = Random.Range(0, 4);
        int randomBallPosition = Random.Range(1, 4);

        switch (randomDirection)
        {   
            case 0:
                ballBoardIndex = new Vector2(0, randomBallPosition);
                board[0, randomBallPosition] = SpawnEntity.Ball;
                b_s.SetUpcomingBallPosition(GetSpawnPositionByIndex(0, randomBallPosition), Vector3.up * 90);
                break;
            case 1:
                ballBoardIndex = new Vector2(5, randomBallPosition);
                board[4, randomBallPosition] = SpawnEntity.Ball;
                b_s.SetUpcomingBallPosition(GetSpawnPositionByIndex(5, randomBallPosition), Vector3.up * -90);
                break;
            case 2:
                ballBoardIndex = new Vector2(randomBallPosition, 0);
                board[randomBallPosition, 0] = SpawnEntity.Ball;
                b_s.SetUpcomingBallPosition(GetSpawnPositionByIndex(randomBallPosition, 0), Vector3.zero);
                break;
            case 3:
                ballBoardIndex = new Vector2(randomBallPosition, 4);
                board[randomBallPosition, 5] = SpawnEntity.Ball;
                b_s.SetUpcomingBallPosition(GetSpawnPositionByIndex(randomBallPosition, 5), Vector3.up * 180);
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
                Vector3 targetPos = transform.position + Vector3.right * horizontalSpacing * i +
                Vector3.forward * verticalSpacing * j;
                Gizmos.DrawCube(targetPos, Vector3.one * .5f);
            }
        }
    }
}