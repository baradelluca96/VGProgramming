using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAction : MonoBehaviour
{

    public virtual float ChannelStep(){
        return 0.5f;
    }
    public abstract void Channel(float value);
    public abstract void ChannelInterrupt();

    public abstract void ChannelComplete();
}
