using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAction : MonoBehaviour
{

    public abstract void Channel(float value);
    public abstract void ChannelInterrupt();

    public abstract void ChannelComplete();
}
