using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

	public int ID { get; set; }
    public string LevelName { get; set; }
    public bool Completed { get; set; }
    public int Points {get; set;}
    public bool Locked { get; set; }

    public Level (int id, string levelName, bool completed, int points, bool locked)
    {
        this.ID = id;
        this.LevelName = levelName;
        this.Completed = completed;
        this.Points = points;
        this.Locked = locked;

    }
    public void Complete()
    {
        this.Completed = true;
    }
    public void Complete (int points)
    {
        this.Completed = true;
        this.Points = points;
    }
    
    public void Lock()
    {
        this.Locked = true;
    }

    public void Unlock()
    {
        this.Locked = false;
    }
}
