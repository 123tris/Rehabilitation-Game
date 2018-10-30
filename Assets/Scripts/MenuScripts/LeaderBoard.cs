using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class User
{
    public string name;

    public List<int> easyScores;
    public List<int> mediumScores;
    public List<int> hardScores;
}

public class Data
{
    public List<User> users;
}
    
public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private Text[] scoreTexts = new Text[3];

    #region Data Management
    private static Data data
    {
        get
        {
            if (_data == null)
            {
                _data = Load();
                Save();
            }
            return _data;
        }
    }
    private static Data _data;

    private static bool isDirty = true;

    private static Data Load()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Data));

        Data data = null;
        XmlReader reader = new XmlTextReader("Assets/Resources/LeaderboardData.txt");
        try
        {
            data = serializer.Deserialize(reader) as Data;
            reader.Close();
        }
        catch (Exception e)
        {
            reader.Close();
            Debug.LogWarning(e);
        }
        if (data == null)
            data = new Data {users = new List<User>()};

        return data;
    }

    public static void Save()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Data));
        TextWriter writer = new StreamWriter("Assets/Resources/LeaderboardData.txt", false);
        serializer.Serialize(writer, data);
        writer.Close();

        isDirty = true;
    }

    public static User AddUser(string userName, bool saveImmediately = true)
    {
        User user = new User
        {
            name = userName,
            easyScores = new List<int>(),
            mediumScores = new List<int>(),
            hardScores = new List<int>()
        };
        data.users.Add(user);

        if (saveImmediately)
            Save();
        return user;
    }

    public static void AddScore(string userName, int difficulty, int score)
    {
        User user = data.users.First(user1 => user1.name == userName);
        if (user == null)
            user = AddUser(userName);

        switch (difficulty)
        {
            case 1:
                user.easyScores.Add(score);
                user.easyScores.Sort();
                break;
            case 2:
                user.mediumScores.Add(score);
                user.mediumScores.Sort();
                break;
            case 3:
                user.hardScores.Add(score);
                user.hardScores.Sort();
                break;
        }

        Save();
    }

    public static IEnumerable<int> GetScores(string userName, int difficulty)
    {
        User user = data.users.First(user1 => user1.name == userName);
        if (user == null)
            user = AddUser(userName);

        switch (difficulty)
        {
            case 1:
                return new List<int>(user.easyScores);
            case 2:
                return new List<int>(user.mediumScores);
            case 3:
                return new List<int>(user.hardScores);
        }
        return null;
    }

    public static IEnumerable<KeyValuePair<string, int>> GetAllScores(int difficulty)
    {
        List<KeyValuePair<string, int>> result = new List<KeyValuePair<string, int>>();
        foreach (User user in data.users)
        {
            IEnumerable<int> scores = GetScores(user.name, difficulty);
            if (scores == null)
                continue;
            result.AddRange(scores.Select(score => new KeyValuePair<string, int>(user.name, score)));
        }

        result.Sort((pair1, pair2) => -pair1.Value.CompareTo(pair2.Value));

        return result;
    }
    #endregion

    private void LateUpdate()
    {
        if (isDirty)
        {
            for (int i = 0; i < 3; i++)
            {
                Text scoreText = scoreTexts[i];
                scoreText.text = "";
                foreach (var score in GetAllScores(difficulty: i+1))
                    scoreText.text += score.Key + ": " + score.Value + "\n";
            }
        }
    }
}

#if UNITY_EDITOR
[UnityEditor.CustomEditor(typeof(LeaderBoard))]
class LeaderBoardEditor : UnityEditor.Editor
{
    private string nameToAdd = "";
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        UnityEditor.EditorGUILayout.LabelField("Debugging", UnityEditor.EditorStyles.boldLabel);
        nameToAdd = UnityEditor.EditorGUILayout.TextField("User name", nameToAdd);
        if (GUILayout.Button("Add random user") && nameToAdd != "")
        {
            User user = LeaderBoard.AddUser(nameToAdd);
            
            for(int i = 0; i < 5; i++)
                user.easyScores.Add(UnityEngine.Random.Range(0, 1000));
            for (int i = 0; i < 5; i++)
                user.mediumScores.Add(UnityEngine.Random.Range(0, 1000));
            for (int i = 0; i < 5; i++)
                user.hardScores.Add(UnityEngine.Random.Range(0, 1000));

            nameToAdd = "";
        }
    }
}

#endif