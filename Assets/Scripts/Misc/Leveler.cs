using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leveler : MonoBehaviour
{

    [HideInInspector] public int testBumpersToSpawn;
    [HideInInspector] public int boardSize;

    public void LevelUpTile()
    {
        testBumpersToSpawn = PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "BumperAmount");
        if (testBumpersToSpawn < 7)
            testBumpersToSpawn += 1;
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "BumperAmount", testBumpersToSpawn);
    }
    public void LevelUpBoard()
    {
        testBumpersToSpawn = PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "BumperAmount");
        boardSize = PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "BoardSize");
        if (testBumpersToSpawn < 7)
            testBumpersToSpawn += 1;
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "BumperAmount", testBumpersToSpawn);
        if (boardSize < 5 + 2)
            boardSize += 1;
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "BoardSize", boardSize);
    }
    public void LevelDownTile()
    {

        testBumpersToSpawn = PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "BumperAmount");
        if (testBumpersToSpawn > 1)
            testBumpersToSpawn -= 1;
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "BumperAmount", testBumpersToSpawn);
    }

    public void LevelDownBoard()
    {
        testBumpersToSpawn = PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "BumperAmount");
        boardSize = PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "BoardSize");
        if (testBumpersToSpawn > 1)
            testBumpersToSpawn -= 1;
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "BumperAmount", testBumpersToSpawn);
        if (boardSize > 5)
            boardSize -= 1;
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "BoardSize", boardSize);
    }
}
