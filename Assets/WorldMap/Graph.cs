using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//The Main Class used to create Graphs ( base class for higherlevel graph creation )
public class Graph< T > : IEnumerable< T > {
	#region IEnumerable implementation
	public IEnumerator<T> GetEnumerator ()
	{
		throw new System.NotImplementedException ();
	}
	IEnumerator IEnumerable.GetEnumerator ()
	{
		throw new System.NotImplementedException ();
	}
	#endregion
	private NodeList< T > nodeSet;
	public  Graph( ) : this( null ){ }
	public  Graph( NodeList< T > nodeSet ){ 
		if ( nodeSet == null ){
			this.nodeSet = new NodeList< T >( );
		} else {
			this.nodeSet = nodeSet;
		}
	}
	/// <summary>
	/// AddNode :
	/// Adds a node to the graph 
	/// </summary>
	/// <param name="node">Node.</param>
	public void AddNode( GraphNode< T > node ){
		nodeSet.Add( node );
	}
	public void AddNode( T value ){
		nodeSet.Add( new GraphNode< T >( value ) );
	}
	/// <summary>
	/// AddDorectedEdge :
	/// Adds a ONE-WAY directional path from current node A to new node B
	/// Remember that once you move from A to B theres not coming back!
	/// </summary>
	/// <param name="from">From.</param>
	/// <param name="to">To.</param>
	/// <param name="cost">Cost.</param>
	public void AddDirectedEdge( T from, T to, int cost ){
		//Convert the value you're passing in into a "Node" type
		GraphNode< T > fromNode = ConvertToNode( from );
		GraphNode< T > toNode   = ConvertToNode( to ) ;
		fromNode.Neighbors.Add( toNode );
		fromNode.DistanceCosts.Add( cost );
	}
	/// <summary>
	/// AddUndirectedEdge :
	/// Adds a TWO-WAY directional path between current node A and new node B
	/// Traveling from node A to node B and then deciding go back to A is possible.
	/// </summary>
	/// <param name="from">From.</param>
	/// <param name="to">To.</param>
	/// <param name="cost">Cost.</param>
	public void AddUndirectedEdge( T from, T to, int cost ){
		//Convert the value you're passing in into a "Node" type
		GraphNode< T > fromNode = ConvertToNode( from );
		GraphNode< T > toNode   = ConvertToNode( to );
		fromNode.Neighbors.Add( toNode );
		fromNode.DistanceCosts.Add( cost );
		//Open path back to previous node
		toNode.Neighbors.Add( fromNode );
		toNode.DistanceCosts.Add( cost );
	}
	/// <summary>
	/// Contains :
	/// Check if map contains the specified value. Return true if it exists.
	/// </summary>
	/// <param name="value">Value.</param>
	public string Contains( T value ){
		bool isInList = nodeSet.FindByValue( value ) != null;
		return " Is " + value + " in your map? " + isInList;
	}
	/// <summary>
	/// Remove :
	/// Removes a node, its path, and weighted value
	/// from the graph
	/// </summary>
	/// <param name="value">Value.</param>
	public bool Remove( T value ){
		//first remove node from the nodeSet
		GraphNode< T > nodeToRemove = ( GraphNode< T > ) nodeSet.FindByValue( value );
		if ( nodeToRemove == null ){
			//Node does not exist
			Debug.Log( "Dear me, the node you want to remove doesn't exist!" );
			return false;
		}
		//Else the node has been found, and will now be removed
		nodeSet.Remove( nodeToRemove );
		//Destroy the edges to this node
		foreach( GraphNode< T > graphNode in nodeSet ){
			int index = graphNode.Neighbors.IndexOf( nodeToRemove );
			if ( index != -1 ){
				//remove the reference and the associated cost
				graphNode.Neighbors.RemoveAt( index );
				graphNode.DistanceCosts.RemoveAt( index );
			}
		}
		Debug.Log( "The node was removed successfully" );
		return true;
	}
	/// <summary>
	/// ConvertToNode :
    /// Converts from any value T to a GraphNode value type
	/// </summary>
	/// <returns>The to node.</returns>
	/// <param name="dataToNode">Data to node.</param>
	public GraphNode< T > ConvertToNode( T dataToNode ){
		GraphNode< T > nodeData = ( GraphNode< T > ) nodeSet.FindByValue( dataToNode );
		return nodeData;
	}
	/// <summary>
	/// Gets the list of nodes.
	/// </summary>
	/// <value>The nodes.</value>
	public NodeList< T > Nodes{
		get{
			return nodeSet;
		}
	}
	/// <summary>
	/// Gets the count of nodes in graph.
	/// </summary>
	/// <value>The count.</value>
	public int Count{
		get{ return nodeSet.Count; }
	}
}