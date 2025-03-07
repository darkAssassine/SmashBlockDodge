using System;
using System.Collections.Generic;

[Serializable]
public class SaveData : ISaveData
{
    protected SerializableDictonary<string, int> IntValuesToSave = new SerializableDictonary<string, int>();
    protected SerializableDictonary<string, float> FloatValuesToSave = new SerializableDictonary<string, float>();
    protected SerializableDictonary<string, bool> BoolValuesToSave = new SerializableDictonary<string, bool>();
    protected SerializableDictonary<string, string> StringValuesToSave = new SerializableDictonary<string, string>();

    public void CreateOrSetInt(string variableName, int value)
    {
         IntValuesToSave[variableName] = value;
    }

    public void CreateOrSetFloat(string variableName, float value)
    {
        FloatValuesToSave[variableName] = value;
    }

    public void CreateOrSetBool(string variableName, bool value)
    {
        BoolValuesToSave[variableName] = value;
    }

    public void CreateOrSetString(string variableName, string value)
    {
        StringValuesToSave[variableName] = value;
    }
}


