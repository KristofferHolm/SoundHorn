#if UNITY_EDITOR
using UnityEditor;
using System.IO;
using Managers;

public class GenerateEnum
{
    [MenuItem("Tools/Generate Sound Enum")]
    public static void Go()
    {
        string enumName = "SoundEnum";
        string[] enumEntries = SoundLibrary.Instance.Enums;
        string filePathAndName = "Assets/SoundHorn/Scripts/Enums/" + enumName + ".cs"; //The folder Scripts/Enums/ is expected to exist

        using (StreamWriter streamWriter = new StreamWriter(filePathAndName))
        {
            streamWriter.WriteLine("public enum " + enumName);
            streamWriter.WriteLine("{");
            for (int i = 0; i < enumEntries.Length; i++)
            {
                streamWriter.WriteLine("\t" + enumEntries[i] + ",");
            }
            streamWriter.WriteLine("}");
        }
        AssetDatabase.Refresh();
    }

}
#endif
