using System.Collections;
using System.Collections.ObjectModel;

public class NodeList< T > : Collection< Node< T > > {
	public NodeList( ) : base( ){ }
	public NodeList( int initialSize ){
		//Add the specified number of items
		for ( int i = 0; i < initialSize; i++ ){
			base.Items.Add( default( Node< T > ) );
		}
	}
	/// <summary>
	/// FindByValue :
	/// Search the list for the value
	/// </summary>
	public Node< T > FindByValue( T value ){
		foreach( Node< T > node in Items ){
			if ( node.Value.Equals( value ) ){
				return node;
			}
		}
		//If we reached here, we didn't find a matching node
		return null;
	}
}
