using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class saveSystem
{
    public static void saveVictories(List<victoryType> victories)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = createVictoriesPath();

        FileStream stream = new FileStream(path, FileMode.Create);
        victoriesData data = new victoriesData(victories);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void saveLeaderBoard(List<game> games)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = createLeaderBoardPath();

        FileStream stream = new FileStream(path, FileMode.Create);

        leaderboardData data = new leaderboardData(games);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void saveVolume(float SFX, float music)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = createVolumePath();

        FileStream stream = new FileStream(path, FileMode.Create);

        volumeData data = new volumeData(SFX, music);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static victoriesData loadVictories()
    {
        string path = createVictoriesPath();
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            victoriesData data = formatter.Deserialize(stream) as victoriesData;
            stream.Close();
            return data;
        }
        else
        {
            return null;
        }
    }
    public static leaderboardData loadLeaderBoard()
    {
        string path = createLeaderBoardPath();
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            leaderboardData data = formatter.Deserialize(stream) as leaderboardData;
            stream.Close();
            return data;
        }
        else
        {
            return null;
        }
    }
    public static volumeData loadVolume()
    {
        string path = createVolumePath();
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            volumeData data = formatter.Deserialize(stream) as volumeData;
            stream.Close();
            return data;
        }
        else
        {
            return null;
        }
    }
    /*
    public static void saveAttributes()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = createAttributesPath();

        FileStream stream = new FileStream(path, FileMode.Create);

        AttributesData data = new AttributesData();
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static AttributesData loadAttributes()
    {
        string path = createAttributesPath();
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            AttributesData data = formatter.Deserialize(stream) as AttributesData;
            stream.Close();
            return data;
        }
        else
        {
            return null;
        }
    }*/


    public static string createVictoriesPath()
    {
        return Application.persistentDataPath + "/victories.txt";
    }
    public static string createLeaderBoardPath()
    {
        return Application.persistentDataPath + "/leaderBoard.txt";
    }
    public static string createVolumePath()
    {
        return Application.persistentDataPath + "/volume.txt";
    }

}
