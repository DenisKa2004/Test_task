using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

[System.Serializable]
public class TransformData
{
    public Vector3 position;
    public Quaternion rotation;

    public TransformData(Vector3 pos, Quaternion rot)
    {
        position = pos;
        rotation = rot;
    }
}
public class UIController : MonoBehaviour
{
    [Header("Объект сохранения")]
    [SerializeField]
    private GameObject objectToSave;

    private string GetSaveFilePath()
    {
        return Application.persistentDataPath + "/transformData.json";
    }

    void Start()
    {
        string path = GetSaveFilePath();

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            TransformData data = JsonUtility.FromJson<TransformData>(json);

            Transform objectTransform = objectToSave.transform;
            objectTransform.position = data.position;
            objectTransform.rotation = data.rotation;
            Debug.Log("Сохраненные данные: " + json);
        }
        else
        {
            Debug.LogWarning("Сохранение не найдено");
        }
    }

    public void ResetJaw()
    {
        string path = GetSaveFilePath();

        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("Сохранение удаленно");
        }
        else
        {
            Debug.LogWarning("Сохранение не найдено");
        }
        SceneManager.LoadScene("Main_Scene");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Save()
    {
        Transform objectTransform = objectToSave.transform;
        TransformData data = new TransformData(objectTransform.position, objectTransform.rotation);

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/transformData.json", json);
        Debug.Log("Сохраненные данные: " + json);
    }
}
