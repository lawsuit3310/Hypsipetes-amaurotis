using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorySender : Singleton<StorySender>
{
    int story;

    public void SetStory(int _story)
    {
        story = _story;
    }
    
    public int GetStory() 
    { 
        return story;   
    }
}
