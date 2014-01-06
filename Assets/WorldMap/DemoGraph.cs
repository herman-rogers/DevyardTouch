using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//Drag this onto an object in-scene
public class DemoGraph : MonoBehaviour {
	Dictionary< int, string > forestNodes = new Dictionary<int, string>( );
	Dictionary< int, string > desertNodes = new Dictionary<int, string>( );
	Graph< string >           demoGraph = new Graph< string >( );
	void Start ( ) {
		//First Section of the Map Created
		CreateNodes( "Forest", 4, forestNodes );
		CreateEdges( forestNodes );
		//Second Section of the Map Created
		CreateNodes( "Desert", 6, desertNodes );
		CreateEdges( desertNodes );
	}
	void Update( ){
		Debug.Log( demoGraph.Count ); //number of Nodes you've added
		Debug.Log( demoGraph.Contains( "ForestNode1" ) );
		Debug.Log( demoGraph.Contains( "DesertNode4" ) );
	}
	void CreateNodes( string regionName, int mapLength, Dictionary< int, string > nodeDict ){
		for ( int i = 1; i <= mapLength; i++  ){
			demoGraph.AddNode( regionName + "Node" + i );
			nodeDict.Add( i, regionName + "Node" + i );
		}
	}
	void CreateEdges( Dictionary< int, string > nodeDict  ){
		try{
		    demoGraph.AddUndirectedEdge( nodeDict[1], nodeDict[2], 1 );
			demoGraph.AddUndirectedEdge( nodeDict[2], nodeDict[3], 1 );
			demoGraph.AddUndirectedEdge( nodeDict[3], nodeDict[4], 1 );
			demoGraph.AddUndirectedEdge( nodeDict[4], nodeDict[2], 1 );
		} catch ( System.NullReferenceException ) {
			Debug.LogWarning( "Some GraphEdges could not be found : Have you changed the names?" );
		}
	}
}
