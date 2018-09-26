using System.Collections.Generic;
using UnityEngine;

public enum SpawnEntity
{
    Empty, Bumper, Ball
}

public enum Direction
{
    Up, Down, Right, Left, Nothing
}

public enum BorderSide
{
    Nothing = 0, Top = 1, Bottom = 2, Right = 4, Left = 8, TopRight = 5, TopLeft = 9, BottomRight = 6, BottomLeft = 10
}

public class Bumper_placer : MonoBehaviour
{
    public static Bumper_placer instance;

    [Header("External Scripts")]
    public Ball_Spawn b_s;
    public BoardMaker b_m;

    [Header("Misc")]
    public GameObject[] bumpers;
    public float timer = 2.5f;

    public float horizontalSpacing;
    public float verticalSpacing;

    public int testBumpersToSpawn = 1;

    [HideInInspector] public SpawnEntity[,] board = new SpawnEntity[6, 6];
    private List<GameObject> spawnedBumpers = new List<GameObject>();
    private Vector2 ballPosition;
    Vector2 bumperPosition;
    private Direction ballDirection;
    bool lastBumperIsBumper1;

    private bool timerOn;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        timerOn = true;
        RandomizeBall();
        b_m.BuildBoard();
        testBumpersToSpawn = PlayerPrefs.GetInt("BumperAmount", testBumpersToSpawn);
        GenerateBumpers(testBumpersToSpawn);
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && timerOn == true)
        {
            DisableBumperRenderers();
            b_s.instantiatedArrow.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("PinBal Recal Test Scene");
        }
    }

    public void Levelup()
    {
        testBumpersToSpawn += 1;
        PlayerPrefs.SetInt("BumperAmount", testBumpersToSpawn);
        Debug.Log(testBumpersToSpawn);
    }

    void GenerateBumpers(int bumperAmount)
    {
        //Randomize ball position first because the bumper needs to be aware of where the ball spawns before it can be generated

        print("Ball position: " + ballPosition.x + "\t" + ballPosition.y);

        for (int i = 0; i < bumperAmount; i++)
        {
            GenerateBumper(i == 0);
        }
    }

    void GenerateBumper(bool firstIteration)
    {
        if (firstIteration)
        {
            lastBumperIsBumper1 = Random.Range(0, 2) == 0;

            //Determine direction of the ball, generate a random bumper position
            //Then align the bumper with the ball so that the ball will hit the bumper
            ballDirection = Direction.Nothing;
            if (ballPosition.x == 0)
            {
                ballDirection = Direction.Right;
                bumperPosition = GenerateRandomBumperIndex();
                bumperPosition.y = ballPosition.y;
            }
            else if (ballPosition.y == 0)
            {
                ballDirection = Direction.Up;
                bumperPosition = GenerateRandomBumperIndex();
                bumperPosition.x = ballPosition.x;
            }
            else if (ballPosition.x == board.GetLength(0) - 1)
            {
                ballDirection = Direction.Left;
                bumperPosition = GenerateRandomBumperIndex();
                bumperPosition.y = ballPosition.y;
            }
            else if (ballPosition.y == board.GetLength(1) - 1)
            {
                ballDirection = Direction.Down;
                bumperPosition = GenerateRandomBumperIndex();
                bumperPosition.x = ballPosition.x;
            }

            Debug.Assert(ballDirection != Direction.Nothing, "The ball goes nowhere??");

            if (!IsValidBumper(GetBumperSide(), ballDirection, lastBumperIsBumper1))
            {
                Debug.Log("Swapping first bumper. Old: " + lastBumperIsBumper1);
                lastBumperIsBumper1 = !lastBumperIsBumper1;
            }
        }
        else
        {
            //Calculate the direction of the ball after it bounces off the first bumper
            //Spawn a bumper at the position that we predict the ball will be going next.
            //Use the same x/y of the last bumper, adjust x/y based on the direction of the ball
            //If the bumper isn't valid (bounces the ball off the field immediately) then flip the bumper 
            if (ballDirection == Direction.Up)
            {
                ballDirection = lastBumperIsBumper1 ? Direction.Right : Direction.Left;

                bumperPosition.x = lastBumperIsBumper1 ? Random.Range((int)bumperPosition.x + 1, board.GetLength(0) - 1) : Random.Range(1, (int)bumperPosition.x);
                if (!IsValidBumper(GetBumperSide(), ballDirection, lastBumperIsBumper1))
                {
                    lastBumperIsBumper1 = !lastBumperIsBumper1;
                }
            }
            else if (ballDirection == Direction.Down)
            {
                ballDirection = lastBumperIsBumper1 ? Direction.Left : Direction.Right;
                bumperPosition.x = lastBumperIsBumper1 ? Random.Range(1, (int)bumperPosition.x) : Random.Range((int)bumperPosition.x + 1, board.GetLength(0) - 1);
                if (!IsValidBumper(GetBumperSide(), ballDirection, lastBumperIsBumper1))
                {
                    lastBumperIsBumper1 = !lastBumperIsBumper1;
                }
            }
            else if (ballDirection == Direction.Left)
            {
                ballDirection = lastBumperIsBumper1 ? Direction.Down : Direction.Up;
                bumperPosition.y = lastBumperIsBumper1 ? Random.Range(1, (int)bumperPosition.y) : Random.Range((int)bumperPosition.y + 1, board.GetLength(1) - 1);
                if (!IsValidBumper(GetBumperSide(), ballDirection, lastBumperIsBumper1))
                {
                    lastBumperIsBumper1 = !lastBumperIsBumper1;
                }
            }
            else if (ballDirection == Direction.Right)
            {
                ballDirection = lastBumperIsBumper1 ? Direction.Up : Direction.Down;
                bumperPosition.y = lastBumperIsBumper1 ? Random.Range((int)bumperPosition.y + 1, board.GetLength(1) - 1) : Random.Range(1, (int)bumperPosition.y);
                if (!IsValidBumper(GetBumperSide(), ballDirection, lastBumperIsBumper1))
                {
                    lastBumperIsBumper1 = !lastBumperIsBumper1;
                }
            }
        }

        //Spawn the bumper if the calculated index is available
        SpawnEntity spawnPlace = board[(int)bumperPosition.x, (int)bumperPosition.y];
        if (spawnPlace == SpawnEntity.Empty)
        {
            SpawnBumper(bumperPosition, lastBumperIsBumper1);
            Debug.Log(ballDirection);
        }
        else
        {
            //Recursively call GenerateBumper again till we find a spot
            GenerateBumper(false);
        }
    }

    private bool IsValidBumper(BorderSide bumperSide, Direction ballDirection, bool isBumper1)
    {
        switch (bumperSide)
        {
            case BorderSide.Top:
                return isBumper1 ? ballDirection != Direction.Right : ballDirection != Direction.Left;
            case BorderSide.Bottom:
                return isBumper1 ? ballDirection != Direction.Left : ballDirection != Direction.Right;
            case BorderSide.Right:
                return isBumper1 ? ballDirection != Direction.Up : ballDirection != Direction.Down;
            case BorderSide.Left:
                return isBumper1 ? ballDirection != Direction.Down : ballDirection != Direction.Up;
            //For the corners, there's a few very specific directions that are/aren't allowed. 
            //This could probably be done in a cleaner way but we don't have time to do so, so this will do for now.
            case BorderSide.BottomLeft:
                if (isBumper1)
                    return ballDirection != Direction.Left && ballDirection != Direction.Down;
                else
                    return ballDirection == Direction.Left || ballDirection == Direction.Down;
            case BorderSide.TopLeft:
                if (isBumper1)
                    return ballDirection != Direction.Right && ballDirection != Direction.Down;
                else
                    return ballDirection == Direction.Right || ballDirection == Direction.Down;
            case BorderSide.BottomRight:
                if (isBumper1)
                    return ballDirection != Direction.Left && ballDirection != Direction.Up;
                else
                    return ballDirection == Direction.Left || ballDirection == Direction.Up;
            case BorderSide.TopRight:
                if (isBumper1)
                    return ballDirection == Direction.Down || ballDirection == Direction.Left;
                else
                    return ballDirection != Direction.Left && ballDirection != Direction.Down;
            case BorderSide.Nothing:
            default:
                return true;
        }
    }

    BorderSide GetBumperSide()
    {
        //Check what edges we are touching, then detect whether we're on corners or just borders, or nothing.
        bool bottomEdge = bumperPosition.y == 1;
        bool topEdge = bumperPosition.y == board.GetLength(1) - 2;
        bool leftEdge = bumperPosition.x == 1;
        bool rightEdge = bumperPosition.x == board.GetLength(0) - 2;

        if (!bottomEdge && !topEdge)
        {
            if (leftEdge)
                return BorderSide.Left;
            else if (rightEdge)
                return BorderSide.Right;
        }
        else if (!leftEdge && !rightEdge)
        {
            if (topEdge)
                return BorderSide.Top;
            else if (topEdge)
                return BorderSide.Bottom;
        }

        //Corners
        if (bottomEdge && leftEdge)
            return BorderSide.BottomLeft;
        else if (topEdge && leftEdge)
            return BorderSide.TopLeft;
        else if (bottomEdge && rightEdge)
            return BorderSide.BottomRight;
        else if (topEdge && rightEdge)
            return BorderSide.TopRight;
        return BorderSide.Nothing;
    }

    private void SpawnBumper(Vector2 randomBumperIndex, bool isBumper1)
    {
        board[(int)randomBumperIndex.x, (int)randomBumperIndex.y] = SpawnEntity.Bumper;
        Vector3 position = GetSpawnPositionByIndex((int)randomBumperIndex.x, (int)randomBumperIndex.y);

        GameObject instantiatedBumper = Instantiate(bumpers[isBumper1 ? 0 : 1], transform);
        spawnedBumpers.Add(instantiatedBumper);
        instantiatedBumper.transform.position = position;
        instantiatedBumper.transform.rotation = isBumper1 ? Quaternion.Euler(new Vector3(0, -45, 0)) : Quaternion.Euler(new Vector3(0, 45, 0));
    }

    void DisableBumperRenderers()
    {
        for (int i = 0; i < spawnedBumpers.Count; i++)
        {
            spawnedBumpers[i].GetComponent<MeshRenderer>().enabled = false;
            timerOn = false;
        }
    }

    private Vector2 GenerateRandomBumperIndex()
    {
        //Get a random position on the board, excluding position 0 and max
        return new Vector2(Random.Range(1, board.GetLength(0) - 1), Random.Range(1, board.GetLength(1) - 1));
    }

    private void RandomizeBall()
    {
        int randomDirection = Random.Range(0, 4);
        int randomBallPosition = Random.Range(1, 4);

        switch (randomDirection)
        {
            case 0:
                ballPosition = new Vector2(0, randomBallPosition);
                board[0, randomBallPosition] = SpawnEntity.Ball;
                b_s.SetUpcomingBallPosition(GetSpawnPositionByIndex(0, randomBallPosition), Vector3.up * 90, transform);
                break;
            case 1:
                ballPosition = new Vector2(board.GetLength(0) - 1, randomBallPosition);
                board[4, randomBallPosition] = SpawnEntity.Ball;
                b_s.SetUpcomingBallPosition(GetSpawnPositionByIndex(board.GetLength(0) - 1, randomBallPosition), Vector3.up * -90, transform);
                break;
            case 2:
                ballPosition = new Vector2(randomBallPosition, 0f);
                board[randomBallPosition, 0] = SpawnEntity.Ball;
                b_s.SetUpcomingBallPosition(GetSpawnPositionByIndex(randomBallPosition, 0), Vector3.zero, transform);
                break;
            case 3:
                ballPosition = new Vector2(randomBallPosition, board.GetLength(0) - 1);
                board[randomBallPosition, board.GetLength(0) - 1] = SpawnEntity.Ball;
                b_s.SetUpcomingBallPosition(GetSpawnPositionByIndex(randomBallPosition, board.GetLength(0) - 1), Vector3.up * 180, transform);
                break;
        }

    }

    public Vector3 GetSpawnPositionByIndex(int x, int y)
    {
        Vector3 verticalOffset = Vector3.forward * verticalSpacing * y;
        Vector3 horizontalOffset = Vector3.right * horizontalSpacing * x;
        return transform.position + verticalOffset + horizontalOffset;
    }

    /*void OnDrawGizmos()
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
    }*/
}