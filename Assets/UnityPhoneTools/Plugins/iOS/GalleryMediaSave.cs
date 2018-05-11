#if !UNITY_EDITOR && UNITY_IOS
using UnityEngine;

namespace NativePhoto
{
	public class GalleryMediaSave : MonoBehaviour
	{
		private static GalleryMediaSave instance;
		private NativePhoto.MediaSaveCallback callback;

		public static void Initialize( NativePhoto.MediaSaveCallback callback )
		{
			if( instance == null )
			{
				instance = new GameObject( "GalleryMediaSave" ).AddComponent<GalleryMediaSave>();
				DontDestroyOnLoad( instance.gameObject );
			}
			else if( instance.callback != null )
				instance.callback( null );

			instance.callback = callback;
		}
		
		public void OnMediaSaveCompleted( string message )
		{
			if( callback != null )
			{
				callback( null );
				callback = null;
			}
		}

		public void OnMediaSaveFailed( string error )
		{
			if( string.IsNullOrEmpty( error ) )
				error = "Unknown error";

			if( callback != null )
			{
				callback( error );
				callback = null;
			}
		}
	}
}
#endif