using UnityEngine;
using System.Collections.Generic;
public class LevelManager : MonoBehaviour
{
    public GameObject door;
    public GameObject collectablePrefab;
    public List<GameObject> collectables;
    public void RestartLevel()
    {
        DeactivateDoor();
        RandomizeDoorPosition();
        DeleteCollectables();
        GenerateCollactables();
    }

    private void DeleteCollectables()
    {
        foreach (GameObject c in collectables)
        {
            Destroy(c);
        }
        collectables.Clear();

    }

    private void GenerateCollactables()
    {
        var newCollectable = Instantiate(collectablePrefab);
        newCollectable.transform.position = new Vector3 (13,0,UnityEngine.Random.Range(4,-4)); 
        collectables.Add(newCollectable);

    }

    private void RandomizeDoorPosition()
    {
        var pos = door.transform.position;
        pos.z = Random.Range(-1f, 1f);
        door.transform.position = pos;
    }

    private void DeactivateDoor()
    {
        door.SetActive(false);
    }

    public void Collected()
    {
        door.SetActive(true);
    }
}
