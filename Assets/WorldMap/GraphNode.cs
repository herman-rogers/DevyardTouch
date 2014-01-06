using System.Collections;
using System.Collections.Generic;

//Base class that finds a Nodes position in relation to the Graph as a whole.
//Used for Graph.cs
public class GraphNode< T > : Node< T > {
	private List< int > costs;
	public  GraphNode( ) : base( ){ }
	public  GraphNode( T value ) : base( value ){ }
	public  GraphNode( T value, NodeList< T > neighbors ) : base( value, neighbors ){ }
	/// <summary>
	///Neighbors :
	///Exposes the protected class in NodeList. 
	///It tells us which nodes neighbor other nodes.
	/// </summary>
	/// <value>The neighbors.</value>
	new public NodeList< T > Neighbors{
		get{
			if ( base.Neighbors == null ){
				base.Neighbors = new NodeList< T >( );
			}
			return base.Neighbors;
		}
	}
	/// <summary>
	/// DistanceCost :
	/// Maps a weight value ( i.e. Cost ) from the current GraphNode
	/// to a specified neightboring node.
	/// </summary>
	/// <value>The distance costs.</value>
	public List< int > DistanceCosts{
		get{
			if ( costs == null ){
				costs = new List<int>( );
			}
			return costs;
		}
	}
}
