using UnityEngine;
using System;
using System.Collections;

public class ProceduralCity : MonoBehaviour
{
	[SerializeField]
	private bool _useSeed;
	[SerializeField]
	private int _seed;
	[SerializeField]
	private Pipeline _pipeline;
	[SerializeField]
	private RoadNetworkParameters _roadNetworkParameters;
	[SerializeField]
	private ArchitectureStyle[] _architectureStyle;

    public int WorldWidth
    {
        get
        {
            return _roadNetworkParameters.Width;
        }
    }
    public int WorldHeight
    {
        get
        {
            return _roadNetworkParameters.Height;
        }
    }

    void Start ()
	{
		if (_pipeline == null) {
			throw new Exception ("_pipeline == null");
		}
		
		if (!_useSeed) {
			int milliseconds = (int)(DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond);
			_seed = milliseconds;
		}
		UnityEngine.Random.seed = _seed;
        Debug.Log("seed: " + _seed);
		
		_pipeline.Run (_roadNetworkParameters, _architectureStyle);
	}
	
}