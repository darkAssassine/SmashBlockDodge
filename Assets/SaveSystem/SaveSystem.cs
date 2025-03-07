using System;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private static readonly string encryptionCodeWord = "This is the best project you will see in your life!";

    private static string path = Application.persistentDataPath + "/";

    /// <summary>
    /// Saves a object with the ISaveData implemented
    /// </summary>
    /// <param name="objectToSave">Must implement the ISaveData inferface</param>
    public static void Save<T>(string fileName, T objectToSave)
    {
        ValidateSaveDataType<T>();

        string saveFile = path + fileName + ".save";
        string dataToSave = JsonUtility.ToJson(objectToSave, true);

        //dataToSave = EncryptDecrypt(dataToSave);
        File.WriteAllText(saveFile, dataToSave);
    }

    public static T Load<T>(string fileName)
    {
        ValidateSaveDataType<T>();

        string savedContent = path + fileName + ".save";

        //savedContent = EncryptDecrypt(savedContent);
        return JsonUtility.FromJson<T>(savedContent);
    }

    // https://youtu.be/aUi9aijvpgs?si=CamS1HS7SOrh1rtO
    // Shaped by Rain Studios
    private static string EncryptDecrypt(string data)
    {
        char[] encryptedChars = new char[data.Length];

        for (int i = 0; i < data.Length; i++)
        {
            encryptedChars[i] = (char) (data[i] ^ encryptionCodeWord[i % encryptionCodeWord.Length]);
        }
        return new string(encryptedChars);
    }

    private static void ValidateSaveDataType<T>()
    {
        if (typeof(ISaveData).IsAssignableFrom(typeof(T)) == false)
        {
            throw new InvalidOperationException("The loaded type does not implement ISaveData.");
        }
    }
}
