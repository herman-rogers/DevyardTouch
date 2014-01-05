using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//Drag this onto an object in-scene
public class DemoGraph : MonoBehaviour {
	Dictionary< int, string > forestNodes = new Dictionary<int, string>( );
	Graph< string >           demoGraph = new Graph< string >( );
	int                       graphLength = 4;
	void Start ( ) {
		CreateNodes( "Forest" );
		CreateEdges( );
	}
	void Update( ){
		Debug.Log( demoGraph.Count ); //number of Nodes you've added
		Debug.Log( demoGraph.Contains( "ForestNode1" ) );
		Debug.Log( demoGraph.Contains( "ForestNode4" ) );
	}
	void CreateNodes( string regionName ){
		for ( int i = 1; i <= graphLength; i++  ){
			demoGraph.AddNode( regionName + "Node" + i );
			forestNodes.Add( i, regionName + "Node" + i );
		}
	}
	void CreateEdges(  ){
		try{
		    demoGraph.AddUndirectedEdge( forestNodes[1], forestNodes[2], 1 );
			demoGraph.AddUndirectedEdge( forestNodes[2], forestNodes[3], 1 );
			demoGraph.AddUndirectedEdge( forestNodes[3], forestNodes[4], 1 );
			demoGraph.AddUndirectedEdge( forestNodes[4], forestNodes[2], 1 );
		} catch ( System.NullReferenceException ) {
			Debug.LogWarning( "Some GraphEdges could not be found : Have you changed the names?" );
		}
	}
}
